using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests {

    public class PlayerHPTest {

        /**
         * [正常] 渡された値が最小値以上最大値以下である場合に、値が正常に格納されること
         */
        [Test]
        public void ValidPlayerHP() {
            List<int> validNumberList = new List<int>() {
                0,
                50,
                100
            };

            foreach (int value in validNumberList) {
                PlayerHP playerHP = PlayerHP.Of(value);

                Assert.That(playerHP.Value, Is.EqualTo(value));
            }
        }

        /**
         * [正常] PlayerHP同士の加算が行われた場合に、値が正常に格納されること
         */
        [Test]
        public void ValidPlayerHPOperatorAdd() {

            PlayerHP playerHP = PlayerHP.Of(50);
            PlayerHP addPlayerHP = PlayerHP.Of(10);
            int responsePlayerHP = 60;

            Assert.That((playerHP + addPlayerHP).Value, Is.EqualTo(responsePlayerHP));
        }

        /**
         * [正常] PlayerHP同士の減算が行われた場合に、値が正常に格納されること
         */
        [Test]
        public void ValidPlayerHPOperatorSub() {
            PlayerHP playerHP = PlayerHP.Of(50);
            PlayerHP subPlayerHP = PlayerHP.Of(10);
            int responsePlayerHP = 40;

            Assert.That((playerHP - subPlayerHP).Value, Is.EqualTo(responsePlayerHP));
        }

        /**
         * [正常] PlayerHP同士の乗算が行われた場合に、値が正常に格納されること
         */
        [Test]
        public void ValidPlayerHPOperatorMul() {
            PlayerHP playerHP = PlayerHP.Of(20);
            PlayerHP mulPlayerHP = PlayerHP.Of(2);
            int responsePlayerHP = 40;

            Assert.That((playerHP * mulPlayerHP).Value, Is.EqualTo(responsePlayerHP));
        }

        /**
         * [正常] PlayerHP同士の除算が行われた場合に、値が正常に格納されること
         */
        [Test]
        public void ValidPlayerHPOperatorDiv() {
            PlayerHP playerHP = PlayerHP.Of(20);
            PlayerHP div = PlayerHP.Of(2);
            int responsePlayerHP = 10;

            Assert.That((playerHP / div).Value, Is.EqualTo(responsePlayerHP));
        }

        /**
         * [異常] 渡された値が最小値未満か最大値より大きい場合に、スローが投げられること
         */
        [Test]
        public void ThrowWhenValueIsOverRange() {
            List<int> invalidNumberList = new List<int>() {
                int.MinValue,
                -1,
                101,
                int.MaxValue
            };

            foreach (int value in invalidNumberList) {
                void PlayerHPMethod() {
                    PlayerHP.Of(value);
                }

                Assert.Throws<ArgumentException>(
                    PlayerHPMethod
                );
            }
        }

        /**
         * [正常] 加算した値が最大値より大きい場合に、最大値が格納されていること
         */
        [Test]
        public void LimitAddPlayerHP() {
            PlayerHP playerHP = PlayerHP.Of(100);
            PlayerHP addPlayerHP = PlayerHP.Of(10);
            int responsePlayerHP = 100;

            PlayerHP newPlayerHP = playerHP + addPlayerHP;
            Assert.That(newPlayerHP.Value, Is.EqualTo(responsePlayerHP));
        }

        /**
         * [正常] 減算した値が最小値より小さい場合に、最小値が格納されていること
         */
        [Test]
        public void LimitSubPlayerHP() {
            PlayerHP playerHP = PlayerHP.Of(0);
            PlayerHP subPlayerHP = PlayerHP.Of(10);
            int responsePlayerHP = 0;

            PlayerHP newPlayerHP = playerHP - subPlayerHP;
            Assert.That(newPlayerHP.Value, Is.EqualTo(responsePlayerHP));
        }

        /**
         * [正常] 乗算した値が最大値より大きい場合に、最大値が格納されていること
         */
        [Test]
        public void LimitMulPlayerHP() {
            PlayerHP playerHP = PlayerHP.Of(100);
            PlayerHP mulPlayerHP = PlayerHP.Of(2);
            int responsePlayerHP = 100;

            PlayerHP newPlayerHP = playerHP * mulPlayerHP;
            Assert.That(newPlayerHP.Value, Is.EqualTo(responsePlayerHP));
        }

        /**
         * [異常] PlayerHP同士の除算において0で割っている場合に、スローが投げられること
         */
        [Test]
        public void ThrowWhenDivPlayerHP() {
            PlayerHP playerHP = PlayerHP.Of(1);
            PlayerHP addPlayerHP = PlayerHP.Of(0);

            void PlayerHPMethod() {
                PlayerHP newPlayerHP = playerHP / addPlayerHP;
            }

            Assert.Throws<DivideByZeroException>(
                PlayerHPMethod
            );
        }

    }

}

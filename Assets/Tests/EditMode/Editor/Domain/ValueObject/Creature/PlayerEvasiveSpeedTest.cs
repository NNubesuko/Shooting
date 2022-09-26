using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests {

    public class PlayerEvasiveSpeedTest {

        /**
         * [正常] 渡された値が最小値以上最大値以下である場合に、値が正常に格納されること
         */
        [Test]
        public void ValidPlayerEvasiveSpeed() {
            List<int> validNumberList = new List<int>() {
                0,
                50,
                100
            };

            foreach (int value in validNumberList) {
                PlayerEvasiveSpeed PlayerEvasiveSpeed = PlayerEvasiveSpeed.Of(value);

                Assert.That(PlayerEvasiveSpeed.Value, Is.EqualTo(value));
            }
        }

        /**
         * [正常] PlayerEvasiveSpeed同士の加算が行われた場合に、値が正常に格納されること
         */
        [Test]
        public void ValidPlayerEvasiveSpeedOperatorAdd() {
            PlayerEvasiveSpeed PlayerEvasiveSpeed = PlayerEvasiveSpeed.Of(50);
            PlayerEvasiveSpeed addPlayerEvasiveSpeed = PlayerEvasiveSpeed.Of(10);
            int responsePlayerEvasiveSpeed = 60;

            Assert.That((PlayerEvasiveSpeed + addPlayerEvasiveSpeed).Value, Is.EqualTo(responsePlayerEvasiveSpeed));
        }

        /**
         * [正常] PlayerEvasiveSpeed同士の減算が行われた場合に、値が正常に格納されること
         */
        [Test]
        public void ValidPlayerEvasiveSpeedOperatorSub() {
            PlayerEvasiveSpeed PlayerEvasiveSpeed = PlayerEvasiveSpeed.Of(50);
            PlayerEvasiveSpeed subPlayerEvasiveSpeed = PlayerEvasiveSpeed.Of(10);
            int responsePlayerEvasiveSpeed = 40;

            Assert.That((PlayerEvasiveSpeed - subPlayerEvasiveSpeed).Value, Is.EqualTo(responsePlayerEvasiveSpeed));
        }

        /**
         * [正常] PlayerEvasiveSpeed同士の乗算が行われた場合に、値が正常に格納されること
         */
        [Test]
        public void ValidPlayerEvasiveSpeedOperatorMul() {
            PlayerEvasiveSpeed PlayerEvasiveSpeed = PlayerEvasiveSpeed.Of(20);
            PlayerEvasiveSpeed mulPlayerEvasiveSpeed = PlayerEvasiveSpeed.Of(2);
            int responsePlayerEvasiveSpeed = 40;

            Assert.That((PlayerEvasiveSpeed * mulPlayerEvasiveSpeed).Value, Is.EqualTo(responsePlayerEvasiveSpeed));
        }

        /**
         * [正常] PlayerEvasiveSpeed同士の除算が行われた場合に、値が正常に格納されること
         */
        [Test]
        public void ValidPlayerEvasiveSpeedOperatorDiv() {
            PlayerEvasiveSpeed PlayerEvasiveSpeed = PlayerEvasiveSpeed.Of(20);
            PlayerEvasiveSpeed div = PlayerEvasiveSpeed.Of(2);
            int responsePlayerEvasiveSpeed = 10;

            Assert.That((PlayerEvasiveSpeed / div).Value, Is.EqualTo(responsePlayerEvasiveSpeed));
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
                void PlayerEvasiveSpeedMethod() {
                    PlayerEvasiveSpeed.Of(value);
                }

                Assert.Throws<ArgumentException>(
                    PlayerEvasiveSpeedMethod
                );
            }
        }

        /**
         * [正常] 加算した値が最大値より大きい場合に、最大値が格納されていること
         */
        [Test]
        public void LimitAddPlayerEvasiveSpeed() {
            PlayerEvasiveSpeed playerEvasiveSpeed = PlayerEvasiveSpeed.Of(100);
            PlayerEvasiveSpeed addPlayerEvasiveSpeed = PlayerEvasiveSpeed.Of(10);
            int responsePlayerEvasiveSpeed = 100;

            PlayerEvasiveSpeed newPlayerEvasiveSpeed = playerEvasiveSpeed + addPlayerEvasiveSpeed;
            Assert.That(newPlayerEvasiveSpeed.Value, Is.EqualTo(responsePlayerEvasiveSpeed));
        }

        /**
         * [正常] 減算した値が最小値より小さい場合に、最小値が格納されていること
         */
        [Test]
        public void ThrowWhenSubPlayerEvasiveSpeed() {
            PlayerEvasiveSpeed PlayerEvasiveSpeed = PlayerEvasiveSpeed.Of(0);
            PlayerEvasiveSpeed addPlayerEvasiveSpeed = PlayerEvasiveSpeed.Of(10);
            int responsePlayerEvasiveSpeed = 0;

            PlayerEvasiveSpeed newPlayerEvasiveSpeed = PlayerEvasiveSpeed - addPlayerEvasiveSpeed;
            Assert.That(newPlayerEvasiveSpeed.Value, Is.EqualTo(responsePlayerEvasiveSpeed));
        }

        /**
         * [正常] 乗算した値が最大値より大きい場合に、最大値が格納されていること
         */
        [Test]
        public void ThrowWhenMulPlayerEvasiveSpeed() {
            PlayerEvasiveSpeed PlayerEvasiveSpeed = PlayerEvasiveSpeed.Of(100);
            PlayerEvasiveSpeed addPlayerEvasiveSpeed = PlayerEvasiveSpeed.Of(2);
            int responsePlayerEvasiveSpeed = 100;

            PlayerEvasiveSpeed newPlayerEvasiveSpeed = PlayerEvasiveSpeed * addPlayerEvasiveSpeed;
            Assert.That(newPlayerEvasiveSpeed.Value, Is.EqualTo(responsePlayerEvasiveSpeed));
        }

        /**
         * [異常] PlayerEvasiveSpeed同士の除算において0で割っている場合に、スローが投げられること
         */
        [Test]
        public void ThrowWhenDivPlayerEvasiveSpeed() {
            PlayerEvasiveSpeed PlayerEvasiveSpeed = PlayerEvasiveSpeed.Of(1);
            PlayerEvasiveSpeed addPlayerEvasiveSpeed = PlayerEvasiveSpeed.Of(0);

            void PlayerEvasiveSpeedMethod() {
                PlayerEvasiveSpeed newPlayerEvasiveSpeed = PlayerEvasiveSpeed / addPlayerEvasiveSpeed;
            }

            Assert.Throws<DivideByZeroException>(
                PlayerEvasiveSpeedMethod
            );
        }

    }

}

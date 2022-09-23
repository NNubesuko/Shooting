using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests {
    
    public class PlayerMoveSpeedTest {

        /**
         * [正常] 渡された値が最小値以上最大値以下である場合に、値が正常に格納されること
         */
        [Test]
        public void ValidPlayerMoveSpeed() {
            List<int> validNumberList = new List<int>() {
                0,
                5,
                10
            };

            foreach (int value in validNumberList) {
                PlayerMoveSpeed PlayerMoveSpeed = PlayerMoveSpeed.Of(value);

                Assert.That(PlayerMoveSpeed.Value, Is.EqualTo(value));
            }
        }

        /**
         * [正常] PlayerMoveSpeed同士の加算が行われた場合に、値が正常に格納されること
         */
        [Test]
        public void ValidPlayerMoveSpeedOperatorAdd() {

            PlayerMoveSpeed PlayerMoveSpeed = PlayerMoveSpeed.Of(5);
            PlayerMoveSpeed addPlayerMoveSpeed = PlayerMoveSpeed.Of(1);
            int responsePlayerMoveSpeed = 6;

            Assert.That((PlayerMoveSpeed + addPlayerMoveSpeed).Value, Is.EqualTo(responsePlayerMoveSpeed));
        }

        /**
         * [正常] PlayerMoveSpeed同士の減算が行われた場合に、値が正常に格納されること
         */
        [Test]
        public void ValidPlayerMoveSpeedOperatorSub() {
            PlayerMoveSpeed PlayerMoveSpeed = PlayerMoveSpeed.Of(5);
            PlayerMoveSpeed subPlayerMoveSpeed = PlayerMoveSpeed.Of(1);
            int responsePlayerMoveSpeed = 4;

            Assert.That((PlayerMoveSpeed - subPlayerMoveSpeed).Value, Is.EqualTo(responsePlayerMoveSpeed));
        }

        /**
         * [正常] PlayerMoveSpeed同士の乗算が行われた場合に、値が正常に格納されること
         */
        [Test]
        public void ValidPlayerMoveSpeedOperatorMul() {
            PlayerMoveSpeed PlayerMoveSpeed = PlayerMoveSpeed.Of(2);
            PlayerMoveSpeed mulPlayerMoveSpeed = PlayerMoveSpeed.Of(2);
            int responsePlayerMoveSpeed = 4;

            Assert.That((PlayerMoveSpeed * mulPlayerMoveSpeed).Value, Is.EqualTo(responsePlayerMoveSpeed));
        }

        /**
         * [正常] PlayerMoveSpeed同士の除算が行われた場合に、値が正常に格納されること
         */
        [Test]
        public void ValidPlayerMoveSpeedOperatorDiv() {
            PlayerMoveSpeed PlayerMoveSpeed = PlayerMoveSpeed.Of(2);
            PlayerMoveSpeed div = PlayerMoveSpeed.Of(2);
            int responsePlayerMoveSpeed = 1;

            Assert.That((PlayerMoveSpeed / div).Value, Is.EqualTo(responsePlayerMoveSpeed));
        }

        /**
         * [異常] 渡された値が最小値未満か最大値より大きい場合に、スローが投げられること
         */
        [Test]
        public void ThrowWhenValueIsOverRange() {
            List<int> invalidNumberList = new List<int>() {
                int.MinValue,
                -1,
                11,
                int.MaxValue
            };

            foreach (int value in invalidNumberList) {
                void PlayerMoveSpeedMethod() {
                    PlayerMoveSpeed.Of(value);
                }

                Assert.Throws<ArgumentException>(
                    PlayerMoveSpeedMethod
                );
            }
        }

        /**
         * [異常] PlayerMoveSpeed同士の加算が行われ結果が異常である場合に、スローが投げられること
         */
        [Test]
        public void ThrowWhenAddPlayerMoveSpeed() {
            PlayerMoveSpeed PlayerMoveSpeed = PlayerMoveSpeed.Of(10);
            PlayerMoveSpeed addPlayerMoveSpeed = PlayerMoveSpeed.Of(1);

            void PlayerMoveSpeedMethod() {
                PlayerMoveSpeed newPlayerMoveSpeed = PlayerMoveSpeed + addPlayerMoveSpeed;
            }

            Assert.Throws<ArithmeticException>(
                PlayerMoveSpeedMethod
            );
        }

        /**
         * [異常] PlayerMoveSpeed同士の減算が行われ結果が異常である場合に、スローが投げられること
         */
        [Test]
        public void ThrowWhenSubPlayerMoveSpeed() {
            PlayerMoveSpeed PlayerMoveSpeed = PlayerMoveSpeed.Of(0);
            PlayerMoveSpeed addPlayerMoveSpeed = PlayerMoveSpeed.Of(1);

            void PlayerMoveSpeedMethod() {
                PlayerMoveSpeed newPlayerMoveSpeed = PlayerMoveSpeed - addPlayerMoveSpeed;
            }

            Assert.Throws<ArithmeticException>(
                PlayerMoveSpeedMethod
            );
        }

        /**
         * [異常] PlayerMoveSpeed同士の乗算が行われ結果が異常である場合に、スローが投げられること
         */
        [Test]
        public void ThrowWhenMulPlayerMoveSpeed() {
            PlayerMoveSpeed PlayerMoveSpeed = PlayerMoveSpeed.Of(10);
            PlayerMoveSpeed addPlayerMoveSpeed = PlayerMoveSpeed.Of(2);

            void PlayerMoveSpeedMethod() {
                PlayerMoveSpeed newPlayerMoveSpeed = PlayerMoveSpeed * addPlayerMoveSpeed;
            }

            Assert.Throws<ArithmeticException>(
                PlayerMoveSpeedMethod
            );
        }

        /**
         * [異常] PlayerMoveSpeed同士の除算において0で割っている場合に、スローが投げられること
         */
        [Test]
        public void ThrowWhenDivPlayerMoveSpeed() {
            PlayerMoveSpeed PlayerMoveSpeed = PlayerMoveSpeed.Of(1);
            PlayerMoveSpeed addPlayerMoveSpeed = PlayerMoveSpeed.Of(0);

            void PlayerMoveSpeedMethod() {
                PlayerMoveSpeed newPlayerMoveSpeed = PlayerMoveSpeed / addPlayerMoveSpeed;
            }

            Assert.Throws<DivideByZeroException>(
                PlayerMoveSpeedMethod
            );
        }

    }

}

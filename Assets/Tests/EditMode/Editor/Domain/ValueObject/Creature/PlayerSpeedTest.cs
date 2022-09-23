using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests {
    
    public class PlayerSpeedTest {

        /**
         * [正常] 渡された値が最小値以上最大値以下である場合に、値が正常に格納されること
         */
        [Test]
        public void ValidPlayerSpeed() {
            List<int> validNumberList = new List<int>() {
                0,
                5,
                10
            };

            foreach (int value in validNumberList) {
                PlayerSpeed playerSpeed = PlayerSpeed.Of(value);

                Assert.That(playerSpeed.Value, Is.EqualTo(value));
            }
        }

        /**
         * [正常] PlayerSpeed同士の加算が行われた場合に、値が正常に格納されること
         */
        [Test]
        public void ValidPlayerSpeedOperatorAdd() {

            PlayerSpeed playerSpeed = PlayerSpeed.Of(5);
            PlayerSpeed addPlayerSpeed = PlayerSpeed.Of(1);
            int responsePlayerSpeed = 6;

            Assert.That((playerSpeed + addPlayerSpeed).Value, Is.EqualTo(responsePlayerSpeed));
        }

        /**
         * [正常] PlayerSpeed同士の減算が行われた場合に、値が正常に格納されること
         */
        [Test]
        public void ValidPlayerSpeedOperatorSub() {
            PlayerSpeed playerSpeed = PlayerSpeed.Of(5);
            PlayerSpeed subPlayerSpeed = PlayerSpeed.Of(1);
            int responsePlayerSpeed = 4;

            Assert.That((playerSpeed - subPlayerSpeed).Value, Is.EqualTo(responsePlayerSpeed));
        }

        /**
         * [正常] PlayerSpeed同士の乗算が行われた場合に、値が正常に格納されること
         */
        [Test]
        public void ValidPlayerSpeedOperatorMul() {
            PlayerSpeed playerSpeed = PlayerSpeed.Of(2);
            PlayerSpeed mulPlayerSpeed = PlayerSpeed.Of(2);
            int responsePlayerSpeed = 4;

            Assert.That((playerSpeed * mulPlayerSpeed).Value, Is.EqualTo(responsePlayerSpeed));
        }

        /**
         * [正常] PlayerSpeed同士の除算が行われた場合に、値が正常に格納されること
         */
        [Test]
        public void ValidPlayerSpeedOperatorDiv() {
            PlayerSpeed playerSpeed = PlayerSpeed.Of(2);
            PlayerSpeed div = PlayerSpeed.Of(2);
            int responsePlayerSpeed = 1;

            Assert.That((playerSpeed / div).Value, Is.EqualTo(responsePlayerSpeed));
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
                void PlayerSpeedMethod() {
                    PlayerSpeed.Of(value);
                }

                Assert.Throws<ArgumentException>(
                    PlayerSpeedMethod
                );
            }
        }

        /**
         * [異常] PlayerSpeed同士の加算が行われ結果が異常である場合に、スローが投げられること
         */
        [Test]
        public void ThrowWhenAddPlayerSpeed() {
            PlayerSpeed playerSpeed = PlayerSpeed.Of(10);
            PlayerSpeed addPlayerSpeed = PlayerSpeed.Of(1);

            void PlayerSpeedMethod() {
                PlayerSpeed newPlayerSpeed = playerSpeed + addPlayerSpeed;
            }

            Assert.Throws<ArithmeticException>(
                PlayerSpeedMethod
            );
        }

        /**
         * [異常] PlayerSpeed同士の減算が行われ結果が異常である場合に、スローが投げられること
         */
        [Test]
        public void ThrowWhenSubPlayerSpeed() {
            PlayerSpeed playerSpeed = PlayerSpeed.Of(0);
            PlayerSpeed addPlayerSpeed = PlayerSpeed.Of(1);

            void PlayerSpeedMethod() {
                PlayerSpeed newPlayerSpeed = playerSpeed - addPlayerSpeed;
            }

            Assert.Throws<ArithmeticException>(
                PlayerSpeedMethod
            );
        }

        /**
         * [異常] PlayerSpeed同士の乗算が行われ結果が異常である場合に、スローが投げられること
         */
        [Test]
        public void ThrowWhenMulPlayerSpeed() {
            PlayerSpeed playerSpeed = PlayerSpeed.Of(10);
            PlayerSpeed addPlayerSpeed = PlayerSpeed.Of(2);

            void PlayerSpeedMethod() {
                PlayerSpeed newPlayerSpeed = playerSpeed * addPlayerSpeed;
            }

            Assert.Throws<ArithmeticException>(
                PlayerSpeedMethod
            );
        }

        /**
         * [異常] PlayerSpeed同士の除算において0で割っている場合に、スローが投げられること
         */
        [Test]
        public void ThrowWhenDivPlayerSpeed() {
            PlayerSpeed playerSpeed = PlayerSpeed.Of(1);
            PlayerSpeed addPlayerSpeed = PlayerSpeed.Of(0);

            void PlayerSpeedMethod() {
                PlayerSpeed newPlayerSpeed = playerSpeed / addPlayerSpeed;
            }

            Assert.Throws<DivideByZeroException>(
                PlayerSpeedMethod
            );
        }

    }

}

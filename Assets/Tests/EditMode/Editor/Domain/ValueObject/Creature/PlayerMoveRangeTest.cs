using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests {

    public class PlayerMoveRangeTest {

        /**
         * 低い値が高い値以下で、低い値が最小値以上、高い値が最大値以下である場合に、値が正常に格納されること
         */
        [Test]
        public void ValidPlayerMoveRange() {
            Dictionary<float, float> validNumberDict = new Dictionary<float, float>() {
                {-100f,  -99f},
                {   0f,    1f},
                {  99f,  100f},
                { 100f,  100f}
            };

            foreach (KeyValuePair<float, float> value in validNumberDict) {
                PlayerMoveRange playerMoveRange = PlayerMoveRange.Of(value.Key, value.Value);

                Assert.That(playerMoveRange.LowValue, Is.EqualTo(value.Key));
                Assert.That(playerMoveRange.HighValue, Is.EqualTo(value.Value));
            }
        }

        /**
         * [正常] PlayerMoveRange同士の加算が行われた場合に、値が正常に格納されること
         */
        [Test]
        public void ValidPlayerMoveSpeedOperatorAdd() {
            PlayerMoveRange playerMoveRange = PlayerMoveRange.Of(0f, 10f);
            PlayerMoveRange addPlayerMoveRange = PlayerMoveRange.Of(1f, 1f);

            float responseLowValue = 1f;
            float responseHighValue = 11f;

            PlayerMoveRange response = playerMoveRange + addPlayerMoveRange;
            Assert.That(response.LowValue, Is.EqualTo(responseLowValue));
            Assert.That(response.HighValue, Is.EqualTo(responseHighValue));
        }

        /**
         * [正常] PlayerMoveRange同士の減算が行われた場合に、値が正常に格納されること
         */
        [Test]
        public void ValidPlayerMoveSpeedOperatorSub() {
            PlayerMoveRange playerMoveRange = PlayerMoveRange.Of(0f, 10f);
            PlayerMoveRange subPlayerMoveRange = PlayerMoveRange.Of(1f, 1f);

            float responseLowValue = -1f;
            float responseHighValue = 9f;

            PlayerMoveRange response = playerMoveRange - subPlayerMoveRange;
            Assert.That(response.LowValue, Is.EqualTo(responseLowValue));
            Assert.That(response.HighValue, Is.EqualTo(responseHighValue));
        }

        /**
         * [正常] PlayerMoveRange同士の乗算が行われた場合に、値が正常に格納されること
         */
        [Test]
        public void ValidPlayerMoveSpeedOperatorMul() {
            PlayerMoveRange playerMoveRange = PlayerMoveRange.Of(2f, 10f);
            PlayerMoveRange mulPlayerMoveRange = PlayerMoveRange.Of(2f, 5f);

            float responseLowValue = 4f;
            float responseHighValue = 50f;

            PlayerMoveRange response = playerMoveRange * mulPlayerMoveRange;
            Assert.That(response.LowValue, Is.EqualTo(responseLowValue));
            Assert.That(response.HighValue, Is.EqualTo(responseHighValue));
        }

        /**
         * [正常] PlayerMoveRange同士の除算が行われた場合に、値が正常に格納されること
         */
        [Test]
        public void ValidPlayerMoveSpeedOperatorDiv() {
            PlayerMoveRange playerMoveRange = PlayerMoveRange.Of(4f, 10f);
            PlayerMoveRange divPlayerMoveRange = PlayerMoveRange.Of(2f, 4f);

            float responseLowValue = 2f;
            float responseHighValue = 2.5f;

            PlayerMoveRange response = playerMoveRange / divPlayerMoveRange;
            Assert.That(response.LowValue, Is.EqualTo(responseLowValue));
            Assert.That(response.HighValue, Is.EqualTo(responseHighValue));
        }

        /**
         * [異常] 低い値が最小値より小さいか、高い値が最大値より大きい場合に、スローを投げること
         */
        [Test]
        public void ThrowWhenValueIsOverRange() {
            Dictionary<float, float> invalidNumberDict = new Dictionary<float, float>() {
                {-102f, -101f},
                { 101f,  102f},
                {float.MinValue, float.MaxValue}
            };

            foreach (KeyValuePair<float, float> value in invalidNumberDict) {
                void PlayerMoveRangeMethod() {
                    PlayerMoveRange playerMoveRange = PlayerMoveRange.Of(value.Key, value.Value);
                }

                Assert.Throws<ArgumentException>(
                    PlayerMoveRangeMethod
                );
            }
        }

        /**
         * [異常] 低い値が高い値より大きい場合に、スローを投げること
         */
        [Test]
        public void ThrowWhenLowValueGiggerThanHighValue() {
            float lowValue = 50f;
            float highValue = 40f;

            void PlayerMoveRangeMethod() {
                PlayerMoveRange playerMoveRange = PlayerMoveRange.Of(lowValue, highValue);
            }

            Assert.Throws<ArgumentException>(
                PlayerMoveRangeMethod
            );
        }

        /**
         * [異常] PlayerMoveRange同士の加算が行われ結果が異常である場合に、スローが投げられること
         */
        [Test]
        public void ThrowWhenAddPlayerMoveRange() {
            PlayerMoveRange playerMoveRange = PlayerMoveRange.Of(100f, 100f);
            PlayerMoveRange addPlayerMoveRange = PlayerMoveRange.Of(1f, 1f);

            void PlayerMoveRangeMethod() {
                PlayerMoveRange newPlayerMoveRange = playerMoveRange + addPlayerMoveRange;
            }

            Assert.Throws<ArithmeticException>(
                PlayerMoveRangeMethod
            );
        }

        /**
         * [異常] PlayerMoveRange同士の減算が行われ結果が異常である場合に、スローが投げられること
         */
        [Test]
        public void ThrowWhenSubPlayerMoveRange() {
            PlayerMoveRange playerMoveRange = PlayerMoveRange.Of(-100f, -100f);
            PlayerMoveRange addPlayerMoveRange = PlayerMoveRange.Of(1f, 1f);

            void PlayerMoveRangeMethod() {
                PlayerMoveRange newPlayerMoveRange = playerMoveRange - addPlayerMoveRange;
            }

            Assert.Throws<ArithmeticException>(
                PlayerMoveRangeMethod
            );
        }

        /**
         * [異常] PlayerMoveRange同士の乗算が行われ結果が異常である場合に、スローが投げられること
         */
        [Test]
        public void ThrowWhenMulPlayerMoveRange() {
            PlayerMoveRange playerMoveRange = PlayerMoveRange.Of(100f, 100f);
            PlayerMoveRange addPlayerMoveRange = PlayerMoveRange.Of(2f, 2f);

            void PlayerMoveRangeMethod() {
                PlayerMoveRange newPlayerMoveRange = playerMoveRange * addPlayerMoveRange;
            }

            Assert.Throws<ArithmeticException>(
                PlayerMoveRangeMethod
            );
        }

        /**
         * [異常] PlayerMoveRange同士の除算が行われ結果が異常である場合に、スローが投げられること
         */
        [Test]
        public void ThrowWhenDivPlayerMoveRange() {
            PlayerMoveRange playerMoveRange = PlayerMoveRange.Of(100f, 100f);

            PlayerMoveRange addPlayerMoveRange = PlayerMoveRange.Of(0f, 1f);

            void PlayerMoveRangeMethod() {
                PlayerMoveRange newPlayerMoveRange = playerMoveRange / addPlayerMoveRange;
            }

            Assert.Throws<DivideByZeroException>(
                PlayerMoveRangeMethod
            );
        }

    }

}
using System;
using Systemk.Exceptions;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests {

    [Description("プレイヤーの動ける範囲のテスト")]
    public class PlayerMoveRangeTest {

        [Test]
        [Description("低い値が高い値以下かつ低い値と高い値が範囲内である場合に、値が正常に格納されること")]
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

        [Test]
        [Description("[正常] PlayerMoveRange同士の加算が行われた場合に、値が正常に格納されること")]
        public void ValidPlayerMoveSpeedOperatorAdd() {
            PlayerMoveRange playerMoveRange = PlayerMoveRange.Of(0f, 10f);
            PlayerMoveRange addPlayerMoveRange = PlayerMoveRange.Of(1f, 1f);

            float responseLowValue = 1f;
            float responseHighValue = 11f;

            PlayerMoveRange response = playerMoveRange + addPlayerMoveRange;
            Assert.That(response.LowValue, Is.EqualTo(responseLowValue));
            Assert.That(response.HighValue, Is.EqualTo(responseHighValue));
        }

        [Test]
        [Description("[正常] PlayerMoveRange同士の減算が行われた場合に、値が正常に格納されること")]
        public void ValidPlayerMoveSpeedOperatorSub() {
            PlayerMoveRange playerMoveRange = PlayerMoveRange.Of(0f, 10f);
            PlayerMoveRange subPlayerMoveRange = PlayerMoveRange.Of(1f, 1f);

            float responseLowValue = -1f;
            float responseHighValue = 9f;

            PlayerMoveRange response = playerMoveRange - subPlayerMoveRange;
            Assert.That(response.LowValue, Is.EqualTo(responseLowValue));
            Assert.That(response.HighValue, Is.EqualTo(responseHighValue));
        }

        [Test]
        [Description("[正常] PlayerMoveRange同士の乗算が行われた場合に、値が正常に格納されること")]
        public void ValidPlayerMoveSpeedOperatorMul() {
            PlayerMoveRange playerMoveRange = PlayerMoveRange.Of(2f, 10f);
            PlayerMoveRange mulPlayerMoveRange = PlayerMoveRange.Of(2f, 5f);

            float responseLowValue = 4f;
            float responseHighValue = 50f;

            PlayerMoveRange response = playerMoveRange * mulPlayerMoveRange;
            Assert.That(response.LowValue, Is.EqualTo(responseLowValue));
            Assert.That(response.HighValue, Is.EqualTo(responseHighValue));
        }

        [Test]
        [Description("[正常] PlayerMoveRange同士の除算が行われた場合に、値が正常に格納されること")]
        public void ValidPlayerMoveSpeedOperatorDiv() {
            PlayerMoveRange playerMoveRange = PlayerMoveRange.Of(4f, 10f);
            PlayerMoveRange divPlayerMoveRange = PlayerMoveRange.Of(2f, 4f);

            float responseLowValue = 2f;
            float responseHighValue = 2.5f;

            PlayerMoveRange response = playerMoveRange / divPlayerMoveRange;
            Assert.That(response.LowValue, Is.EqualTo(responseLowValue));
            Assert.That(response.HighValue, Is.EqualTo(responseHighValue));
        }

        [Test]
        [Description("[異常] 低い値と高い値が範囲外である場合に、スローを投げること")]
        public void ThrowWhenValueIsOverRange() {
            Dictionary<float, float> invalidNumberDict = new Dictionary<float, float>() {
                {-102f, -101f},
                {101f, 102f},
                {float.MinValue, float.MaxValue}
            };

            foreach (KeyValuePair<float, float> value in invalidNumberDict) {
                var exception = Assert.Throws<ArgumentException>(() => {
                    PlayerMoveRange playerMoveRange = PlayerMoveRange.Of(value.Key, value.Value);
                });

                Assert.That(
                    exception.Message,
                    Is.EqualTo(ExceptionMessage.argumentExceptionMessage)
                );
            }
        }

        [Test]
        [Description("[異常] 低い値が高い値より大きい場合に、スローを投げること")]
        public void ThrowWhenLowValueGiggerThanHighValue() {
            var exception = Assert.Throws<ArgumentException>(() => {
                float lowValue = 50f;
                float highValue = 40f;

                PlayerMoveRange playerMoveRange = PlayerMoveRange.Of(lowValue, highValue);
            });

            Assert.That(
                exception.Message,
                Is.EqualTo(ExceptionMessage.argumentExceptionMessage)
            );
        }

        [Test]
        [Description("[正常] 加算した値が最大値より大きい場合に、最大値が格納されていること")]
        public void LimitAddPlayerMoveRange() {
            PlayerMoveRange playerMoveRange = PlayerMoveRange.Of(100f, 100f);
            List<PlayerMoveRange> addPlayerMoveRangeList = new List<PlayerMoveRange>() {
                PlayerMoveRange.Of(0f, 1f),
                PlayerMoveRange.Of(2f, 2f)
            };
            float responseLowValue = 100f;
            float responseHighValue = 100f;

            foreach (PlayerMoveRange addPlayerMoveRange in addPlayerMoveRangeList) {
                PlayerMoveRange newPlayerMoveRange = playerMoveRange + addPlayerMoveRange;
                Assert.That(newPlayerMoveRange.LowValue, Is.EqualTo(responseLowValue));
                Assert.That(newPlayerMoveRange.HighValue, Is.EqualTo(responseHighValue));
            }
        }

        [Test]
        [Description("[正常] 減算した値が最小値より小さい場合に、最小値が格納されていること")]
        public void LimitSubPlayerMOveRange() {
            PlayerMoveRange playerMoveRange = PlayerMoveRange.Of(-100f, -100f);
            List<PlayerMoveRange> subPlayerMoveRangeList = new List<PlayerMoveRange>() {
                PlayerMoveRange.Of(0f, 1f),
                PlayerMoveRange.Of(2f, 2f)
            };
            float responseLowValue = -100f;
            float responseHighValue = -100f;

            foreach (PlayerMoveRange subPlayerMoveRange in subPlayerMoveRangeList) {
                PlayerMoveRange newPlayerMoveRange = playerMoveRange - subPlayerMoveRange;
                Assert.That(newPlayerMoveRange.LowValue, Is.EqualTo(responseLowValue));
                Assert.That(newPlayerMoveRange.HighValue, Is.EqualTo(responseHighValue));
            }
        }

        [Test]
        [Description("[正常] 乗算した値が最大値より大きい場合に、最大値が格納されていること")]
        public void LimitMulPlayerMOveRange() {
            PlayerMoveRange playerMoveRange = PlayerMoveRange.Of(100f, 100f);
            List<PlayerMoveRange> mulPlayerMoveRangeList = new List<PlayerMoveRange>() {
                PlayerMoveRange.Of(1f, 1.5f),
                PlayerMoveRange.Of(2f, 2f)
            };
            float responseLowValue = 100f;
            float responseHighValue = 100f;

            foreach (PlayerMoveRange mulPlayerMoveRange in mulPlayerMoveRangeList) {
                PlayerMoveRange newPlayerMoveRange = playerMoveRange * mulPlayerMoveRange;
                Assert.That(newPlayerMoveRange.LowValue, Is.EqualTo(responseLowValue));
                Assert.That(newPlayerMoveRange.HighValue, Is.EqualTo(responseHighValue));
            }
        }

        [Test]
        [Description("[異常] 除算において0で割っている場合に、スローが投げられること")]
        public void ThrowWhenDivPlayerMoveRange() {
            var exception = Assert.Throws<DivideByZeroException>(() => {
                PlayerMoveRange playerMoveRange = PlayerMoveRange.Of(100f, 100f);
                PlayerMoveRange addPlayerMoveRange = PlayerMoveRange.Of(0f, 1f);
                PlayerMoveRange newPlayerMoveRange = playerMoveRange / addPlayerMoveRange;
            });

            Assert.That(
                exception.Message,
                Is.EqualTo(ExceptionMessage.divideByZeroExceptionMessage)
            );
        }

    }

}
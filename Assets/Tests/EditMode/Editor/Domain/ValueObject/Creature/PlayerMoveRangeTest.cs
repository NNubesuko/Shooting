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
        [TestCase(-100f, -99f)]
        [TestCase(0f, 1f)]
        [TestCase(99f, 100f)]
        [TestCase(100f, 100f)]
        [Description(
            "[正常] 低い値が高い値以下かつ低い値と高い値が範囲内である場合に、値が正常に格納されること"
        )]
        public void ValidPlayerMoveRange(float lowValue, float highValue) {
            PlayerMoveRange playerMoveRange = PlayerMoveRange.Of(lowValue, highValue);
            Assert.That(playerMoveRange.LowValue, Is.EqualTo(lowValue));
            Assert.That(playerMoveRange.HighValue, Is.EqualTo(highValue));
        }

        [Test]
        [TestCase(0f, 10f, 1f, 1f)]
        [Description("[正常] PlayerMoveRange同士の加算が行われた場合に、値が正常に格納されること")]
        public void ValidPlayerMoveSpeedOperatorAdd(
            float lowValue, float highValue, float addLowValue, float addHighValue
        ) {
            float responseLowValue = 1f;
            float responseHighValue = 11f;
            PlayerMoveRange playerMoveRange =
            PlayerMoveRange.Of(lowValue, highValue) + PlayerMoveRange.Of(addLowValue, addHighValue);

            Assert.That(playerMoveRange.LowValue, Is.EqualTo(responseLowValue));
            Assert.That(playerMoveRange.HighValue, Is.EqualTo(responseHighValue));
        }

        [Test]
        [TestCase(0f, 10f, 1f, 1f)]
        [Description("[正常] PlayerMoveRange同士の減算が行われた場合に、値が正常に格納されること")]
        public void ValidPlayerMoveSpeedOperatorSub(
            float lowValue, float highValue, float subLowValue, float subHighValue
        ) {
            float responseLowValue = -1f;
            float responseHighValue = 9f;
            PlayerMoveRange playerMoveRange =
            PlayerMoveRange.Of(lowValue, highValue) - PlayerMoveRange.Of(subLowValue, subHighValue);

            Assert.That(playerMoveRange.LowValue, Is.EqualTo(responseLowValue));
            Assert.That(playerMoveRange.HighValue, Is.EqualTo(responseHighValue));
        }

        [Test]
        [TestCase(2f, 10f, 2f, 5f)]
        [Description("[正常] PlayerMoveRange同士の乗算が行われた場合に、値が正常に格納されること")]
        public void ValidPlayerMoveSpeedOperatorMul(
            float lowValue, float highValue, float mulLowValue, float mulHighValue
        ) {
            float responseLowValue = 4f;
            float responseHighValue = 50f;
            PlayerMoveRange playerMoveRange =
            PlayerMoveRange.Of(lowValue, highValue) * PlayerMoveRange.Of(mulLowValue, mulHighValue);

            Assert.That(playerMoveRange.LowValue, Is.EqualTo(responseLowValue));
            Assert.That(playerMoveRange.HighValue, Is.EqualTo(responseHighValue));
        }

        [Test]
        [TestCase(4f, 10f, 2f, 4f)]
        [Description("[正常] PlayerMoveRange同士の除算が行われた場合に、値が正常に格納されること")]
        public void ValidPlayerMoveSpeedOperatorDiv(
            float lowValue, float highValue, float divLowValue, float divHighValue
        ) {
            float responseLowValue = 2f;
            float responseHighValue = 2.5f;
            PlayerMoveRange playerMoveRange =
            PlayerMoveRange.Of(lowValue, highValue) / PlayerMoveRange.Of(divLowValue, divHighValue);

            Assert.That(playerMoveRange.LowValue, Is.EqualTo(responseLowValue));
            Assert.That(playerMoveRange.HighValue, Is.EqualTo(responseHighValue));
        }

        [Test]
        [TestCase(100f, 100f, 0f, 1f)]
        [TestCase(100f, 100f, 2f, 2f)]
        [Description("[正常] 加算した値が最大値より大きい場合に、最大値が格納されていること")]
        public void LimitAddPlayerMoveRange(
            float lowValue, float highValue, float addLowValue, float addHighValue
        ) {
            float responseLowValue = 100f;
            float responseHighValue = 100f;
            PlayerMoveRange playerMoveRange =
            PlayerMoveRange.Of(lowValue, highValue) + PlayerMoveRange.Of(addLowValue, addHighValue);

            Assert.That(playerMoveRange.LowValue, Is.EqualTo(responseLowValue));
            Assert.That(playerMoveRange.HighValue, Is.EqualTo(responseHighValue));
        }

        [Test]
        [TestCase(-100f, -100f, 0f, 1f)]
        [TestCase(-100f, -100f, 2f, 2f)]
        [Description("[正常] 減算した値が最小値より小さい場合に、最小値が格納されていること")]
        public void LimitSubPlayerMOveRange(
            float lowValue, float highValue, float subLowValue, float subHighValue
        ) {
            float responseLowValue = -100f;
            float responseHighValue = -100f;
            PlayerMoveRange playerMoveRange =
            PlayerMoveRange.Of(lowValue, highValue) - PlayerMoveRange.Of(subLowValue, subHighValue);

            Assert.That(playerMoveRange.LowValue, Is.EqualTo(responseLowValue));
            Assert.That(playerMoveRange.HighValue, Is.EqualTo(responseHighValue));
        }

        [Test]
        [TestCase(100f, 100f, 1f, 1.5f)]
        [TestCase(100f, 100f, 2f, 2f)]
        [Description("[正常] 乗算した値が最大値より大きい場合に、最大値が格納されていること")]
        public void LimitMulPlayerMOveRange(
            float lowValue, float highValue, float mulLowValue, float mulHighValue
        ) {
            float responseLowValue = 100f;
            float responseHighValue = 100f;
            PlayerMoveRange playerMoveRange =
            PlayerMoveRange.Of(lowValue, highValue) * PlayerMoveRange.Of(mulLowValue, mulHighValue);

            Assert.That(playerMoveRange.LowValue, Is.EqualTo(responseLowValue));
            Assert.That(playerMoveRange.HighValue, Is.EqualTo(responseHighValue));
        }

        [Test]
        [TestCase(-102f, -101f)]
        [TestCase(101f, 102f)]
        [TestCase(float.MinValue, float.MaxValue)]
        [Description("[異常] 低い値と高い値が範囲外である場合に、スローを投げること")]
        public void ThrowWhenValueIsOverRange(float lowValue, float highValue) {
            var exception = Assert.Throws<ArgumentException>(() => {
                PlayerMoveRange playerMoveRange = PlayerMoveRange.Of(lowValue, highValue);
            });

            Assert.That(
                exception.Message,
                Is.EqualTo(ExceptionMessage.argumentExceptionMessage)
            );
        }

        
        [Test]
        [TestCase(-99f, -100f)]
        [TestCase(1f, 0f)]
        [TestCase(100f, 99f)]
        [Description("[異常] 低い値が高い値より大きい場合に、スローを投げること")]
        public void ThrowWhenLowValueGiggerThanHighValue(float lowValue, float highValue) {
            var exception = Assert.Throws<ArgumentException>(() => {
                PlayerMoveRange playerMoveRange = PlayerMoveRange.Of(lowValue, highValue);
            });

            Assert.That(
                exception.Message,
                Is.EqualTo(ExceptionMessage.argumentExceptionMessage)
            );
        }

        [Test]
        [TestCase(100f, 100f, 0f, 1f)]
        [TestCase(100f, 100f, 0f, 0f)]
        [Description("[異常] 除算において0で割っている場合に、スローが投げられること")]
        public void ThrowWhenDivPlayerMoveRange(
            float lowValue, float highValue, float divLowValue, float divHighValue
        ) {
            var exception = Assert.Throws<DivideByZeroException>(() => {
                PlayerMoveRange playerMoveRange =
                    PlayerMoveRange.Of(lowValue, highValue) /
                    PlayerMoveRange.Of(divLowValue, divHighValue);
            });
            
            Assert.That(
                exception.Message,
                Is.EqualTo(ExceptionMessage.divideByZeroExceptionMessage)
            );
        }

    }

}
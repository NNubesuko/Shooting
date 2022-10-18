using System;
using Systemk.Exceptions;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests {

    [Description("プレイヤーの体力のテスト")]
    public class PlayerHPTest {

        [Test]
        [TestCase(0)]
        [TestCase(50)]
        [TestCase(100)]
        [Description("[正常] 渡された値が最小値以上最大値以下である場合に、値が正常に格納されること")]
        public void ValidPlayerHP(int value) {
            PlayerHP playerHP = PlayerHP.Of(value);
            Assert.That(playerHP.Value, Is.EqualTo(value));
        }

        [Test]
        [TestCase(10, 2)]
        [Description("[正常] PlayerHP同士の加算が行われた場合に、値が正常に格納されること")]
        public void ValidPlayerHPOperatorAdd(int value, int addValue) {
            int responsePlayerHP = 12;

            PlayerHP playerHP = PlayerHP.Of(value) + PlayerHP.Of(addValue);
            Assert.That(playerHP.Value, Is.EqualTo(responsePlayerHP));
        }

        [Test]
        [TestCase(10, 2)]
        [Description("[正常] PlayerHP同士の減算が行われた場合に、値が正常に格納されること")]
        public void ValidPlayerHPOperatorSub(int value, int subValue) {
            int responsePlayerHP = 8;

            PlayerHP playerHP = PlayerHP.Of(value) - PlayerHP.Of(subValue);
            Assert.That(playerHP.Value, Is.EqualTo(responsePlayerHP));
        }

        [Test]
        [TestCase(10, 2)]
        [Description("[正常] PlayerHP同士の乗算が行われた場合に、値が正常に格納されること")]
        public void ValidPlayerHPOperatorMul(int value, int mulValue) {
            int responsePlayerHP = 20;

            PlayerHP playerHP = PlayerHP.Of(value) * PlayerHP.Of(mulValue);
            Assert.That(playerHP.Value, Is.EqualTo(responsePlayerHP));
        }

        [Test]
        [TestCase(10, 2)]
        [Description("[正常] PlayerHP同士の除算が行われた場合に、値が正常に格納されること")]
        public void ValidPlayerHPOperatorDiv(int value, int divValue) {
            int responsePlayerHP = 5;

            PlayerHP playerHP = PlayerHP.Of(value) / PlayerHP.Of(divValue);
            Assert.That(playerHP.Value, Is.EqualTo(responsePlayerHP));
        }

        [Test]
        [TestCase(100, 10)]
        [Description("[正常] 加算した値が最大値より大きい場合に、最大値が格納されていること")]
        public void LimitAddPlayerHP(int value, int addValue) {
            int responsePlayerHP = 100;

            PlayerHP playerHP = PlayerHP.Of(value) + PlayerHP.Of(addValue);
            Assert.That(playerHP.Value, Is.EqualTo(responsePlayerHP));
        }

        [Test]
        [TestCase(0, 1)]
        [Description("[正常] 減算した値が最小値より小さい場合に、最小値が格納されていること")]
        public void LimitSubPlayerHP(int value, int subValue) {
            int responsePlayerHP = 0;

            PlayerHP playerHP = PlayerHP.Of(value) - PlayerHP.Of(subValue);
            Assert.That(playerHP.Value, Is.EqualTo(responsePlayerHP));
        }

        [Test]
        [TestCase(100, 2)]
        [Description("[正常] 乗算した値が最大値より大きい場合に、最大値が格納されていること")]
        public void LimitMulPlayerHP(int value, int mulValue) {
            int responsePlayerHP = 100;

            PlayerHP playerHP = PlayerHP.Of(value) * PlayerHP.Of(mulValue);
            Assert.That(playerHP.Value, Is.EqualTo(responsePlayerHP));
        }

        [Test]
        [TestCase(int.MinValue)]
        [TestCase(-1)]
        [TestCase(101)]
        [TestCase(int.MaxValue)]
        [Description("[異常] 渡された値が最小値未満か最大値より大きい場合に、スローが投げられること")]
        public void ThrowWhenValueIsOverRange(int value) {
            var exception = Assert.Throws<ArgumentException>(() => {
                PlayerHP playerHP = PlayerHP.Of(value);
            });

            Assert.That(
                exception.Message,
                Is.EqualTo(ExceptionMessage.argumentExceptionMessage)
            );
        }

        [Test]
        [TestCase(1, 0)]
        [Description("[異常] 除算において0で割っている場合に、スローが投げられること")]
        public void ThrowWhenDivPlayerHP(int value, int divValue) {
            var exception = Assert.Throws<DivideByZeroException>(() => {
                PlayerHP playerHP = PlayerHP.Of(value) / PlayerHP.Of(divValue);
            });

            Assert.That(
                exception.Message,
                Is.EqualTo(ExceptionMessage.divideByZeroExceptionMessage)
            );
        }

    }

}

using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using KataokaLib.ValueObject;

namespace Tests {

    [Description("プレイヤーの体力のテスト")]
    public class PlayerHPTest {

        [Test]
        [TestCase(0)]
        [TestCase(50)]
        [TestCase(100)]
        [Description("[正常] 渡された値が最小値以上かつ最大値以下である場合に、正常に格納されること")]
        public void ValidPlayerHP(int value) {
            PlayerHP playerHP = PlayerHP.Of(value);
            Assert.That(playerHP, Is.EqualTo(PlayerHP.Of(value)));
        }

        [Test]
        [TestCase(int.MinValue)]
        [TestCase(-1)]
        [TestCase(101)]
        [TestCase(int.MaxValue)]
        [Description("[異常] 渡された値が最小値未満または最大値より大きい場合に、スローが投げられること")]
        public void InvalidPlayerHP(int value) {
            var exception = Assert.Throws<ArgumentException>(() => {
                PlayerHP playerHP = PlayerHP.Of(value);
            });

            Assert.That(
                exception.Message,
                Is.EqualTo(ValueObjectExceptionHandler.ArgumentException(nameof(value)).Message)
            );
        }

    }

}
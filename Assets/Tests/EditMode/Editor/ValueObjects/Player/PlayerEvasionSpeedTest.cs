using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using KataokaLib.ValueObject;

namespace Tests {

    [Description("プレイヤーの回避速度のテスト")]
    public class PlayerEvasionSpeedTest {

        [Test]
        [TestCase(0f)]
        [TestCase(50f)]
        [TestCase(100f)]
        [Description("[正常] 渡された値が最小値以上かつ最大値以下である場合に、正常に格納されること")]
        public void ValidPlayerEvasionSpeed(float value) {
            PlayerEvasionSpeed playerEvasionSpeed = PlayerEvasionSpeed.Of(value);
            Assert.That(playerEvasionSpeed, Is.EqualTo(PlayerEvasionSpeed.Of(value)));
        }

        [Test]
        [TestCase(float.MinValue)]
        [TestCase(-1f)]
        [TestCase(101f)]
        [TestCase(float.MaxValue)]
        [Description("[異常] 渡された値が最小値未満または最大値より大きい場合に、スローが投げられること")]
        public void InvalidPlayerEvasionSpeed(float value) {
            var exception = Assert.Throws<ArgumentException>(() => {
                PlayerEvasionSpeed playerEvasionSpeed = PlayerEvasionSpeed.Of(value);
            });

            Assert.That(
                exception.Message,
                Is.EqualTo(
                    ValueObjectExceptionHandler.ArgumentException(nameof(value)).Message
                )
            );
        }
        
    }

}

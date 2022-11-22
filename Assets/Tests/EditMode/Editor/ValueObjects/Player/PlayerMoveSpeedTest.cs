using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using KataokaLib.ValueObject;

namespace Tests {

    [Description("プレイヤーの移動速度のテスト")]
    public class PlayerMoveSpeedTest {

        [Test]
        [TestCase(0)]
        [TestCase(5)]
        [TestCase(10)]
        [Description("[正常] 渡された値が最小値以上かつ最大値以下である場合に、正常に格納されること")]
        public void ValidPlayerMoveSpeed(int value) {
            PlayerMoveSpeed playerMoveSpeed = PlayerMoveSpeed.Of(value);
            Assert.That(playerMoveSpeed, Is.EqualTo(PlayerMoveSpeed.Of(value)));
        }

        [Test]
        [TestCase(int.MinValue)]
        [TestCase(-1)]
        [TestCase(11)]
        [TestCase(int.MaxValue)]
        public void InvalidPlaeyrMoveSpeed(int value) {
            var exception = Assert.Throws<ArgumentException>(() => {
                PlayerMoveSpeed playerMoveSpeed = PlayerMoveSpeed.Of(value);
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

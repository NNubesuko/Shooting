using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using KataokaLib.ValueObject;

namespace Tests {

    [Description("弾丸の攻撃力のテスト")]
    public class BulletMoveSpeedTest {

        [Test]
        [TestCase(0f)]
        [TestCase(50f)]
        [TestCase(100f)]
        [Description("[正常] 渡された値が最小値以上かつ最大値以下である場合に、正常に格納されること")]
        public void ValidBulletMoveSpeed(float value) {
            BulletMoveSpeed bulletMoveSpeed = BulletMoveSpeed.Of(value);
            Assert.That(bulletMoveSpeed, Is.EqualTo(BulletMoveSpeed.Of(value)));
        }

        [Test]
        [TestCase(float.MinValue)]
        [TestCase(-1f)]
        [TestCase(101f)]
        [TestCase(float.MaxValue)]
        [Description("[異常] 渡された値が最小値未満または最大値より大きい場合に、スローが投げられること")]
        public void InvalidBulletMoveSpeed(float value) {
            var exception = Assert.Throws<ArgumentException>(() => {
                BulletMoveSpeed bulletMoveSpeed = BulletMoveSpeed.Of(value);
            });

            Assert.That(
                exception.Message,
                Is.EqualTo(
                    ValueObjectExceptionHandler.ArgumentException(nameof(value)).Message
                )
            );
        }

        [Test]
        [TestCase(0f)]
        [TestCase(10f)]
        [TestCase(50f)]
        [Description("[正常] フレーム秒と乗算した場合に、float型の実数が格納されること")]
        public void BulletMoveSpeedMulDeltaTime(float value) {
            BulletMoveSpeed bulletMoveSpeed = BulletMoveSpeed.Of(value);
            float bulletMoveSpeedMulDeltaTime = bulletMoveSpeed * Time.deltaTime;

            Assert.That(
                bulletMoveSpeedMulDeltaTime,
                Is.EqualTo(value * Time.deltaTime)
            );
        }

    }

}

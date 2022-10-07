using System;
using Systemk.Exceptions;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests {

    [Description("弾丸速度のテスト")]
    public class BulletSpeedTest {

        [Test]
        [TestCase(0)]
        [TestCase(5)]
        [TestCase(100)]
        [Description("[正常] 渡された値が最小値以上最大値以下である場合に、値が正常に格納されること")]
        public void ValidBulletSpeed(int value) {
            BulletSpeed bulletSpeed = BulletSpeed.Of(value);
            Assert.That(bulletSpeed.Value, Is.EqualTo(value));
        }

        [Test]
        [TestCase(10, 2)]
        [Description("[正常] 加算が行われた場合に、値が正常に格納されること")]
        public void ValidOperatorAddForBulletSpeed(int speed, int addSpeed) {
            int responseBulletSpeed = 12;

            BulletSpeed bulletSpeed = BulletSpeed.Of(speed) + BulletSpeed.Of(addSpeed);
            Assert.That(bulletSpeed.Value, Is.EqualTo(responseBulletSpeed));
        }

        [Test]
        [TestCase(10, 2)]
        [Description("[正常] 減算が行われた場合に、値が正常に格納されること")]
        public void ValidOperatorSubForBulletSpeed(int speed, int subSpeed) {
            int responseBulletSpeed = 8;

            BulletSpeed bulletSpeed = BulletSpeed.Of(speed) - BulletSpeed.Of(subSpeed);
            Assert.That(bulletSpeed.Value, Is.EqualTo(responseBulletSpeed));
        }

        [Test]
        [TestCase(10, 2)]
        [Description("[正常] 乗算が行われた場合に、値が正常に格納されること")]
        public void ValidOperatorMulForBulletSpeed(int speed, int mulSpeed) {
            int responseBulletSpeed = 20;

            BulletSpeed bulletSpeed = BulletSpeed.Of(speed) * BulletSpeed.Of(mulSpeed);
            Assert.That(bulletSpeed.Value, Is.EqualTo(responseBulletSpeed));
        }

        [Test]
        [TestCase(10, 2)]
        [Description("[正常] 除算が行われた場合に、値が正常に格納されること")]
        public void ValidOperatorDivForBulletSpeed(int speed, int divSpeed) {
            int responseBulletSpeed = 5;

            BulletSpeed bulletSpeed = BulletSpeed.Of(speed) / BulletSpeed.Of(divSpeed);
            Assert.That(bulletSpeed.Value, Is.EqualTo(responseBulletSpeed));
        }

        [Test]
        [TestCase(100, 1)]
        [Description("[正常] 加算した値が最大値より大きい場合に、最大値が格納されていること")]
        public void LimitAddBulletSpeed(int speed, int addSpeed) {
            int responseBulletSpeed = 100;

            BulletSpeed bulletSpeed = BulletSpeed.Of(speed) + BulletSpeed.Of(addSpeed);
            Assert.That(bulletSpeed.Value, Is.EqualTo(responseBulletSpeed));
        }

        [Test]
        [TestCase(0, 1)]
        [Description("[正常] 減算した値が最小値より小さい場合に、最小値が格納されていること")]
        public void LimitSubBulletSpeed(int speed, int subSpeed) {
            int responseBulletSpeed = 0;

            BulletSpeed bulletSpeed = BulletSpeed.Of(speed) - BulletSpeed.Of(subSpeed);
            Assert.That(bulletSpeed.Value, Is.EqualTo(responseBulletSpeed));
        }

        [Test]
        [TestCase(100, 2)]
        [Description("[正常] 乗算した値が最大値より大きい場合に、最大値が格納されていること")]
        public void LimitMulBulletSpeed(int speed, int mulSpeed) {
            int responseBulletSpeed = 100;

            BulletSpeed bulletSpeed = BulletSpeed.Of(speed) * BulletSpeed.Of(mulSpeed);
            Assert.That(bulletSpeed.Value, Is.EqualTo(responseBulletSpeed));
        }

        [Test]
        [TestCase(int.MinValue)]
        [TestCase(-1)]
        [TestCase(101)]
        [TestCase(int.MaxValue)]
        [Description("[異常] 渡された値が最小値未満か最大値より大きい場合に、スローが投げられること")]
        public void ThrowWhenValueIsOverRange(int value) {
            var exception = Assert.Throws<ArgumentException>(() => {
                BulletSpeed BulletSpeed = BulletSpeed.Of(value);
            });

            Assert.That(
                exception.Message,
                Is.EqualTo(ExceptionMessage.argumentExceptionMessage)
            );
        }

    }

}
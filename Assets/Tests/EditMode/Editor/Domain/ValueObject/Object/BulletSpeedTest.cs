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
        [Description("[正常] 渡された値が最小値以上最大値以下である場合に、値が正常に格納されること")]
        public void ValidBulletSpeed() {
            List<int> validNumberList = new List<int>() {
                0,
                5,
                100
            };

            foreach (int value in validNumberList) {
                BulletSpeed bulletSpeed = BulletSpeed.Of(value);
                Assert.That(bulletSpeed.Value, Is.EqualTo(value));
            }
        }

        [Test]
        [Description("[正常] 加算が行われた場合に、値が正常に格納されること")]
        public void ValidOperatorAddForBulletSpeed() {
            BulletSpeed bulletSpeed = BulletSpeed.Of(10);
            BulletSpeed addBulletSpeed = BulletSpeed.Of(2);
            int responseBulletSpeed = 12;

            BulletSpeed newBulletSpeed = bulletSpeed + addBulletSpeed;
            Assert.That(newBulletSpeed.Value, Is.EqualTo(responseBulletSpeed));
        }

        [Test]
        [Description("[正常] 減算が行われた場合に、値が正常に格納されること")]
        public void ValidOperatorSubForBulletSpeed() {
            BulletSpeed bulletSpeed = BulletSpeed.Of(10);
            BulletSpeed subBulletSpeed = BulletSpeed.Of(2);
            int responseBulletSpeed = 8;

            BulletSpeed newBulletSpeed = bulletSpeed - subBulletSpeed;
            Assert.That(newBulletSpeed.Value, Is.EqualTo(responseBulletSpeed));
        }

        [Test]
        [Description("[正常] 乗算が行われた場合に、値が正常に格納されること")]
        public void ValidOperatorMulForBulletSpeed() {
            BulletSpeed BulletSpeed = BulletSpeed.Of(10);
            BulletSpeed mulBulletSpeed = BulletSpeed.Of(2);
            int responseBulletSpeed = 20;

            BulletSpeed newBulletSpeed = BulletSpeed * mulBulletSpeed;
            Assert.That(newBulletSpeed.Value, Is.EqualTo(responseBulletSpeed));
        }

        [Test]
        [Description("[正常] 除算が行われた場合に、値が正常に格納されること")]
        public void ValidOperatorDivForBulletSpeed() {
            BulletSpeed BulletSpeed = BulletSpeed.Of(10);
            BulletSpeed divBulletSpeed = BulletSpeed.Of(2);
            int responseBulletSpeed = 5;

            BulletSpeed newBulletSpeed = BulletSpeed / divBulletSpeed;
            Assert.That(newBulletSpeed.Value, Is.EqualTo(responseBulletSpeed));
        }

        [Test]
        [Description("[正常] 加算した値が最大値より大きい場合に、最大値が格納されていること")]
        public void LimitAddBulletSpeed() {
            BulletSpeed BulletSpeed = BulletSpeed.Of(100);
            BulletSpeed addBulletSpeed = BulletSpeed.Of(1);
            int responseBulletSpeed = 100;

            BulletSpeed newBulletSpeed = BulletSpeed + addBulletSpeed;
            Assert.That(newBulletSpeed.Value, Is.EqualTo(responseBulletSpeed));
        }

        [Test]
        [Description("[正常] 減算した値が最小値より小さい場合に、最小値が格納されていること")]
        public void LimitSubBulletSpeed() {
            BulletSpeed BulletSpeed = BulletSpeed.Of(0);
            BulletSpeed subBulletSpeed = BulletSpeed.Of(1);
            int responseBulletSpeed = 0;

            BulletSpeed newBulletSpeed = BulletSpeed - subBulletSpeed;
            Assert.That(newBulletSpeed.Value, Is.EqualTo(responseBulletSpeed));
        }

        [Test]
        [Description("[正常] 乗算した値が最大値より大きい場合に、最大値が格納されていること")]
        public void LimitMulBulletSpeed() {
            BulletSpeed BulletSpeed = BulletSpeed.Of(100);
            BulletSpeed mulBulletSpeed = BulletSpeed.Of(2);
            int responseBulletSpeed = 100;

            BulletSpeed newBulletSpeed = BulletSpeed * mulBulletSpeed;
            Assert.That(newBulletSpeed.Value, Is.EqualTo(responseBulletSpeed));
        }

        [Test]
        [Description("[異常] 渡された値が最小値未満か最大値より大きい場合に、スローが投げられること")]
        public void ThrowWhenValueIsOverRange() {
            List<int> invalidNumberList = new List<int>() {
                int.MinValue,
                -1,
                101,
                int.MaxValue
            };

            foreach (int value in invalidNumberList) {
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

}
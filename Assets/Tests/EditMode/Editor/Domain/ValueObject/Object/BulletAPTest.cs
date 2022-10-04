using System;
using Systemk;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests {

    [Description("弾丸攻撃力のテスト")]
    public class BulletAPTest {

        [Test]
        [Description("[正常] 渡された値が最小値以上最大値以下である場合に、値が正常に格納されること")]
        public void ValidBulletAP() {
            List<int> validNumberList = new List<int>() {
                1,
                5,
                100,
            };

            foreach (int value in validNumberList) {
                BulletAP bulletAP = BulletAP.Of(value);
                Assert.That(bulletAP.Value, Is.EqualTo(value));
            }
        }

        [Test]
        [Description("[正常] 加算が行われた場合に、値が正常に格納されること")]
        public void ValidOperatorAddForBulletAP() {
            BulletAP bulletAP = BulletAP.Of(10);
            BulletAP addBulletAP = BulletAP.Of(2);
            int responseBulletAP = 12;

            BulletAP newBulletAP = bulletAP + addBulletAP;
            Assert.That(newBulletAP.Value, Is.EqualTo(responseBulletAP));
        }

        [Test]
        [Description("[正常] 減算が行われた場合に、値が正常に格納されること")]
        public void ValidOperatorSubForBulletAP() {
            BulletAP bulletAP = BulletAP.Of(10);
            BulletAP subBulletAP = BulletAP.Of(2);
            int responseBulletAP = 8;

            BulletAP newBulletAP = bulletAP - subBulletAP;
            Assert.That(newBulletAP.Value, Is.EqualTo(responseBulletAP));
        }

        [Test]
        [Description("[正常] 乗算が行われた場合に、値が正常に格納されること")]
        public void ValidOperatorMulForBulletAP() {
            BulletAP bulletAP = BulletAP.Of(10);
            BulletAP mulBulletAP = BulletAP.Of(2);
            int responseBulletAP = 20;

            BulletAP newBulletAP = bulletAP * mulBulletAP;
            Assert.That(newBulletAP.Value, Is.EqualTo(responseBulletAP));
        }

        [Test]
        [Description("[正常] 除算が行われた場合に、値が正常に格納されること")]
        public void ValidOperatorDivForBulletAP() {
            BulletAP bulletAP = BulletAP.Of(10);
            BulletAP divBulletAP = BulletAP.Of(2);
            int responseBulletAP = 5;

            BulletAP newBulletAP = bulletAP / divBulletAP;
            Assert.That(newBulletAP.Value, Is.EqualTo(responseBulletAP));
        }

        [Test]
        [Description("[正常] 加算した値が最大値より大きい場合に、最大値が格納されていること")]
        public void LimitAddBulletAP() {
            BulletAP bulletAP = BulletAP.Of(100);
            BulletAP addBulletAP = BulletAP.Of(1);
            int responseBulletAP = 100;

            BulletAP newBulletAP = bulletAP + addBulletAP;
            Assert.That(newBulletAP.Value, Is.EqualTo(responseBulletAP));
        }

        [Test]
        [Description("[正常] 減算した値が最小値より小さい場合に、最小値が格納されていること")]
        public void LimitSubBulletAP() {
            BulletAP bulletAP = BulletAP.Of(1);
            BulletAP subBulletAP = BulletAP.Of(1);
            int responseBulletAP = 1;

            BulletAP newBulletAP = bulletAP - subBulletAP;
            Assert.That(newBulletAP.Value, Is.EqualTo(responseBulletAP));
        }

        [Test]
        [Description("[正常] 乗算した値が最大値より大きい場合に、最大値が格納されていること")]
        public void LimitMulBulletAP() {
            BulletAP bulletAP = BulletAP.Of(100);
            BulletAP mulBulletAP = BulletAP.Of(2);
            int responseBulletAP = 100;

            BulletAP newBulletAP = bulletAP * mulBulletAP;
            Assert.That(newBulletAP.Value, Is.EqualTo(responseBulletAP));
        }

        [Test]
        [Description("[正常] 除算した値が最小値より小さい場合に、最小値が格納されること")]
        public void LimitDivBulletAP() {
            BulletAP bulletAP = BulletAP.Of(1);
            BulletAP mulBulletAP = BulletAP.Of(2);
            int responseBulletAP = 1;

            BulletAP newBulletAP = bulletAP / mulBulletAP;
            Assert.That(newBulletAP.Value, Is.EqualTo(responseBulletAP));
        }

        [Test]
        [Description("[異常] 渡された値が最小値未満か最大値より大きい場合に、スローが投げられること")]
        public void ThrowWhenValueIsOverRange() {
            List<int> invalidNumberList = new List<int>() {
                int.MinValue,
                0,
                101,
                int.MaxValue
            };

            foreach (int value in invalidNumberList) {
                var exception = Assert.Throws<ArgumentException>(() => {
                    BulletAP bulletAP = BulletAP.Of(value);
                });

                Assert.That(
                    exception.Message,
                    Is.EqualTo(ExceptionMessage.argumentExceptionMessage)
                );
            }
        }


    }

}

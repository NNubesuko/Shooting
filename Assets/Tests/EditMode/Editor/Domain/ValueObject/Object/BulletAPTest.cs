using System;
using System.Runtime.InteropServices;
using System.Collections;
using System.Collections.Generic;
using Systemk;
using Systemk.Exceptions;
using Systemk.Util;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests {

    [Description("弾丸攻撃力のテスト")]
    public class BulletAPTest {

        [Test]
        [TestCase(1)]
        [TestCase(5)]
        [TestCase(100)]
        [Description("[正常] 渡された値が最小値以上最大値以下である場合に、値が正常に格納されること")]
        public void ValidBulletAP(int value) {
            BulletAP bulletAP = BulletAP.Of(value);
            Assert.That(bulletAP.Value, Is.EqualTo(value));
        }

        [Test]
        [TestCase(10, 2)]
        [Description("[正常] 加算が行われた場合に、値が正常に格納されること")]
        public void ValidOperatorAddForBulletAP(int value, int addValue) {
            int responseBulletAP = 12;

            BulletAP newBulletAP = BulletAP.Of(value) + BulletAP.Of(addValue);
            Assert.That(newBulletAP.Value, Is.EqualTo(responseBulletAP));
        }

        [Test]
        [TestCase(10, 2)]
        [Description("[正常] 減算が行われた場合に、値が正常に格納されること")]
        public void ValidOperatorSubForBulletAP(int value, int subValue) {
            int responseBulletAP = 8;

            BulletAP newBulletAP = BulletAP.Of(value) - BulletAP.Of(subValue);
            Assert.That(newBulletAP.Value, Is.EqualTo(responseBulletAP));
        }

        [Test]
        [TestCase(10, 2)]
        [Description("[正常] 乗算が行われた場合に、値が正常に格納されること")]
        public void ValidOperatorMulForBulletAP(int value, int mulValue) {
            int responseBulletAP = 20;

            BulletAP newBulletAP = BulletAP.Of(value) * BulletAP.Of(mulValue);
            Assert.That(newBulletAP.Value, Is.EqualTo(responseBulletAP));
        }

        [Test]
        [TestCase(10, 2)]
        [Description("[正常] 除算が行われた場合に、値が正常に格納されること")]
        public void ValidOperatorDivForBulletAP(int value, int divValue) {
            int responseBulletAP = 5;

            BulletAP newBulletAP = BulletAP.Of(value) / BulletAP.Of(divValue);
            Assert.That(newBulletAP.Value, Is.EqualTo(responseBulletAP));
        }

        [Test]
        [TestCase(100, 1)]
        [Description("[正常] 加算した値が最大値より大きい場合に、最大値が格納されていること")]
        public void LimitAddBulletAP(int value, int addValue) {
            int responseBulletAP = 100;

            BulletAP newBulletAP = BulletAP.Of(value) + BulletAP.Of(addValue);
            Assert.That(newBulletAP.Value, Is.EqualTo(responseBulletAP));
        }

        [Test]
        [TestCase(1, 1)]
        [Description("[正常] 減算した値が最小値より小さい場合に、最小値が格納されていること")]
        public void LimitSubBulletAP(int value, int subValue) {
            int responseBulletAP = 1;

            BulletAP newBulletAP = BulletAP.Of(value) - BulletAP.Of(subValue);
            Assert.That(newBulletAP.Value, Is.EqualTo(responseBulletAP));
        }

        [Test]
        [TestCase(100, 2)]
        [Description("[正常] 乗算した値が最大値より大きい場合に、最大値が格納されていること")]
        public void LimitMulBulletAP(int value, int mulValue) {
            int responseBulletAP = 100;

            BulletAP newBulletAP = BulletAP.Of(value) * BulletAP.Of(mulValue);
            Assert.That(newBulletAP.Value, Is.EqualTo(responseBulletAP));
        }

        [Test]
        [TestCase(1, 2)]
        [Description("[正常] 除算した値が最小値より小さい場合に、最小値が格納されること")]
        public void LimitDivBulletAP(int value, int divValue) {
            int responseBulletAP = 1;

            BulletAP newBulletAP = BulletAP.Of(value) / BulletAP.Of(divValue);
            Assert.That(newBulletAP.Value, Is.EqualTo(responseBulletAP));
        }

        [Test]
        [TestCase(100, TestCodeIni.ScriptBytes)]
        [Description(
            "[正常] スクリプト自体のサイズとインスタンスのサイズが、スクリプトバイト以下であること"
        )]
        public void ValidScriptCapacity(int value, int scriptBytes) {
            BulletAP bulletAP = BulletAP.Of(value);

            Assert.That(Marshal.SizeOf(typeof(BulletAP)), Is.LessThanOrEqualTo(scriptBytes));
            Assert.That(Marshal.SizeOf(bulletAP), Is.LessThanOrEqualTo(scriptBytes));
        }

        [Test]
        [TestCase(int.MinValue)]
        [TestCase(0)]
        [TestCase(101)]
        [TestCase(int.MaxValue)]
        [Description("[異常] 渡された値が最小値未満か最大値より大きい場合に、スローが投げられること")]
        public void ThrowWhenValueIsOverRange(int value) {
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

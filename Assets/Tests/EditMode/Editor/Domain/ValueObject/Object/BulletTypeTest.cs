using System;
using Systemk;
using Systemk.Exceptions;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests {

    [Description("弾丸の種類のテスト")]
    public class BulletTypeTest {

        [Test]
        [TestCase(0)]
        [Description("[正常] 通常の弾丸が存在する場合に、値が正常に格納されていること")]
        public void ValidNormalBulletType(int bulletType) {
            BulletType responseBulletType = BulletType.Normal;

            Assert.That(bulletType, Is.EqualTo(responseBulletType.Value));
        }

        [Test]
        [TestCase(1)]
        [Description("[正常] 強化弾が存在する場合に、値が正常に格納されていること")]
        public void ValidHeadBulletType(int bulletType) {
            BulletType responseBulletType = BulletType.Head;

            Assert.That(bulletType, Is.EqualTo(responseBulletType.Value));
        }

        [Test]
        [TestCase(int.MinValue)]
        [TestCase(int.MaxValue)]
        [Description("[異常] 弾丸の種類が存在しない場合に、スローが投げられること")]
        public void NotExistBulletType(int bulletType) {
            var exception = Assert.Throws<BulletTypeNotFoundException>(() => {
                BulletType bulletTypeInstance = BulletType.Of(bulletType);
            });

            Assert.That(
                exception.Message,
                Is.EqualTo(ExceptionMessage.bulletTypeNotFoundExceptionMessage)
            );
        }

    }

}
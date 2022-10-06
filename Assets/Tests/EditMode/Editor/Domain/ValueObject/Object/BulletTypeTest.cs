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
        [Description("[正常] 弾丸の種類が存在する場合に、値が正常に格納されていること")]
        public void ValidBulletType() {
            BulletType bulletType = BulletType.Normal;
            BulletType responseBulletType = (BulletType)0;

            Assert.That(bulletType.Value, Is.EqualTo(responseBulletType.Value));
        }

        [Test]
        [Description("[異常] 弾丸の種類が存在しない場合に、スローが投げられること")]
        public void NotExistBulletType() {
            var exception = Assert.Throws<BulletTypeNotFoundException>(() => {
                BulletType bulletType = (BulletType)9999;
            });

            Assert.That(
                exception.Message,
                Is.EqualTo(ExceptionMessage.bulletTypeNotFoundExceptionMessage)
            );
        }

    }

}
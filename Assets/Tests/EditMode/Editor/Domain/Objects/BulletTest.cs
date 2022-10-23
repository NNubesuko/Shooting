using System;
using Systemk;
using Systemk.Exceptions;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests {

    [Description("弾丸のテスト")]
    public class BulletTest {

        [Test]
        [TestCase(10, 25)]
        [Description("[正常] 通常の弾丸を選択した場合に、通常の弾丸が返却されること")]
        public void ValidNormalBullet(int ap, int speed) {
            BulletType responseBulletType = BulletType.Normal;
            BulletAP responseBulletAP = BulletAP.Of(ap);
            BulletSpeed responseBulletSpeed = BulletSpeed.Of(speed);

            Bullet bullet = Bullet.Generate(BulletType.Normal);

            Assert.That(bullet.Type, Is.EqualTo(responseBulletType));
            Assert.That(bullet.AP, Is.EqualTo(responseBulletAP));
            Assert.That(bullet.Speed, Is.EqualTo(responseBulletSpeed));
        }

        [Test]
        [TestCase(50, 10)]
        [Description("[正常] 強化弾を選択した場合に、強化弾が返却されること")]
        public void ValidHeadBullet(int ap, int speed) {
            BulletType responseBulletType = BulletType.Head;
            BulletAP responseBulletAP = BulletAP.Of(ap);
            BulletSpeed responseBulletSpeed = BulletSpeed.Of(speed);

            Bullet bullet = Bullet.Generate(BulletType.Head);

            Assert.That(bullet.Type, Is.EqualTo(responseBulletType));
            Assert.That(bullet.AP, Is.EqualTo(responseBulletAP));
            Assert.That(bullet.Speed, Is.EqualTo(responseBulletSpeed));
        }

    }

}
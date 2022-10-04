using System;
using Systemk;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests {

    [Description("弾丸のテスト")]
    public class BulletTest {

        [Test]
        [Description("通常の弾丸を選択した場合に、通常の弾丸が返却されること")]
        public void ValidNormalBullet() {
            BulletType responseBulletType = BulletType.Normal;
            BulletAP responseBulletAP = BulletAP.Of(10);
            BulletSpeed responseBulletSpeed = BulletSpeed.Of(25);

            Bullet bullet = Bullet.Of(BulletType.Normal);

            Assert.That(bullet.Type, Is.EqualTo(responseBulletType));
            Assert.That(bullet.AP, Is.EqualTo(responseBulletAP));
            Assert.That(bullet.Speed, Is.EqualTo(responseBulletSpeed));
        }

        [Test]
        [Description("強化弾を選択した場合に、強化弾が返却されること")]
        public void ValidHeadBullet() {
            BulletType responseBulletType = BulletType.Head;
            BulletAP responseBulletAP = BulletAP.Of(50);
            BulletSpeed responseBulletSpeed = BulletSpeed.Of(10);

            Bullet bullet = Bullet.Of(BulletType.Head);

            Assert.That(bullet.Type, Is.EqualTo(responseBulletType));
            Assert.That(bullet.AP, Is.EqualTo(responseBulletAP));
            Assert.That(bullet.Speed, Is.EqualTo(responseBulletSpeed));
        }

    }

}
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

    [Description("弾丸の種類のテスト")]
    public class BulletTypeTest {

        [Test]
        [TestCase(0)]
        [Description("[正常] 通常の弾丸が存在する場合に、値が正常に格納されていること")]
        public void ValidNormalBulletType(int value) {
            BulletType bulletType = BulletType.Normal;

            Assert.That(value, Is.EqualTo(bulletType.Value));
        }

        [Test]
        [TestCase(1)]
        [Description("[正常] 強化弾が存在する場合に、値が正常に格納されていること")]
        public void ValidHeadBulletType(int value) {
            BulletType bulletType = BulletType.Head;

            Assert.That(value, Is.EqualTo(bulletType.Value));
        }

        [Test]
        [TestCase(TestCodeIni.ScriptBytes)]
        [Description(
            "[正常] スクリプト自体のサイズとインスタンスのサイズが、スクリプトバイト以下であること"
        )]
        public void ValidScriptCapacity(int scriptBytes) {
            BulletType bulletType = BulletType.Normal;

            Assert.That(Marshal.SizeOf(typeof(BulletType)), Is.LessThanOrEqualTo(scriptBytes));
            Assert.That(Marshal.SizeOf(bulletType), Is.LessThanOrEqualTo(scriptBytes));
        }

        [Test]
        [TestCase(int.MinValue)]
        [TestCase(int.MaxValue)]
        [Description("[異常] 弾丸の種類が存在しない場合に、スローが投げられること")]
        public void NotExistBulletType(int value) {
            var exception = Assert.Throws<BulletTypeNotFoundException>(() => {
                BulletType bulletType = BulletType.Of(value);
            });

            Assert.That(
                exception.Message,
                Is.EqualTo(ExceptionMessage.bulletTypeNotFoundExceptionMessage)
            );
        }

    }

}
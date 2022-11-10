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

    [Description("敵の攻撃力のテスト")]
    public class EnemyAPTest {

        [Test]
        [TestCase(0)]
        [TestCase(50)]
        [TestCase(100)]
        [Description("[正常] 渡された値が最小値以上最大値以下である場合に、値が正常に格納されること")]
        public void ValidEnemyAP(int value) {
            EnemyAP enemyAP = EnemyAP.Of(value);
            Assert.That(enemyAP.Value, Is.EqualTo(value));
        }

        [Test]
        [TestCase(10, 2)]
        [Description("[正常] EnemyAP同士の加算が行われた場合に、値が正常に格納されること")]
        public void ValidEnemyAPOperatorAdd(int value, int addValue) {
            int responseEnemyAP = 12;

            EnemyAP enemyAP = EnemyAP.Of(value) + EnemyAP.Of(addValue);
            Assert.That(enemyAP.Value, Is.EqualTo(responseEnemyAP));
        }

        [Test]
        [TestCase(10, 2)]
        [Description("[正常] EnemyAP同士の減算が行われた場合に、値が正常に格納されること")]
        public void ValidEnemyAPOperatorSub(int value, int subValue) {
            int responseEnemyAP = 8;

            EnemyAP enemyAP = EnemyAP.Of(value) - EnemyAP.Of(subValue);
            Assert.That(enemyAP.Value, Is.EqualTo(responseEnemyAP));
        }

        [Test]
        [TestCase(10, 2)]
        [Description("[正常] EnemyAP同士の乗算が行われた場合に、値が正常に格納されること")]
        public void ValidEnemyAPOperatorMul(int value, int mulValue) {
            int responseEnemyAP = 20;

            EnemyAP enemyAP = EnemyAP.Of(value) * EnemyAP.Of(mulValue);
            Assert.That(enemyAP.Value, Is.EqualTo(responseEnemyAP));
        }

        [Test]
        [TestCase(10, 2)]
        [Description("[正常] EnemyAP同士の除算が行われた場合に、値が正常に格納されること")]
        public void ValidEnemyAPOperatorDiv(int value, int divValue) {
            int responseEnemyAP = 5;

            EnemyAP enemyAP = EnemyAP.Of(value) / EnemyAP.Of(divValue);
            Assert.That(enemyAP.Value, Is.EqualTo(responseEnemyAP));
        }

        [Test]
        [TestCase(100, 10)]
        [Description("[正常] 加算した値が最大値より大きい場合に、最大値が格納されていること")]
        public void LimitAddEnemyAP(int value, int addValue) {
            int responseEnemyAP = 100;

            EnemyAP enemyAP = EnemyAP.Of(value) + EnemyAP.Of(addValue);
            Assert.That(enemyAP.Value, Is.EqualTo(responseEnemyAP));
        }

        [Test]
        [TestCase(0, 1)]
        [Description("[正常] 減算した値が最小値より小さい場合に、最小値が格納されていること")]
        public void LimitSubEnemyAP(int value, int subValue) {
            int responseEnemyAP = 0;

            EnemyAP enemyAP = EnemyAP.Of(value) - EnemyAP.Of(subValue);
            Assert.That(enemyAP.Value, Is.EqualTo(responseEnemyAP));
        }

        [Test]
        [TestCase(100, 2)]
        [Description("[正常] 乗算した値が最大値より大きい場合に、最大値が格納されていること")]
        public void LimitMulEnemyAP(int value, int mulValue) {
            int responseEnemyAP = 100;

            EnemyAP enemyAP = EnemyAP.Of(value) * EnemyAP.Of(mulValue);
            Assert.That(enemyAP.Value, Is.EqualTo(responseEnemyAP));
        }

        [Test]
        [TestCase(100, TestCodeIni.ScriptBytes)]
        [Description(
            "[正常] スクリプト自体のサイズとインスタンスのサイズが、スクリプトバイト以下であること"
        )]
        public void ValidScriptCapacity(int value, int scriptBytes) {
            EnemyAP enemyAP = EnemyAP.Of(value);

            Assert.That(Marshal.SizeOf(typeof(EnemyAP)), Is.LessThanOrEqualTo(scriptBytes));
            Assert.That(Marshal.SizeOf(enemyAP), Is.LessThanOrEqualTo(scriptBytes));
        }

        [Test]
        [TestCase(int.MinValue)]
        [TestCase(-1)]
        [TestCase(101)]
        [TestCase(int.MaxValue)]
        [Description("[異常] 渡された値が最小値未満か最大値より大きい場合に、スローが投げられること")]
        public void ThrowWhenValueIsOverRange(int value) {
            var exception = Assert.Throws<ArgumentException>(() => {
                EnemyAP enemyAP = EnemyAP.Of(value);
            });

            Assert.That(
                exception.Message,
                Is.EqualTo(ExceptionMessage.argumentExceptionMessage)
            );
        }

        [Test]
        [TestCase(1, 0)]
        [Description("[異常] 除算において0で割っている場合に、スローが投げられること")]
        public void ThrowWhenDivEnemyAP(int value, int divValue) {
            var exception = Assert.Throws<DivideByZeroException>(() => {
                EnemyAP enemyAP = EnemyAP.Of(value) / EnemyAP.Of(divValue);
            });

            Assert.That(
                exception.Message,
                Is.EqualTo(ExceptionMessage.divideByZeroExceptionMessage)
            );
        }

    }

}

using System;
using System.Runtime.InteropServices;
using System.Collections;
using System.Collections.Generic;
using Systemk;
using Systemk.Exceptions;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests {

    [Description("敵の獲得ポイントのテスト")]
    public class EnemyPointTest {

        [Test]
        [TestCase(0)]
        [TestCase(50)]
        [TestCase(100)]
        [Description("[正常] 渡された値が最小値以上最大値以下である場合に、値が正常に格納されること")]
        public void ValidEnemyPoint(int value) {
            EnemyPoint enemyPoint = EnemyPoint.Of(value);
            Assert.That(enemyPoint.Value, Is.EqualTo(value));
        }

        [Test]
        [TestCase(10, 2)]
        [Description("[正常] EnemyPoint同士の加算が行われた場合に、値が正常に格納されること")]
        public void ValidEnemyPointOperatorAdd(int value, int addValue) {
            int responseEnemyPoint = 12;

            EnemyPoint enemyPoint = EnemyPoint.Of(value) + EnemyPoint.Of(addValue);
            Assert.That(enemyPoint.Value, Is.EqualTo(responseEnemyPoint));
        }

        [Test]
        [TestCase(10, 2)]
        [Description("[正常] EnemyPoint同士の減算が行われた場合に、値が正常に格納されること")]
        public void ValidEnemyPointOperatorSub(int value, int subValue) {
            int responseEnemyPoint = 8;

            EnemyPoint enemyPoint = EnemyPoint.Of(value) - EnemyPoint.Of(subValue);
            Assert.That(enemyPoint.Value, Is.EqualTo(responseEnemyPoint));
        }

        [Test]
        [TestCase(10, 2)]
        [Description("[正常] EnemyPoint同士の乗算が行われた場合に、値が正常に格納されること")]
        public void ValidEnemyPointOperatorMul(int value, int mulValue) {
            int responseEnemyPoint = 20;

            EnemyPoint enemyPoint = EnemyPoint.Of(value) * EnemyPoint.Of(mulValue);
            Assert.That(enemyPoint.Value, Is.EqualTo(responseEnemyPoint));
        }

        [Test]
        [TestCase(10, 2)]
        [Description("[正常] EnemyPoint同士の除算が行われた場合に、値が正常に格納されること")]
        public void ValidEnemyPointOperatorDiv(int value, int divValue) {
            int responseEnemyPoint = 5;

            EnemyPoint enemyPoint = EnemyPoint.Of(value) / EnemyPoint.Of(divValue);
            Assert.That(enemyPoint.Value, Is.EqualTo(responseEnemyPoint));
        }

        [Test]
        [TestCase(100, 10)]
        [Description("[正常] 加算した値が最大値より大きい場合に、最大値が格納されていること")]
        public void LimitAddEnemyPoint(int value, int addValue) {
            int responseEnemyPoint = 100;

            EnemyPoint enemyPoint = EnemyPoint.Of(value) + EnemyPoint.Of(addValue);
            Assert.That(enemyPoint.Value, Is.EqualTo(responseEnemyPoint));
        }

        [Test]
        [TestCase(0, 1)]
        [Description("[正常] 減算した値が最小値より小さい場合に、最小値が格納されていること")]
        public void LimitSubEnemyPoint(int value, int subValue) {
            int responseEnemyPoint = 0;

            EnemyPoint enemyPoint = EnemyPoint.Of(value) - EnemyPoint.Of(subValue);
            Assert.That(enemyPoint.Value, Is.EqualTo(responseEnemyPoint));
        }

        [Test]
        [TestCase(100, 2)]
        [Description("[正常] 乗算した値が最大値より大きい場合に、最大値が格納されていること")]
        public void LimitMulEnemyPoint(int value, int mulValue) {
            int responseEnemyPoint = 100;

            EnemyPoint enemyPoint = EnemyPoint.Of(value) * EnemyPoint.Of(mulValue);
            Assert.That(enemyPoint.Value, Is.EqualTo(responseEnemyPoint));
        }

        [Test]
        [TestCase(100, TestCodeIni.ScriptBytes)]
        [Description(
            "[正常] スクリプト自体のサイズとインスタンスのサイズが、スクリプトバイト以下であること"
        )]
        public void ValidScriptCapacity(int value, int scriptBytes) {
            EnemyPoint enemyPoint = EnemyPoint.Of(value);

            Assert.That(Marshal.SizeOf(typeof(EnemyPoint)), Is.LessThanOrEqualTo(scriptBytes));
            Assert.That(Marshal.SizeOf(enemyPoint), Is.LessThanOrEqualTo(scriptBytes));
        }

        [Test]
        [TestCase(int.MinValue)]
        [TestCase(-1)]
        [TestCase(101)]
        [TestCase(int.MaxValue)]
        [Description("[異常] 渡された値が最小値未満か最大値より大きい場合に、スローが投げられること")]
        public void ThrowWhenValueIsOverRange(int value) {
            var exception = Assert.Throws<ArgumentException>(() => {
                EnemyPoint enemyPoint = EnemyPoint.Of(value);
            });

            Assert.That(
                exception.Message,
                Is.EqualTo(ExceptionMessage.argumentExceptionMessage)
            );
        }

        [Test]
        [TestCase(1, 0)]
        [Description("[異常] 除算において0で割っている場合に、スローが投げられること")]
        public void ThrowWhenDivEnemyPoint(int value, int divValue) {
            var exception = Assert.Throws<DivideByZeroException>(() => {
                EnemyPoint enemyPoint = EnemyPoint.Of(value) / EnemyPoint.Of(divValue);
            });

            Assert.That(
                exception.Message,
                Is.EqualTo(ExceptionMessage.divideByZeroExceptionMessage)
            );
        }

    }

}

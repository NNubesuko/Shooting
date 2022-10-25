using System;
using System.Runtime.InteropServices;
using Systemk;
using Systemk.Exceptions;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests {

    [Description("敵の体力のテスト")]
    public class EnemyHPTest {

        [Test]
        [TestCase(0)]
        [TestCase(50)]
        [TestCase(100)]
        [Description("[正常] 渡された値が最小値以上最大値以下である場合に、値が正常に格納されること")]
        public void ValidEnemyHP(int value) {
            EnemyHP enemyHP = EnemyHP.Of(value);
            Assert.That(enemyHP.Value, Is.EqualTo(value));
        }

        [Test]
        [TestCase(10, 2)]
        [Description("[正常] EnemyHP同士の加算が行われた場合に、値が正常に格納されること")]
        public void ValidEnemyHPOperatorAdd(int value, int addValue) {
            int responseEnemyHP = 12;

            EnemyHP enemyHP = EnemyHP.Of(value) + EnemyHP.Of(addValue);
            Assert.That(enemyHP.Value, Is.EqualTo(responseEnemyHP));
        }

        [Test]
        [TestCase(10, 2)]
        [Description("[正常] EnemyHP同士の減算が行われた場合に、値が正常に格納されること")]
        public void ValidEnemyHPOperatorSub(int value, int subValue) {
            int responseEnemyHP = 8;

            EnemyHP enemyHP = EnemyHP.Of(value) - EnemyHP.Of(subValue);
            Assert.That(enemyHP.Value, Is.EqualTo(responseEnemyHP));
        }

        [Test]
        [TestCase(10, 2)]
        [Description("[正常] EnemyHP同士の乗算が行われた場合に、値が正常に格納されること")]
        public void ValidEnemyHPOperatorMul(int value, int mulValue) {
            int responseEnemyHP = 20;

            EnemyHP enemyHP = EnemyHP.Of(value) * EnemyHP.Of(mulValue);
            Assert.That(enemyHP.Value, Is.EqualTo(responseEnemyHP));
        }

        [Test]
        [TestCase(10, 2)]
        [Description("[正常] EnemyHP同士の除算が行われた場合に、値が正常に格納されること")]
        public void ValidEnemyHPOperatorDiv(int value, int divValue) {
            int responseEnemyHP = 5;

            EnemyHP enemyHP = EnemyHP.Of(value) / EnemyHP.Of(divValue);
            Assert.That(enemyHP.Value, Is.EqualTo(responseEnemyHP));
        }

        [Test]
        [TestCase(100, 10)]
        [Description("[正常] 加算した値が最大値より大きい場合に、最大値が格納されていること")]
        public void LimitAddEnemyHP(int value, int addValue) {
            int responseEnemyHP = 100;

            EnemyHP enemyHP = EnemyHP.Of(value) + EnemyHP.Of(addValue);
            Assert.That(enemyHP.Value, Is.EqualTo(responseEnemyHP));
        }

        [Test]
        [TestCase(0, 1)]
        [Description("[正常] 減算した値が最小値より小さい場合に、最小値が格納されていること")]
        public void LimitSubEnemyHP(int value, int subValue) {
            int responseEnemyHP = 0;

            EnemyHP enemyHP = EnemyHP.Of(value) - EnemyHP.Of(subValue);
            Assert.That(enemyHP.Value, Is.EqualTo(responseEnemyHP));
        }

        [Test]
        [TestCase(100, 2)]
        [Description("[正常] 乗算した値が最大値より大きい場合に、最大値が格納されていること")]
        public void LimitMulEnemyHP(int value, int mulValue) {
            int responseEnemyHP = 100;

            EnemyHP enemyHP = EnemyHP.Of(value) * EnemyHP.Of(mulValue);
            Assert.That(enemyHP.Value, Is.EqualTo(responseEnemyHP));
        }

        [Test]
        [TestCase(100, TestCodeIni.ScriptBytes)]
        [Description(
            "[正常] スクリプト自体のサイズとインスタンスのサイズが、スクリプトバイト以下であること"
        )]
        public void ValidScriptCapacity(int value, int scriptBytes) {
            EnemyHP enemyHP = EnemyHP.Of(value);

            Assert.That(Marshal.SizeOf(typeof(EnemyHP)), Is.LessThanOrEqualTo(scriptBytes));
            Assert.That(Marshal.SizeOf(enemyHP), Is.LessThanOrEqualTo(scriptBytes));
        }

        [Test]
        [TestCase(int.MinValue)]
        [TestCase(-1)]
        [TestCase(101)]
        [TestCase(int.MaxValue)]
        [Description("[異常] 渡された値が最小値未満か最大値より大きい場合に、スローが投げられること")]
        public void ThrowWhenValueIsOverRange(int value) {
            var exception = Assert.Throws<ArgumentException>(() => {
                EnemyHP enemyHP = EnemyHP.Of(value);
            });

            Assert.That(
                exception.Message,
                Is.EqualTo(ExceptionMessage.argumentExceptionMessage)
            );
        }

        [Test]
        [TestCase(1, 0)]
        [Description("[異常] 除算において0で割っている場合に、スローが投げられること")]
        public void ThrowWhenDivEnemyHP(int value, int divValue) {
            var exception = Assert.Throws<DivideByZeroException>(() => {
                EnemyHP enemyHP = EnemyHP.Of(value) / EnemyHP.Of(divValue);
            });

            Assert.That(
                exception.Message,
                Is.EqualTo(ExceptionMessage.divideByZeroExceptionMessage)
            );
        }

    }

}

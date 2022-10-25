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

    [Description("敵の移動速度のテスト")]
    public class EnemyMoveSpeedTest {

        [Test]
        [TestCase(0)]
        [TestCase(10)]
        [TestCase(25)]
        [Description("[正常] 渡された値が最小値以上最大値以下である場合に、値が正常に格納されること")]
        public void ValidEnemyMoveSpeed(int value) {
            EnemyMoveSpeed enemyMoveSpeed = EnemyMoveSpeed.Of(value);
            Assert.That(enemyMoveSpeed.Value, Is.EqualTo(value));
        }

        [Test]
        [TestCase(10, 2)]
        [Description("[正常] EnemyMoveSpeed同士の加算が行われた場合に、値が正常に格納されること")]
        public void ValidEnemyMoveSpeedOperatorAdd(int value, int addValue) {
            int responseEnemyMoveSpeed = 12;

            EnemyMoveSpeed enemyMoveSpeed = EnemyMoveSpeed.Of(value) + EnemyMoveSpeed.Of(addValue);
            Assert.That(enemyMoveSpeed.Value, Is.EqualTo(responseEnemyMoveSpeed));
        }

        [Test]
        [TestCase(10, 2)]
        [Description("[正常] EnemyMoveSpeed同士の減算が行われた場合に、値が正常に格納されること")]
        public void ValidEnemyMoveSpeedOperatorSub(int value, int subValue) {
            int responseEnemyMoveSpeed = 8;

            EnemyMoveSpeed enemyMoveSpeed = EnemyMoveSpeed.Of(value) - EnemyMoveSpeed.Of(subValue);
            Assert.That(enemyMoveSpeed.Value, Is.EqualTo(responseEnemyMoveSpeed));
        }

        [Test]
        [TestCase(10, 2)]
        [Description("[正常] EnemyMoveSpeed同士の乗算が行われた場合に、値が正常に格納されること")]
        public void ValidEnemyMoveSpeedOperatorMul(int value, int mulValue) {
            int responseEnemyMoveSpeed = 20;

            EnemyMoveSpeed enemyMoveSpeed = EnemyMoveSpeed.Of(value) * EnemyMoveSpeed.Of(mulValue);
            Assert.That(enemyMoveSpeed.Value, Is.EqualTo(responseEnemyMoveSpeed));
        }

        [Test]
        [TestCase(10, 2)]
        [Description("[正常] EnemyMoveSpeed同士の除算が行われた場合に、値が正常に格納されること")]
        public void ValidEnemyMoveSpeedOperatorDiv(int value, int divValue) {
            int responseEnemyMoveSpeed = 5;

            EnemyMoveSpeed enemyMoveSpeed = EnemyMoveSpeed.Of(value) / EnemyMoveSpeed.Of(divValue);
            Assert.That(enemyMoveSpeed.Value, Is.EqualTo(responseEnemyMoveSpeed));
        }

        [Test]
        [TestCase(25, 10)]
        [Description("[正常] 加算した値が最大値より大きい場合に、最大値が格納されていること")]
        public void LimitAddEnemyMoveSpeed(int value, int addValue) {
            int responseEnemyMoveSpeed = 25;

            EnemyMoveSpeed enemyMoveSpeed = EnemyMoveSpeed.Of(value) + EnemyMoveSpeed.Of(addValue);
            Assert.That(enemyMoveSpeed.Value, Is.EqualTo(responseEnemyMoveSpeed));
        }

        [Test]
        [TestCase(0, 1)]
        [Description("[正常] 減算した値が最小値より小さい場合に、最小値が格納されていること")]
        public void LimitSubEnemyMoveSpeed(int value, int subValue) {
            int responseEnemyMoveSpeed = 0;

            EnemyMoveSpeed enemyMoveSpeed = EnemyMoveSpeed.Of(value) - EnemyMoveSpeed.Of(subValue);
            Assert.That(enemyMoveSpeed.Value, Is.EqualTo(responseEnemyMoveSpeed));
        }

        [Test]
        [TestCase(25, 2)]
        [Description("[正常] 乗算した値が最大値より大きい場合に、最大値が格納されていること")]
        public void LimitMulEnemyMoveSpeed(int value, int mulValue) {
            int responseEnemyMoveSpeed = 25;

            EnemyMoveSpeed enemyMoveSpeed = EnemyMoveSpeed.Of(value) * EnemyMoveSpeed.Of(mulValue);
            Assert.That(enemyMoveSpeed.Value, Is.EqualTo(responseEnemyMoveSpeed));
        }

        [Test]
        [TestCase(25, TestCodeIni.ScriptBytes)]
        [Description(
            "[正常] スクリプト自体のサイズとインスタンスのサイズが、スクリプトバイト以下であること"
        )]
        public void ValidScriptCapacity(int value, int scriptBytes) {
            EnemyMoveSpeed enemyMoveSpeed = EnemyMoveSpeed.Of(value);

            Assert.That(Marshal.SizeOf(typeof(EnemyMoveSpeed)), Is.LessThanOrEqualTo(scriptBytes));
            Assert.That(Marshal.SizeOf(enemyMoveSpeed), Is.LessThanOrEqualTo(scriptBytes));
        }

        [Test]
        [TestCase(int.MinValue)]
        [TestCase(-1)]
        [TestCase(26)]
        [TestCase(int.MaxValue)]
        [Description("[異常] 渡された値が最小値未満か最大値より大きい場合に、スローが投げられること")]
        public void ThrowWhenValueIsOverRange(int value) {
            var exception = Assert.Throws<ArgumentException>(() => {
                EnemyMoveSpeed enemyMoveSpeed = EnemyMoveSpeed.Of(value);
            });

            Assert.That(
                exception.Message,
                Is.EqualTo(ExceptionMessage.argumentExceptionMessage)
            );
        }

        [Test]
        [TestCase(1, 0)]
        [Description("[異常] 除算において0で割っている場合に、スローが投げられること")]
        public void ThrowWhenDivEnemyMoveSpeed(int value, int divValue) {
            var exception = Assert.Throws<DivideByZeroException>(() => {
                EnemyMoveSpeed enemyMoveSpeed =
                    EnemyMoveSpeed.Of(value) / EnemyMoveSpeed.Of(divValue);
            });

            Assert.That(
                exception.Message,
                Is.EqualTo(ExceptionMessage.divideByZeroExceptionMessage)
            );
        }

    }

}

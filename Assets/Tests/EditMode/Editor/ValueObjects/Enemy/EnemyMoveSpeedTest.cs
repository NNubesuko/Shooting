using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using KataokaLib.ValueObject;

namespace Tests {

    [Description("敵の移動速度のテスト")]
    public class EnemyMoveSpeedTest {

        [Test]
        [TestCase(0f)]
        [TestCase(5f)]
        [TestCase(10f)]
        [Description("[正常] 渡された値が最小値以上かつ最大値以下である場合に、正常に格納されること")]
        public void ValidEnemyMoveSpeed(float value) {
            EnemyMoveSpeed enemyMoveSpeed = EnemyMoveSpeed.Of(value);
            Assert.That(enemyMoveSpeed, Is.EqualTo(EnemyMoveSpeed.Of(value)));
        }

        [Test]
        [TestCase(float.MinValue)]
        [TestCase(-1f)]
        [TestCase(11f)]
        [TestCase(float.MaxValue)]
        [Description("[異常] 渡された値が最小値未満または最大値より大きい場合に、スローが投げられること")]
        public void InvalidEnemyMoveSpeed(float value) {
            var exception = Assert.Throws<ArgumentException>(() => {
                EnemyMoveSpeed enemyMoveSpeed = EnemyMoveSpeed.Of(value);
            });

            Assert.That(
                exception.Message,
                Is.EqualTo(
                    ValueObjectExceptionHandler.ArgumentException(nameof(value)).Message
                )
            );
        }

    }

}

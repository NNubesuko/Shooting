using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using KataokaLib.ValueObject;

namespace Tests {

    [Description("敵の得点のテスト")]
    public class EnemyPointTest {

        [Test]
        [TestCase(0)]
        [TestCase(50)]
        [TestCase(100)]
        [Description("[正常] 渡された値が最小値以上かつ最大値以下である場合に、正常に格納されること")]
        public void ValidEnemyPoint(int value) {
            EnemyPoint enemyPoint = EnemyPoint.Of(value);
            Assert.That(enemyPoint, Is.EqualTo(EnemyPoint.Of(value)));
        }

        [Test]
        [TestCase(int.MinValue)]
        [TestCase(-1)]
        [TestCase(101)]
        [TestCase(int.MaxValue)]
        [Description("[異常] 渡された値が最小値未満または最大値より大きい場合に、スローが投げられること")]
        public void InvalidEnemyPoint(int value) {
            var exception = Assert.Throws<ArgumentException>(() => {
                EnemyPoint enemyPoint = EnemyPoint.Of(value);
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

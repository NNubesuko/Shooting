using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using KataokaLib.ValueObject;

namespace Tests {

    [Description("敵の体力のテスト")]
    public class EnemyHPTest {

        [Test]
        [TestCase(0)]
        [TestCase(500)]
        [TestCase(1000)]
        [Description("[正常] 渡された値が最小値以上かつ最大値以下である場合に、正常に格納されること")]
        public void ValidEnemyHP(int value) {
            EnemyHP enemyHP = EnemyHP.Of(value);
            Assert.That(enemyHP, Is.EqualTo(EnemyHP.Of(value)));
        }

        [Test]
        [TestCase(int.MinValue)]
        [TestCase(-1)]
        [TestCase(1001)]
        [TestCase(int.MaxValue)]
        [Description("[異常] 渡された値が最小値未満または最大値より大きい場合に、スローが投げられること")]
        public void InvalidEnemyHP(int value) {
            var exception = Assert.Throws<ArgumentException>(() => {
                EnemyHP enemyHP = EnemyHP.Of(value);
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

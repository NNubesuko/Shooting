using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using KataokaLib.ValueObject;

namespace Tests {

    [Description("敵の移動倍率のテスト")]
    public class EnemyMoveSpeedMagnificationTest {

        [Test]
        [TestCase(0f)]
        [TestCase(5f)]
        [TestCase(10f)]
        [Description("[正常] 渡された値が最小値以上かつ最大値以下である場合に、正常に格納されること")]
        public void ValidEnemyMoveSpeedMagnification(float value) {
            EnemyMoveSpeedMagnification enemyMoveSpeedMagnification =
                EnemyMoveSpeedMagnification.Of(value);
            
            Assert.That(
                enemyMoveSpeedMagnification,
                Is.EqualTo(EnemyMoveSpeedMagnification.Of(value))
            );
        }

        [Test]
        [TestCase(float.MinValue)]
        [TestCase(-1f)]
        [TestCase(11f)]
        [TestCase(float.MaxValue)]
        [Description("[異常] 渡された値が最小値未満または最大値より大きい場合に、スローが投げられること")]
        public void InvalidEnemyMoveSpeedMagnification(float value) {
            var exception = Assert.Throws<ArgumentException>(() => {
                EnemyMoveSpeedMagnification enemyMoveSpeedMagnification =
                    EnemyMoveSpeedMagnification.Of(value);
            });

            Assert.That(
                exception.Message,
                Is.EqualTo(
                    ValueObjectExceptionHandler.ArgumentException(nameof(value)).Message
                )
            );
        }

        [Test]
        [Description("[正常] 二次元ベクトルと乗算した場合に、二次元ベクトルが格納されていること")]
        public void ValidEnemyMoveSpeedMul(
            [Values(0f, 5f, 10f)] float value,
            [Values(0f, 1f, 5)] float x,
            [Values(0f, 1f, 5f)] float y
        ) {
            EnemyMoveSpeedMagnification enemyMoveSpeedMagnification =
                EnemyMoveSpeedMagnification.Of(value);
            Vector2 vector2 = new Vector2(x, y);
            Vector2 moveSpeedMagnificationMulVector2 = enemyMoveSpeedMagnification * vector2;

            Assert.That(
                moveSpeedMagnificationMulVector2,
                Is.EqualTo(value * new Vector2(x, y))
            );
        }

    }

}

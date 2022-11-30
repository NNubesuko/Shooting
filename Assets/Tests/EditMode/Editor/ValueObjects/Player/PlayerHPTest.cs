using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using KataokaLib.ValueObject;

namespace Tests {

    [Description("プレイヤーの体力のテスト")]
    public class PlayerHPTest {

        [Test]
        [TestCase(0)]
        [TestCase(50)]
        [TestCase(100)]
        [Description("[正常] 渡された値が最小値以上かつ最大値以下である場合に、正常に格納されること")]
        public void ValidPlayerHP(int value) {
            PlayerHP playerHP = PlayerHP.Of(value);
            Assert.That(playerHP, Is.EqualTo(PlayerHP.Of(value)));
        }

        [Test]
        [TestCase(int.MinValue)]
        [TestCase(-1)]
        [TestCase(101)]
        [TestCase(int.MaxValue)]
        [Description("[異常] 渡された値が最小値未満または最大値より大きい場合に、スローが投げられること")]
        public void InvalidPlayerHP(int value) {
            var exception = Assert.Throws<ArgumentException>(() => {
                PlayerHP playerHP = PlayerHP.Of(value);
            });

            Assert.That(
                exception.Message,
                Is.EqualTo(
                    ValueObjectExceptionHandler.ArgumentException(nameof(value)).Message
                )
            );
        }

        [Test]
        [TestCase(100, 10)]
        [TestCase(50, 50)]
        [TestCase(20, 10)]
        [Description("[正常] 攻撃力と減算した場合に、プレイヤーの体力が格納されること")]
        public void ValidPlayerHPSubAP(int hp, int ap) {
            PlayerHP playerHP = PlayerHP.Of(hp);
            EnemyAP enemyAP = EnemyAP.Of(ap);
            PlayerHP plyaerHPSubAp = playerHP - enemyAP;

            Assert.That(
                plyaerHPSubAp,
                Is.EqualTo(
                    PlayerHP.Of(hp - ap)
                )
            );
        }

        [Test]
        [TestCase(80, 100)]
        [TestCase(50, 100)]
        [TestCase(0, 100)]
        [Description(
            "[正常] 攻撃力と減算した結果が最小値より小さい場合に、プレイヤー体力の最小値が格納されること"
        )]
        public void ValidPlayerHPSubAPOverMin(int hp, int ap) {
            PlayerHP playerHP = PlayerHP.Of(hp);
            EnemyAP enemyAP = EnemyAP.Of(ap);
            PlayerHP playerHPSubAp = playerHP - enemyAP;

            Assert.That(
                playerHPSubAp,
                Is.EqualTo(PlayerHP.Of(playerHPSubAp.MIN))
            );
        }

    }

}
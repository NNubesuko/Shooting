using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using KataokaLib.ValueObject;

namespace Tests {

    [Description("プレイヤーのスコアのテスト")]
    public class PlayerScoreTest {

        [Test]
        [TestCase(0)]
        [TestCase(50)]
        [TestCase(int.MaxValue)]
        [Description("[正常] 渡された値が最小値以上かつ最大値以下である場合に、正常に格納されること")]
        public void ValidPlayerScore(int value) {
            PlayerScore playerScore = PlayerScore.Of(value);
            Assert.That(playerScore, Is.EqualTo(PlayerScore.Of(value)));
        }

        [Test]
        [TestCase(int.MinValue)]
        [TestCase(-1)]
        [Description("[異常] 渡された値が最小値未満または最大値より大きい場合に、スローが投げられること")]
        public void InvalidPlayerScore(int value) {
            var exception = Assert.Throws<ArgumentException>(() => {
                PlayerScore playerScore = PlayerScore.Of(value);
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

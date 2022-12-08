using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using KataokaLib.ValueObject;

namespace Tests {

    [Description("プレイヤーの水平移動範囲のテスト")]
    public class PlayerHorizontalMoveRangeTest {

        [Test]
        [TestCase(-5f, 5f)]
        [TestCase(0f, 5f)]
        [TestCase(-10f, 10f)]
        [Description("[正常] 渡された値が最小値以上かつ最大値以下である場合に、正常に格納されること")]
        public void ValidPlayerHorizontalMoveRange(float start, float end) {
            PlayerHorizontalMoveRange playerHorizontalMoveRange =
                PlayerHorizontalMoveRange.Of(start, end);
        }

        [Test]
        [TestCase(float.MinValue, 0f)]
        [TestCase(-11f, 0f)]
        [TestCase(-11f, 11f)]
        [TestCase(0f, 11f)]
        [TestCase(0f, float.MaxValue)]
        [TestCase(float.MinValue, float.MaxValue)]
        [Description("[異常] 渡された値が最小値未満または最大値より大きい場合に、スローが投げられること")]
        public void InvalidPlayerHorizontalMoveRange(float start, float end) {
            var exception = Assert.Throws<ArgumentException>(() => {
                PlayerHorizontalMoveRange playerHorizontalMoveRange =
                    PlayerHorizontalMoveRange.Of(start, end);
            });

            Assert.That(
                exception.Message,
                Is.EqualTo(
                    ValueObjectExceptionHandler.ArgumentException(
                        nameof(start) + ", " + nameof(end)
                    ).Message
                )
            );
        }

    }

}

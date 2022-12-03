using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using KataokaLib.ValueObject;

namespace Tests {

    [Description("銃弾数のテスト")]
    public class BulletsCountTest {

        [Test]
        [TestCase(0)]
        [TestCase(50)]
        [TestCase(300)]
        [Description("[正常] 渡された値が最小値以上かつ最大値以下である場合に、正常に格納されること")]
        public void ValidBulletsCount(int value) {
            BulletsCount bulletsCount = BulletsCount.Of(value);
            Assert.That(bulletsCount, Is.EqualTo(BulletsCount.Of(value)));
        }

        [Test]
        [TestCase(int.MinValue)]
        [TestCase(-1)]
        [TestCase(301)]
        [TestCase(int.MaxValue)]
        [Description("[異常] 渡された値が最小値未満または最大値より大きい場合に、スローが投げられること")]
        public void InvalidBulletsCount(int value) {
            var exception = Assert.Throws<ArgumentException>(() => {
                BulletsCount bulletsCount = BulletsCount.Of(value);
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

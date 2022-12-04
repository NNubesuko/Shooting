using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using KataokaLib.ValueObject;

namespace Tests {

    public class BulletsMaxCountTest {

        [Test]
        [TestCase(0)]
        [TestCase(100)]
        [TestCase(int.MaxValue)]
        [Description("[正常] 渡された値が最小値以上かつ最大値以下である場合に、正常に格納されること")]
        public void ValidBulletsMaxCount(int value) {
            BulletsMaxCount bulletsMaxCount = BulletsMaxCount.Of(value);
            Assert.That(bulletsMaxCount, Is.EqualTo(BulletsMaxCount.Of(value)));
        }

        [Test]
        [TestCase(int.MinValue)]
        [TestCase(-1)]
        [Description("[異常] 渡された値が最小値未満または最大値より大きい場合に、スローが投げられること")]
        public void InvalidBulletsMaxCount(int value) {
            var exception = Assert.Throws<ArgumentException>(() => {
                BulletsMaxCount bulletsMaxCount = BulletsMaxCount.Of(value);
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

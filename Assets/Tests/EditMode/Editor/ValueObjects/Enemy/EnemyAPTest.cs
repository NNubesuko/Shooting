using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using KataokaLib.ValueObject;

namespace Tests {

    public class EnemyAPTest {

        [Test]
        [TestCase(0)]
        [TestCase(50)]
        [TestCase(100)]
        public void ValidEnemyAP(int value) {
            EnemyAP enemyAP = EnemyAP.Of(value);
            Assert.That(enemyAP, Is.EqualTo(EnemyAP.Of(value)));
        }

        [Test]
        [TestCase(int.MinValue)]
        [TestCase(-1)]
        [TestCase(101)]
        [TestCase(int.MaxValue)]
        public void InvalidEnemyAP(int value) {
            var exception = Assert.Throws<ArgumentException>(() => {
                EnemyAP enemyAP = EnemyAP.Of(value);
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

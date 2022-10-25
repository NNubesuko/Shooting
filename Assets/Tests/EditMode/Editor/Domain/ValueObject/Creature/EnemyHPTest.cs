using System;
using System.Collections;
using System.Collections.Generic;
using Systemk;
using Systemk.Exceptions;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests {

    [Description("敵の体力のテスト")]
    public class EnemyHPTest {

        [Test]
        [TestCase(0)]
        [TestCase(50)]
        [TestCase(100)]
        [Description("[正常] 渡された値が最小値以上最大値以下である場合に、値が正常に格納されること")]
        public void ValidEnemyHP(int value) {
            EnemyHP enemyHP = EnemyHP.Of(value);
            Assert.That(enemyHP.Value, Is.EqualTo(value));
        }

    }

}

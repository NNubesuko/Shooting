using System;
using System.Runtime.InteropServices;
using Systemk;
using Systemk.Exceptions;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests {

    [Description("敵のテスト")]
    public class EnemyTest {

        // [Test]
        // [TestCase(100, 100, 25, 100)]
        // [Description("[正常] 生成した敵のパラメータが正常の場合に、敵が格納されること")]
        // public void ValidEnemy(int hp, int ap, int speed, int point) {
        //     EnemyHP enemyHP = EnemyHP.Of(hp);
        //     EnemyAP enemyAP = EnemyAP.Of(ap);
        //     EnemyMoveSpeed enemyMoveSpeed = EnemyMoveSpeed.Of(speed);
        //     EnemyPoint enemyPoint = EnemyPoint.Of(point);
        //     Enemy enemy = Enemy.Generate(enemyHP, enemyAP, enemyMoveSpeed, enemyPoint);

        //     Assert.That(enemy.HP, Is.EqualTo(enemyHP));
        //     Assert.That(enemy.AP, Is.EqualTo(enemyAP));
        //     Assert.That(enemy.Speed, Is.EqualTo(enemyMoveSpeed));
        // }

        // [Test]
        // [TestCase(-100, 100, 25, 100)]
        // [TestCase(100, -100, 25, 100)]
        // [TestCase(100, 100, -25, 100)]
        // [TestCase(100, 100, 25, -100)]
        // [Description("[異常] 生成した敵のパラメータが異常の場合に、スローが投げられること")]
        // public void InvalidEnemy(int hp, int ap, int speed, int point) {
        //     var exception = Assert.Throws<ArgumentException>(() => {
        //         EnemyHP enemyHP = EnemyHP.Of(hp);
        //         EnemyAP enemyAP = EnemyAP.Of(ap);
        //         EnemyMoveSpeed enemyMoveSpeed = EnemyMoveSpeed.Of(speed);
        //         EnemyPoint enemyPoint = EnemyPoint.Of(point);
        //         Enemy enemy = Enemy.Generate(enemyHP, enemyAP, enemyMoveSpeed, enemyPoint);
        //     });

        //     Assert.That(
        //         exception.Message,
        //         Is.EqualTo(ExceptionMessage.argumentExceptionMessage)
        //     );
        // }
    
    }

}

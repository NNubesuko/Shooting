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

        [Test]
        [TestCase(100, 100, 25)]
        [Description("[正常] 生成した敵のパラメータが正常の場合に、敵が格納されること")]
        public void ValidEnemy(int hp, int ap, int speed) {
            // todo: オブジェクト単位の比較？
            // 単体テストで比較のテストを行っていないため不安がある
            // todo: 数値を取り出してプリミティブ型の比較？
            // 結合テストの段階でプリミティブ型の比較をしていたらきりがない
            // * -> 単体テストに比較テストを追加し、オブジェクト同士の比較ですむようにすればアクセスする
            // * 数値の深さを浅くすることができる

            EnemyHP enemyHP = EnemyHP.Of(hp);
            EnemyAP enemyAP = EnemyAP.Of(ap);
            EnemyMoveSpeed enemyMoveSpeed = EnemyMoveSpeed.Of(speed);
            Enemy enemy = Enemy.Generate(enemyHP, enemyAP, enemyMoveSpeed);

            Assert.That(enemy.HP, Is.EqualTo(enemyHP));
            Assert.That(enemy.AP, Is.EqualTo(enemyAP));
            Assert.That(enemy.Speed, Is.EqualTo(enemyMoveSpeed));
        }

        [Test]
        [TestCase(-100, 100, 25)]
        [TestCase(100, -100, 25)]
        [TestCase(100, 100, -25)]
        [Description("[異常] 生成した敵のパラメータが異常の場合に、スローが投げられること")]
        public void InvalidEnemy(int hp, int ap, int speed) {
            var exception = Assert.Throws<ArgumentException>(() => {
                EnemyHP enemyHP = EnemyHP.Of(hp);
                EnemyAP enemyAP = EnemyAP.Of(ap);
                EnemyMoveSpeed enemyMoveSpeed = EnemyMoveSpeed.Of(speed);
                Enemy enemy = Enemy.Generate(enemyHP, enemyAP, enemyMoveSpeed);
            });

            Assert.That(
                exception.Message,
                Is.EqualTo(ExceptionMessage.argumentExceptionMessage)
            );
        }
    
    }

}

using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.TestTools.Utils;
using UnityEngine.SceneManagement;
using Systemk;

namespace Tests {

    [Description("敵の動作テスト")]
    public class EnemyTest {

        private GameObject enemyObject = null;
        private EnemyMain enemyScript = null;
        private Vector2[] moveTargetTable = {
            new Vector2(0f, 3f),
            new Vector2(5f, -4.5f),
            new Vector2(-5f, -4.5f)
        };

        [OneTimeSetUp]
        public void OneTimeSetUp() {
            SceneManager.LoadSceneAsync("Stage1").completed += _ => {
                enemyObject = GameObject.Find("Enemy");
                enemyScript = enemyObject.GetComponent<EnemyMain>();
            };
        }

        [UnityTest]
        [Order(1)]
        [Description("[正常] 敵オブジェクトが存在する場合に、変数に格納されること")]
        public IEnumerator EnemyObjectExists() {
            Assert.That(enemyObject, Is.Not.Null);
            yield return null;
        }

        [UnityTest]
        [Order(2)]
        [Description("[正常] 敵スクリプトが存在する場合に、変数に格納されること")]
        public IEnumerator EnemyScriptExists() {
            Assert.That(enemyScript, Is.Not.Null);
            yield return null;
        }

        [UnityTest]
        [Order(3)]
        [Description("[正常] 敵のステータスが初期化された場合に、正常に格納されること")]
        public IEnumerator ValidEnemyStatus() {
            EnemyHP enemyHP = EnemyHP.Of(20);
            EnemyAP enemyAP = EnemyAP.Of(10);
            EnemyMoveSpeed enemyMoveSpeed = EnemyMoveSpeed.Of(3f);
            EnemyMoveSpeedMagnification magnification = EnemyMoveSpeedMagnification.Of(1.5f);

            enemyScript.Init(
                enemyHP,
                enemyAP,
                enemyMoveSpeed,
                magnification,
                moveTargetTable
            );

            Assert.That(enemyScript.HP, Is.EqualTo(enemyHP));
            Assert.That(enemyScript.AP, Is.EqualTo(enemyAP));
            Assert.That(enemyScript.MoveSpeed, Is.EqualTo(enemyMoveSpeed));
            Assert.That(enemyScript.MoveTargetTable, Is.EqualTo(moveTargetTable));
            yield return null;
        }

        [UnityTest]
        [Order(4)]
        [Description("[正常] 順に座標が指定された場合に、座標周辺に移動すること")]
        public IEnumerator ValidMove() {
            int tableIndex = 0;
            var comparer = new Vector2EqualityComparer(1f);

            while (enemyScript.MoveTargetTable.Length > tableIndex) {
                yield return new WaitForSeconds(3f);
                Assert.That(
                    (Vector2)enemyObject.transform.position,
                    Is.EqualTo(enemyScript.MoveTargetTable[tableIndex]).Using(comparer)
                );
                tableIndex++;
            }

            yield return null;
        }

        [UnityTest]
        [Order(5)]
        [Description("[正常] プレイヤーに攻撃された場合に、体力が攻撃力分減少していること")]
        public IEnumerator AttacksFromPlayer() {
            BulletMain bulletScript = GameObject.Find("Bullet").GetComponent<BulletMain>();

            EnemyHP lastHP = enemyScript.HP;
            yield return new WaitUntil(() => {
                return bulletScript.wasAttacked;
            });
            EnemyHP currentHP = enemyScript.HP;

            Assert.That(currentHP, Is.LessThan(lastHP));
        }

    }

}
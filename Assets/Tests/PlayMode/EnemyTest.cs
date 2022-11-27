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
            EnemyMoveSpeed enemyMoveSpeed = EnemyMoveSpeed.Of(5f);

            enemyScript.Init(
                enemyHP,
                enemyAP,
                enemyMoveSpeed
            );

            Assert.That(enemyScript.HP, Is.EqualTo(enemyHP));
            Assert.That(enemyScript.AP, Is.EqualTo(enemyAP));
            Assert.That(enemyScript.MoveSpeed, Is.EqualTo(enemyMoveSpeed));
            yield return null;
        }

    }

}
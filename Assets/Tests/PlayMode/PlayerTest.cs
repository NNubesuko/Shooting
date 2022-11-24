using System.Collections;
using System.Collections.Generic;
using Systemk;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

namespace Tests {

    [Description("プレイヤーの動作テスト")]
    public class PlayerTest {

        private GameObject playerObject = null;
        private Player playerScript = null;

        [OneTimeSetUp]
        public void OneTimeSetUp() {
            SceneManager.LoadSceneAsync("Stage1").completed += _ => {
                playerObject = GameObject.Find("Player");
                playerScript = playerObject.GetComponent<PlayerMain>();
            };
        }

        [UnityTest]
        [Order(1)]
        [Description("[正常] プレイヤーオブジェクトが存在する場合に、変数に格納されること")]
        public IEnumerator PlayerObjectExists() {
            Assert.That(playerObject, Is.Not.Null);
            yield return null;
        }

        [UnityTest]
        [Order(2)]
        [Description("[正常] プレイヤースクリプトが存在する場合に、変数に格納されること")]
        public IEnumerator PlayerScriptExists() {
            Assert.That(playerScript, Is.Not.Null);
            yield return null;
        }

        [UnityTest]
        [Order(3)]
        [Description(
            "[正常] プレイヤーのステータスがインスペクターから渡された場合に、正常に初期化されること"
        )]
        public IEnumerator ValidPlayerStatus() {
            PlayerHP hp = PlayerHP.Of(100);
            PlayerStamina stamina = PlayerStamina.Of(100f);
            PlayerMoveSpeed moveSpeed = PlayerMoveSpeed.Of(5f);
            PlayerEvasionSpeed evasionSpeed = PlayerEvasionSpeed.Of(20f);

            Assert.That(playerScript.HP, Is.EqualTo(hp));
            Assert.That(playerScript.Stamina, Is.EqualTo(stamina));
            Assert.That(playerScript.MoveSpeed, Is.EqualTo(moveSpeed));
            Assert.That(playerScript.EvasionSpeed, Is.EqualTo(evasionSpeed));
            yield return null;
        }

    }

}

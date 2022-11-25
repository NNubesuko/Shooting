using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.TestTools.Utils;
using UnityEngine.SceneManagement;
using Systemk;

namespace Tests {

    [Description("プレイヤーの動作テスト")]
    public class PlayerTest {

        private GameObject playerObject = null;
        private Player playerScript = null;
        private Vector2 lastPosition = default;
        private Vector2 currentPosition = default;
        private const float Vector2Tolerance = 0.001f;

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

        [UnityTest]
        [Order(4)]
        [Description(
            "[正常] 上移動するキーを入力した場合に、プレイヤーが単位円のY軸の1に移動すること"
        )]
        public IEnumerator UpKeyToMovePlayer() {
            yield return new WaitUntil(() => {
                lastPosition = playerObject.transform.position;
                return Inputk.GetAxis() == Vector2.up;
            });
            // 入力された１フレーム後に移動処理が実行されるため、１フレーム待つ
            yield return null;
            currentPosition = playerObject.transform.position;
            Vector2 diffPosition = currentPosition - lastPosition;
            
            // 実数の演算では、誤差が出るため許容値を設定する
            var comparer = new Vector2EqualityComparer(Vector2Tolerance);
            Assert.That(
                diffPosition.normalized,
                Is.EqualTo(Vector2.up).Using(comparer)
            );
        }

        [UnityTest]
        [Order(5)]
        [Description(
            "[正常] 左移動するキーを入力した場合に、プレイヤーが単位円のX軸の-1に移動すること"
        )]
        public IEnumerator LeftKeyToMovePlayer() {
            yield return new WaitUntil(() => {
                lastPosition = playerObject.transform.position;
                return Inputk.GetAxis() == Vector2.left;
            });
            yield return null;
            currentPosition = playerObject.transform.position;
            Vector2 diffPosition = currentPosition - lastPosition;
            
            var comparer = new Vector2EqualityComparer(Vector2Tolerance);
            Assert.That(
                diffPosition.normalized,
                Is.EqualTo(Vector2.left).Using(comparer)
            );
        }

        [UnityTest]
        [Order(6)]
        [Description(
            "[正常] 下移動するキーを入力した場合に、プレイヤーが単位円のY軸の-1に移動すること"
        )]
        public IEnumerator DownKeyToMovePlayer() {
            yield return new WaitUntil(() => {
                lastPosition = playerObject.transform.position;
                return Inputk.GetAxis() == Vector2.down;
            });
            yield return null;
            currentPosition = playerObject.transform.position;
            Vector2 diffPosition = currentPosition - lastPosition;
            
            var comparer = new Vector2EqualityComparer(Vector2Tolerance);
            Assert.That(
                diffPosition.normalized,
                Is.EqualTo(Vector2.down).Using(comparer)
            );
        }

        [UnityTest]
        [Order(7)]
        [Description(
            "[正常] 右移動するキーを入力した場合に、プレイヤーが単位円のX軸の1に移動すること"
        )]
        public IEnumerator RightKeyToMovePlayer() {
            yield return new WaitUntil(() => {
                lastPosition = playerObject.transform.position;
                return Inputk.GetAxis() == Vector2.right;
            });
            yield return null;
            currentPosition = playerObject.transform.position;
            Vector2 diffPosition = currentPosition - lastPosition;
            
            var comparer = new Vector2EqualityComparer(Vector2Tolerance);
            Assert.That(
                diffPosition.normalized,
                Is.EqualTo(Vector2.right).Using(comparer)
            );
        }

        [UnityTest]
        [Order(8)]
        [Description(
            "[正常] 上と左移動するキーを入力した場合に、プレイヤーが単位円のY軸1とX軸-1の間に移動すること"
        )]
        public IEnumerator UpAndLeftKeyToMovePlayer() {
            yield return new WaitUntil(() => {
                lastPosition = playerObject.transform.position;
                return Inputk.GetAxis() == (Vector2.up + Vector2.left).normalized;
            });
            yield return null;
            currentPosition = playerObject.transform.position;
            Vector2 diffPosition = currentPosition - lastPosition;
            
            var comparer = new Vector2EqualityComparer(Vector2Tolerance);
            Assert.That(
                diffPosition.normalized,
                Is.EqualTo((Vector2.up + Vector2.left).normalized).Using(comparer)
            );
        }

        [UnityTest]
        [Order(9)]
        [Description(
            "[正常] 左と下移動するキーを入力した場合に、プレイヤーが単位円のX軸-1とY軸-1の間に移動すること"
        )]
        public IEnumerator LeftAndDownKeyToMovePlayer() {
            yield return new WaitUntil(() => {
                lastPosition = playerObject.transform.position;
                return Inputk.GetAxis() == (Vector2.left + Vector2.down).normalized;
            });
            yield return null;
            currentPosition = playerObject.transform.position;
            Vector2 diffPosition = currentPosition - lastPosition;
            
            var comparer = new Vector2EqualityComparer(Vector2Tolerance);
            Assert.That(
                diffPosition.normalized,
                Is.EqualTo((Vector2.left + Vector2.down).normalized).Using(comparer)
            );
        }

        [UnityTest]
        [Order(10)]
        [Description(
            "[正常] 左と下移動するキーを入力した場合に、プレイヤーが単位円のX軸-1とY軸-1の間に移動すること"
        )]
        public IEnumerator DownAndRightKeyToMovePlayer() {
            yield return new WaitUntil(() => {
                lastPosition = playerObject.transform.position;
                return Inputk.GetAxis() == (Vector2.down + Vector2.right).normalized;
            });
            yield return null;
            currentPosition = playerObject.transform.position;
            Vector2 diffPosition = currentPosition - lastPosition;
            
            var comparer = new Vector2EqualityComparer(Vector2Tolerance);
            Assert.That(
                diffPosition.normalized,
                Is.EqualTo((Vector2.down + Vector2.right).normalized).Using(comparer)
            );
        }

        [UnityTest]
        [Order(11)]
        [Description(
            "[正常] 左と下移動するキーを入力した場合に、プレイヤーが単位円のX軸-1とY軸-1の間に移動すること"
        )]
        public IEnumerator RightAndUpKeyToMovePlayer() {
            yield return new WaitUntil(() => {
                lastPosition = playerObject.transform.position;
                return Inputk.GetAxis() == (Vector2.right + Vector2.up).normalized;
            });
            yield return null;
            currentPosition = playerObject.transform.position;
            Vector2 diffPosition = currentPosition - lastPosition;
            
            var comparer = new Vector2EqualityComparer(Vector2Tolerance);
            Assert.That(
                diffPosition.normalized,
                Is.EqualTo((Vector2.right + Vector2.up).normalized).Using(comparer)
            );
        }

    }

}

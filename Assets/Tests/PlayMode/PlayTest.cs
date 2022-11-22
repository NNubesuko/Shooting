// using System.Collections;
// using System.Collections.Generic;
// using Systemk;
// using NUnit.Framework;
// using UnityEngine;
// using UnityEngine.TestTools;
// using UnityEngine.SceneManagement;

// public class PlayTest {

//     private GameObject playerObject;
//     private Player playerScript;
//     private Vector2 lastPosition;
//     private Vector2 currentPosition;

//     [OneTimeSetUp]
//     public void InitializeTest() {
//         SceneManager.LoadSceneAsync("Stage1").completed += _ => {
//             playerObject = GameObject.Find("Player");
//             playerScript = playerObject.GetComponent<Player>();
//         };
//     }

//     [UnityTest]
//     [Order(1)]
//     [Description("[正常] プレイヤーオブジェクトが存在している場合に、変数に格納されていること")]
//     public IEnumerator PlayerObjectExists() {
//         Assert.That(playerObject, Is.Not.Null);
//         yield return null;
//     }

//     [UnityTest]
//     [Order(2)]
//     [Description("[正常] プレイヤースクリプトが存在している場合に、変数に格納されていること")]
//     public IEnumerator PlayerScriptExists() {
//         Assert.That(playerScript, Is.Not.Null);
//         yield return null;
//     }

//     [UnityTest]
//     [Order(3)]
//     [Description("[正常] ゲーム上のプレイヤーのステータスが、インスペクター上の数値と一致すること")]
//     public IEnumerator PlayerStatusAndInspectorValueMatch() {
//         PlayerHP hp = PlayerHP.Of(100);
//         PlayerStamina stamina = PlayerStamina.Of(100f);
//         PlayerMoveSpeed moveSpeed = PlayerMoveSpeed.Of(5);
//         PlayerEvasiveSpeed evasiveSpeed = PlayerEvasiveSpeed.Of(25);
//         PlayerMoveRange moveHorizontalRange = PlayerMoveRange.Of(-8.4f, 8.4f);
//         PlayerMoveRange moveVerticalRange = PlayerMoveRange.Of(-4.5f, 4.5f);
//         PlayerScore score = PlayerScore.Of(0);

//         Assert.That(playerScript.HP, Is.EqualTo(hp));
//         Assert.That(playerScript.Stamina, Is.EqualTo(stamina));
//         Assert.That(playerScript.MoveSpeed, Is.EqualTo(moveSpeed));
//         Assert.That(playerScript.EvasiveSpeed, Is.EqualTo(evasiveSpeed));
//         Assert.That(playerScript.MoveHorizontalRange, Is.EqualTo(moveHorizontalRange));
//         Assert.That(playerScript.MoveVerticalRange, Is.EqualTo(moveVerticalRange));
//         Assert.That(playerScript.Score, Is.EqualTo(score));
//         yield return null;
//     }

//     [UnityTest]
//     [Order(4)]
//     [Description("[正常] スコアが追加された場合に、追加された分のスコアが格納されていること")]
//     public IEnumerator ProcessingAddScoreNormal() {
//         PlayerScore responseFirstScore = PlayerScore.Of(10);
//         PlayerScore responseSecondScore = PlayerScore.Of(50);
//         PlayerScore responseThridScore = PlayerScore.Of(105);

//         PlayerScore firstAddScore = PlayerScore.Of(10);
//         PlayerScore secondAddScore = PlayerScore.Of(40);
//         PlayerScore thridAddScore = PlayerScore.Of(55);

//         playerScript.AddScore(firstAddScore);
//         Assert.That(playerScript.Score, Is.EqualTo(responseFirstScore));

//         playerScript.AddScore(secondAddScore);
//         Assert.That(playerScript.Score, Is.EqualTo(responseSecondScore));

//         playerScript.AddScore(thridAddScore);
//         Assert.That(playerScript.Score, Is.EqualTo(responseThridScore));
//         yield return null;
//     }
    
//     [UnityTest]
//     [Order(5)]
//     [Description("[正常] ダメージを受けた場合に、ダメージを受けた分体力が減少していること")]
//     public IEnumerator ProcessingDamageNormal() {
//         PlayerHP responseFirstHP = PlayerHP.Of(90);
//         PlayerHP responseSecondHP = PlayerHP.Of(85);
//         PlayerHP responseThridHP = PlayerHP.Of(35);

//         int firstDamage = 10;
//         int secondDamage = 5;
//         int thridDamage = 50;

//         playerScript.Damage(firstDamage);
//         Assert.That(playerScript.HP, Is.EqualTo(responseFirstHP));

//         playerScript.Damage(secondDamage);
//         Assert.That(playerScript.HP, Is.EqualTo(responseSecondHP));

//         playerScript.Damage(thridDamage);
//         Assert.That(playerScript.HP, Is.EqualTo(responseThridHP));
//         yield return null;
//     }

//     [UnityTest]
//     [Order(6)]
//     [Description("[正常] 上に移動するキーを入力した場合に、上に移動していること")]
//     public IEnumerator UpKeyToMovePlayer() {
//         yield return new WaitUntil(() => {
//             lastPosition = playerObject.transform.position;
//             return Inputk.GetAxis() == Vector2.up;
//         });
//         // 入力が来てから、1フレーム経ったときに移動判定が来るため、1フレーム待つ
//         yield return null;
//         currentPosition = playerObject.transform.position;
//         // * 差分の正規化された値が上方向のものであれば、上方向に移動していると判定できるため差分を取得する
//         Vector2 diffPosition = currentPosition - lastPosition;

//         Assert.That(diffPosition.normalized, Is.EqualTo(Vector2.up));
//     }

//     [UnityTest]
//     [Order(7)]
//     [Description("[正常] 下に移動するキーを入力した場合に、下に移動していること")]
//     public IEnumerator DownKeyToMovePlayer() {
//         yield return new WaitUntil(() => {
//             lastPosition = playerObject.transform.position;
//             return Inputk.GetAxis() == Vector2.down;
//         });
//         // 入力が来てから、1フレーム経ったときに移動判定が来るため、1フレーム待つ
//         yield return null;
//         currentPosition = playerObject.transform.position;
//         // * 差分の正規化された値が上方向のものであれば、上方向に移動していると判定できるため差分を取得する
//         Vector2 diffPosition = currentPosition - lastPosition;

//         Assert.That(diffPosition.normalized, Is.EqualTo(Vector2.down));
//     }

//     [UnityTest]
//     [Order(8)]
//     [Description("[正常] 左に移動するキーを入力した場合に、左に移動していること")]
//     public IEnumerator LeftKeyToMovePlayer() {
//         yield return new WaitUntil(() => {
//             lastPosition = playerObject.transform.position;
//             return Inputk.GetAxis() == Vector2.left;
//         });
//         // 入力が来てから、1フレーム経ったときに移動判定が来るため、1フレーム待つ
//         yield return null;
//         currentPosition = playerObject.transform.position;
//         // * 差分の正規化された値が上方向のものであれば、上方向に移動していると判定できるため差分を取得する
//         Vector2 diffPosition = currentPosition - lastPosition;

//         Assert.That(diffPosition.normalized, Is.EqualTo(Vector2.left));
//     }

//     [UnityTest]
//     [Order(9)]
//     [Description("[正常] 右に移動するキーを入力した場合に、右に移動していること")]
//     public IEnumerator RihgtKeyToMovePlayer() {
//         yield return new WaitUntil(() => {
//             lastPosition = playerObject.transform.position;
//             return Inputk.GetAxis() == Vector2.right;
//         });
//         // 入力が来てから、1フレーム経ったときに移動判定が来るため、1フレーム待つ
//         yield return null;
//         currentPosition = playerObject.transform.position;
//         // * 差分の正規化された値が上方向のものであれば、上方向に移動していると判定できるため差分を取得する
//         Vector2 diffPosition = currentPosition - lastPosition;

//         Assert.That(diffPosition.normalized, Is.EqualTo(Vector2.right));
//     }
    
//     [UnityTest]
//     [Order(100)]
//     [Description("[正常] 体力が0になった場合に、プレイヤーオブジェクトが非アクティブ状態になっていること")]
//     public IEnumerator PlayerObjectInactiveWhenPlayerHPIsZero() {
//         playerScript.Damage(PlayerHP.MAX);

//         yield return null;
//         // プレイヤーの体力が0になってから、1フレーム経ったときに死亡判定が来るため、1フレーム待ち判定を行う
//         Assert.That(GameObject.Find("Player"), Is.Null);
//     }

// }

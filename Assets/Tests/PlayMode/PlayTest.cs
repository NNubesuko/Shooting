using System.Collections;
using System.Collections.Generic;
using Systemk;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

public class PlayTest : NUnitAttribute, IOuterUnityTestAction {

    private GameObject playerObject;
    private Player playerScript;

    [OneTimeSetUp]
    public void InitializeTest() {
        SceneManager.LoadSceneAsync("Stage1").completed += _ => {
            playerObject = GameObject.Find("Player");
            playerScript = playerObject.GetComponent<Player>();
        };
    }

    public IEnumerator BeforeTest(ITest test) {
        Debug.Log("Before Test");
        yield break;
    }

    public IEnumerator AfterTest(ITest test) {
        Debug.Log("After Test");
        yield break;
    }

    [UnityTest]
    [Order(1)]
    [Description("[正常] プレイヤーオブジェクトが存在している場合に、変数に格納されていること")]
    public IEnumerator PlayerObjectExists() {
        Assert.That(playerObject, Is.Not.Null);
        yield return null;
    }

    [UnityTest]
    [Order(2)]
    [Description("[正常] プレイヤースクリプトが存在している場合に、変数に格納されていること")]
    public IEnumerator PlayerScriptExists() {
        Assert.That(playerScript, Is.Not.Null);
        yield return null;
    }

    [UnityTest]
    [Order(3)]
    [Description("[正常] ゲーム上のプレイヤーのステータスが、インスペクター上の数値と一致すること")]
    public IEnumerator PlayerStatusAndInspectorValueMatch() {
        PlayerHP hp = PlayerHP.Of(100);
        PlayerStamina stamina = PlayerStamina.Of(100f);
        PlayerMoveSpeed moveSpeed = PlayerMoveSpeed.Of(5);
        PlayerEvasiveSpeed evasiveSpeed = PlayerEvasiveSpeed.Of(25);
        PlayerMoveRange moveHorizontalRange = PlayerMoveRange.Of(-8.4f, 8.4f);
        PlayerMoveRange moveVerticalRange = PlayerMoveRange.Of(-4.5f, 4.5f);
        PlayerScore score = PlayerScore.Of(0);

        Assert.That(playerScript.HP, Is.EqualTo(hp));
        Assert.That(playerScript.Stamina, Is.EqualTo(stamina));
        Assert.That(playerScript.MoveSpeed, Is.EqualTo(moveSpeed));
        Assert.That(playerScript.EvasiveSpeed, Is.EqualTo(evasiveSpeed));
        Assert.That(playerScript.MoveHorizontalRange, Is.EqualTo(moveHorizontalRange));
        Assert.That(playerScript.MoveVerticalRange, Is.EqualTo(moveVerticalRange));
        Assert.That(playerScript.Score, Is.EqualTo(score));
        yield return null;
    }

    [UnityTest]
    [Order(4)]
    [Description("[正常] スコアが追加された場合に、追加された分のスコアが格納されていること")]
    public IEnumerator ProcessingAddScoreNormal() {
        PlayerScore responseFirstScore = PlayerScore.Of(10);
        PlayerScore responseSecondScore = PlayerScore.Of(50);
        PlayerScore responseThridScore = PlayerScore.Of(105);

        PlayerScore firstAddScore = PlayerScore.Of(10);
        PlayerScore secondAddScore = PlayerScore.Of(40);
        PlayerScore thridAddScore = PlayerScore.Of(55);

        playerScript.AddScore(firstAddScore);
        Assert.That(playerScript.Score, Is.EqualTo(responseFirstScore));

        playerScript.AddScore(secondAddScore);
        Assert.That(playerScript.Score, Is.EqualTo(responseSecondScore));

        playerScript.AddScore(thridAddScore);
        Assert.That(playerScript.Score, Is.EqualTo(responseThridScore));
        yield return null;
    }
    
    [UnityTest]
    [Order(5)]
    [Description("[正常] ダメージを受けた場合に、ダメージを受けた分体力が減少していること")]
    public IEnumerator ProcessingDamageNormal() {
        PlayerHP responseFirstHP = PlayerHP.Of(90);
        PlayerHP responseSecondHP = PlayerHP.Of(85);
        PlayerHP responseThridHP = PlayerHP.Of(35);

        int firstDamage = 10;
        int secondDamage = 5;
        int thridDamage = 50;

        playerScript.Damage(firstDamage);
        Assert.That(playerScript.HP, Is.EqualTo(responseFirstHP));

        playerScript.Damage(secondDamage);
        Assert.That(playerScript.HP, Is.EqualTo(responseSecondHP));

        playerScript.Damage(thridDamage);
        Assert.That(playerScript.HP, Is.EqualTo(responseThridHP));
        yield return null;
    }

    [UnityTest]
    [Order(6)]
    [Description("[正常] 上に移動するキーを入力した場合に、上に移動していること")]
    public IEnumerator UpKeyToMovePlayer() {
        Vector2 lastPosition = default;
        yield return new WaitUntil(() => {
            lastPosition = playerObject.transform.position;
            return Inputk.GetAxis() == Vector2.up;
        });
        yield return null;
        // 入力が来てから、1フレーム経ったときに移動判定が来るため、1フレーム待ち判定を行う
        Vector2 currentPosition = playerObject.transform.position;
        Assert.That(currentPosition.y, Is.GreaterThan(lastPosition.y));
    }

    [UnityTest]
    [Order(7)]
    [Description("[正常] 下に移動するキーを入力した場合に、下に移動していること")]
    public IEnumerator DownKeyToMovePlayer() {
        Vector2 lastPosition = default;
        yield return new WaitUntil(() => {
            lastPosition = playerObject.transform.position;
            return Inputk.GetAxis() == Vector2.down;
        });
        yield return null;
        Vector2 currentPosition = playerObject.transform.position;
        Assert.That(currentPosition.y, Is.LessThan(lastPosition.y));
    }

    [UnityTest]
    [Order(8)]
    [Description("[正常] 左に移動するキーを入力した場合に、左に移動していること")]
    public IEnumerator LeftKeyToMovePlayer() {
        Vector2 lastPosition = default;
        yield return new WaitUntil(() => {
            lastPosition = playerObject.transform.position;
            return Inputk.GetAxis() == Vector2.left;
        });
        yield return null;
        Vector2 currentPosition = playerObject.transform.position;
        Assert.That(currentPosition.x, Is.LessThan(lastPosition.x));
    }

    [UnityTest]
    [Order(9)]
    [Description("[正常] 右に移動するキーを入力した場合に、右に移動していること")]
    public IEnumerator RihgtKeyToMovePlayer() {
        Vector2 lastPosition = default;
        yield return new WaitUntil(() => {
            lastPosition = playerObject.transform.position;
            return Inputk.GetAxis() == Vector2.right;
        });
        yield return null;
        Vector2 currentPosition = playerObject.transform.position;
        Assert.That(currentPosition.x, Is.GreaterThan(lastPosition.x));
    }
    
    [UnityTest]
    [Order(100)]
    [Description("[正常] 体力が0になった場合に、プレイヤーオブジェクトが非アクティブ状態になっていること")]
    public IEnumerator PlayerObjectInactiveWhenPlayerHPIsZero() {
        playerScript.Damage(PlayerHP.MAX);

        yield return null;
        // プレイヤーの体力が0になってから、1フレーム経ったときに死亡判定が来るため、1フレーム待ち判定を行う
        Assert.That(GameObject.Find("Player"), Is.Null);
    }

}

using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

public class PlayTest {

    private Player player;

    [OneTimeSetUp]
    public void InitializeTest() {
        SceneManager.LoadSceneAsync("Stage1").completed += _ => {
            player = GameObject.Find("Player").GetComponent<Player>();
        };
    }

    [UnityTest]
    [Order(-100)]
    [Description("[正常] プレイヤースクリプトが存在している場合に、変数に格納されていること")]
    public IEnumerator PlayerObjectExists() {
        Assert.That(player, Is.Not.Null);
        yield return null;
    }

    [UnityTest]
    [Order(1)]
    [Description("[正常] ゲーム上のプレイヤーのステータスが、インスペクター上の数値と一致すること")]
    public IEnumerator PlayerStatusAndInspectorValueMatch() {
        PlayerHP hp = PlayerHP.Of(100);
        PlayerStamina stamina = PlayerStamina.Of(100f);
        PlayerMoveSpeed moveSpeed = PlayerMoveSpeed.Of(5);
        PlayerEvasiveSpeed evasiveSpeed = PlayerEvasiveSpeed.Of(25);
        PlayerMoveRange moveHorizontalRange = PlayerMoveRange.Of(-8.4f, 8.4f);
        PlayerMoveRange moveVerticalRange = PlayerMoveRange.Of(-4.5f, 4.5f);
        PlayerScore score = PlayerScore.Of(0);

        Assert.That(player.HP, Is.EqualTo(hp));
        Assert.That(player.Stamina, Is.EqualTo(stamina));
        Assert.That(player.MoveSpeed, Is.EqualTo(moveSpeed));
        Assert.That(player.EvasiveSpeed, Is.EqualTo(evasiveSpeed));
        Assert.That(player.MoveHorizontalRange, Is.EqualTo(moveHorizontalRange));
        Assert.That(player.MoveVerticalRange, Is.EqualTo(moveVerticalRange));
        Assert.That(player.Score, Is.EqualTo(score));
        yield return null;
    }

    [UnityTest]
    [Order(2)]
    [Description("[正常] スコアが追加された場合に、追加された分のスコアが格納されていること")]
    public IEnumerator ProcessingAddScoreNormal() {
        PlayerScore responseFirstScore = PlayerScore.Of(10);
        PlayerScore responseSecondScore = PlayerScore.Of(50);
        PlayerScore responseThridScore = PlayerScore.Of(105);

        PlayerScore firstAddScore = PlayerScore.Of(10);
        PlayerScore secondAddScore = PlayerScore.Of(40);
        PlayerScore thridAddScore = PlayerScore.Of(55);

        player.AddScore(firstAddScore);
        Assert.That(player.Score, Is.EqualTo(responseFirstScore));

        player.AddScore(secondAddScore);
        Assert.That(player.Score, Is.EqualTo(responseSecondScore));

        player.AddScore(thridAddScore);
        Assert.That(player.Score, Is.EqualTo(responseThridScore));
        yield return null;
    }
    
    [UnityTest]
    [Order(3)]
    [Description("[正常] ダメージを受けた場合に、ダメージを受けた分体力が減少していること")]
    public IEnumerator ProcessingDamageNormal() {
        PlayerHP responseFirstHP = PlayerHP.Of(90);
        PlayerHP responseSecondHP = PlayerHP.Of(85);
        PlayerHP responseThridHP = PlayerHP.Of(35);

        int firstDamage = 10;
        int secondDamage = 5;
        int thridDamage = 50;

        player.Damage(firstDamage);
        Assert.That(player.HP, Is.EqualTo(responseFirstHP));

        player.Damage(secondDamage);
        Assert.That(player.HP, Is.EqualTo(responseSecondHP));

        player.Damage(thridDamage);
        Assert.That(player.HP, Is.EqualTo(responseThridHP));
        yield return null;
    }
    
    [UnityTest]
    [Order(4)]
    [Description("[正常] 体力が0になった場合に、プレイヤーオブジェクトが非アクティブ状態になっていること")]
    public IEnumerator PlayerObjectInactiveWhenPlayerHPIsZero() {
        player.Damage(PlayerHP.MAX);

        yield return null;
        // プレイヤーの体力が0になってから、1フレーム経ったときに死亡判定が来るため、ここで判定を行う
        Assert.That(GameObject.Find("Player"), Is.Null);
    }

}

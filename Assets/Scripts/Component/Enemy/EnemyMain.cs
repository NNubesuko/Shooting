using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMain : TriggerObject {

    private float magnification;
    private float moveTargetSwitchingInterval;
    private Vector2[] moveTargetTable;

    private Enemy enemy;
    private Player player;

    private void OnEnable() {
        StartCoroutine(enemy.TableControl(moveTargetTable, moveTargetSwitchingInterval));
    }

    private void Update() {
        enemy.Move(transform, magnification);

        if (enemy.HP.Value == 0) {
            // プレイヤーから攻撃され体力が０になった場合のみ、スコアを加算する
            player.AddScore(PlayerScore.Of(enemy.Point.Value));
            this.gameObject.SetActive(false);
        }
    }

    public void Init(
        EnemyHP enemyHP,
        EnemyAP enemyAP,
        EnemyMoveSpeed enemyMoveSpeed,
        EnemyPoint enemyPoint,
        float magnification,
        float moveTargetSwitchingInterval,
        Vector2[] moveTargetTable,
        Player player
    ) {
        enemy = Enemy.Generate(enemyHP, enemyAP, enemyMoveSpeed, enemyPoint);
        this.magnification = magnification;
        this.moveTargetSwitchingInterval = moveTargetSwitchingInterval;
        this.moveTargetTable = moveTargetTable;
        this.player = player;
    }

    public Enemy Enemy {
        get { return enemy; }
    }

    protected override void OnTriggerEnter2DEvent(Collider2D collider) {
        GameObject gameObject = collider.gameObject;

        if (gameObject.name == "DownWall") {
            this.gameObject.SetActive(false);
        }

        if (gameObject.CompareTag("Player")) {
            Player playerScript = gameObject.GetComponent<PlayerMain>().Player;
            playerScript.SubHP(PlayerHP.Of(enemy.AP.Value));
        }
    }

    private void OnDisable() {
        enemy = null;
        GC.Collect();
    }

}

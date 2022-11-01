using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMain : TriggerObject {

    // TODO: ValueObjectのEnemyPointを実装する

    // [SerializeField] private int hp;
    // [SerializeField] private int ap;
    // [SerializeField] private int moveSpeed;
    // [SerializeField] private float magnification;
    // [SerializeField] private float moveTargetSwitchingInterval;
    // [SerializeField] private Vector2[] moveTargetTable;

    private float magnification;
    private float moveTargetSwitchingInterval;
    private Vector2[] moveTargetTable;

    private Enemy enemy;
    private PlayerUI playerUI;

    private void OnEnable() {
        StartCoroutine(enemy.TableControl(moveTargetTable, moveTargetSwitchingInterval));
        playerUI = GameObject.Find("GameAdmin").GetComponent<PlayerUI>();
    }

    private void Update() {
        enemy.Move(transform, magnification);

        if (enemy.HP.Value == 0) {
            playerUI.AddScore(10);
            this.gameObject.SetActive(false);
        }
    }

    public void Init(
        EnemyHP enemyHP,
        EnemyAP enemyAP,
        EnemyMoveSpeed enemyMoveSpeed,
        float magnification,
        float moveTargetSwitchingInterval,
        Vector2[] moveTargetTable
    ) {
        enemy = Enemy.Generate(enemyHP, enemyAP, enemyMoveSpeed);
        this.magnification = magnification;
        this.moveTargetSwitchingInterval = moveTargetSwitchingInterval;
        this.moveTargetTable = moveTargetTable;
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

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMain : TriggerObject {

    [SerializeField] private int hp;
    [SerializeField] private int ap;
    [SerializeField] private int moveSpeed;
    [SerializeField] private float magnification;
    [SerializeField] private Vector2[] moveTargetTable;

    private Enemy enemy = null;

    private void OnEnable() {
        StartCoroutine(enemy.TableControl(moveTargetTable, 2f));
    }

    private void Update() {
        enemy.Move(transform, magnification);

        if (enemy.HP.Value == 0) {
            this.gameObject.SetActive(false);
        }
    }

    public void SetMagnification(float magnification) {
        this.magnification = magnification;
    }

    public void SetMoveTargetTable(Vector2[] moveTargetTable) {
        this.moveTargetTable = moveTargetTable;
    }

    public Enemy Enemy {
        get { return enemy; }
        set { enemy = value; }
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

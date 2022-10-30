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

    private Enemy enemy;

    private void Awake() {
        enemy = Enemy.Generate(
            EnemyHP.Of(hp),
            EnemyAP.Of(ap),
            EnemyMoveSpeed.Of(moveSpeed)
        );
        StartCoroutine(enemy.TableControl(moveTargetTable, 2f));
    }

    private void Update() {
        enemy.Move(transform, magnification);

        if (enemy.HP.Value == 0) {
            Destroy(this.gameObject);
        }
    }

    public Enemy Enemy {
        get { return enemy; }
    }

    protected override void OnTriggerEnter2DEvent(Collider2D collider) {
        if (collider.gameObject.CompareTag("Player")) {
        }
    }

    private void OnDestroy() {
        enemy = null;
        GC.Collect();
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMain : EnemyImpl {

    private Vector2[] moveTargetTable = {
        new Vector2(0f, 3f),
        new Vector2(3f, -3f),
        new Vector2(-3f, -3f)
    };

    private void Awake() {
        Init(
            EnemyHP.Of(20),
            EnemyAP.Of(10),
            EnemyMoveSpeed.Of(3f),
            EnemyMoveSpeedMagnification.Of(2f),
            moveTargetTable
        );
    }

    private void Update() {
        Move();
    }

    protected override void OnTriggerEnter2DEvent(Collider2D collider) {
        GameObject gameObject = collider.gameObject;
        wasAttacked = gameObject.name.Equals("Player");
        
        Attack(gameObject.GetComponent<PlayerMain>());
    }

}

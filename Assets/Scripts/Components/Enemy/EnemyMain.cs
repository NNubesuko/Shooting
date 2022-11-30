using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMain : EnemyImpl {

    private Vector2[] moveTargetTable = {
        new Vector2(0f, 3f),
        new Vector2(5f, -4.5f),
        new Vector2(-5f, -4.5f)
    };

    private void Awake() {
        Init(
            EnemyHP.Of(20),
            EnemyAP.Of(10),
            EnemyMoveSpeed.Of(3f),
            EnemyMoveSpeedMagnification.Of(1.5f),
            moveTargetTable
        );
    }

    private void Update() {
        Move();
    }

}

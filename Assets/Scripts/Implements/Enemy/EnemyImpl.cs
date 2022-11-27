using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyImpl : MonoBehaviour, Enemy {

    public EnemyHP HP { get; private set; }
    public EnemyAP AP { get; private set; }
    public EnemyMoveSpeed MoveSpeed { get; private set; }

    public void Init(
        EnemyHP hp,
        EnemyAP ap,
        EnemyMoveSpeed moveSpeed
    ) {
        HP = hp;
        AP = ap;
        MoveSpeed = moveSpeed;
    }

    public void Move() {
    }

}

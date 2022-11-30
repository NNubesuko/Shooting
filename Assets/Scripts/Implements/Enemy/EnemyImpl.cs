using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Systemk;

public class EnemyImpl : MonoBehaviour, Enemy {

    public EnemyHP HP { get; private set; }
    public EnemyAP AP { get; private set; }
    public EnemyMoveSpeed MoveSpeed { get; private set; }
    public EnemyMoveSpeedMagnification Magnification { get; private set; }
    public Vector2[] MoveTargetTable { get; private set; }

    private Timer tableChangeTimer;
    private Vector2 target;
    private Vector2 p;
    private int index = 0;

    public void Init(
        EnemyHP hp,
        EnemyAP ap,
        EnemyMoveSpeed moveSpeed,
        EnemyMoveSpeedMagnification magnification,
        Vector2[] moveTargetTable
    ) {
        HP = hp;
        AP = ap;
        MoveSpeed = moveSpeed;
        Magnification = magnification;
        MoveTargetTable = moveTargetTable;
        tableChangeTimer = new Timer(3f);
    }

    public void Move() {
        target = MoveTargetTable[index];

        Vector2 velocity = transform.position;
        p += MoveSpeed * (target - velocity) * Time.deltaTime;
        p -= Magnification * p * Time.deltaTime;
        velocity += p * Time.deltaTime;
        transform.position = velocity;

        tableChangeTimer.Update(() => {
            tableChangeTimer.Reset();
            index = (index + 1) % MoveTargetTable.Length;
        });
    }

}

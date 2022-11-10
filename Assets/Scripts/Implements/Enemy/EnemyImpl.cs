using System.Collections;
using System.Collections.Generic;
using Systemk.Util;
using UnityEngine;

public class EnemyImpl : TriggerObject, Enemy {

    public EnemyHP HP { get; private set; }
    public EnemyAP AP { get; private set; }
    public EnemyMoveSpeed MoveSpeed { get; private set; }
    public EnemyPoint Point { get; private set; }
    public float Magnification { get; private set; }
    public float MoveTargetSwitchingInterval { get; private set; }
    public Vector2[] MoveTargetTable { get; private set; }
    public Player Player { get; private set; }

    private Vector2 target;
    private Vector2 p;

    public virtual void Init(
        EnemyHP hp,
        EnemyAP ap,
        EnemyMoveSpeed moveSpeed,
        EnemyPoint point,
        float magnification,
        float moveTargetSwitchingInterval,
        Vector2[] moveTargetTable,
        Player player
    ) {
        HP = hp;
        AP = ap;
        MoveSpeed = moveSpeed;
        Point = point;
        Magnification = magnification;
        MoveTargetSwitchingInterval = moveTargetSwitchingInterval;
        MoveTargetTable = moveTargetTable;
        Player = player;
    }

    public virtual void Move() {
        Vector2 velocity = transform.position;
        p += (target - velocity) * MoveSpeed.Value * Time.deltaTime;
        p -= p * Magnification * Time.deltaTime;
        velocity += p * Time.deltaTime;
        transform.position = velocity;
    }

    public virtual void Damage(int value) {
        HP -= EnemyHP.Of(value);
    }

    public virtual void Death() {
        if (HP.Value == 0) {
            Player.AddScore(PlayerScore.Of(Point.Value));
            this.gameObject.SetActive(false);
        }
    }

    protected IEnumerator TableControl() {
        int index = 0;
        while (true) {
            target = MoveTargetTable[index];
            yield return new WaitForSeconds(MoveTargetSwitchingInterval);
            index = (index + 1) % MoveTargetTable.Length;
        }
    }

}
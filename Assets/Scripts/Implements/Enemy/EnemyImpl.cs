using System.Collections;
using System.Collections.Generic;
using Systemk.Util;
using UnityEngine;

public class EnemyImpl : TriggerObject, Enemy {

    protected EnemyHP hp;
    protected EnemyAP ap;
    protected EnemyMoveSpeed moveSpeed;
    protected EnemyPoint point;

    protected Vector2 target;
    protected Vector2 p;
    protected float magnification;
    protected float moveTargetSwitchingInterval;
    protected Vector2[] moveTargetTable;
    protected Player player;

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
        this.hp = hp;
        this.ap = ap;
        this.moveSpeed = moveSpeed;
        this.point = point;
        this.magnification = magnification;
        this.moveTargetSwitchingInterval = moveTargetSwitchingInterval;
        this.moveTargetTable = moveTargetTable;
        this.player = player;
    }

    public virtual void Move() {
        Vector2 velocity = transform.position;
        p += (target - velocity) * moveSpeed.Value * Time.deltaTime;
        p -= p * magnification * Time.deltaTime;
        velocity += p * Time.deltaTime;
        transform.position = velocity;
    }

    public virtual void Death() {
        if (hp.Value == 0) {
            player.AddScore(PlayerScore.Of(point.Value));
            this.gameObject.SetActive(false);
        }
    }

    public virtual void SubHP(EnemyHP subHP) {
        hp -= subHP;
    }

    protected IEnumerator TableControl() {
        int index = 0;
        while (true) {
            target = moveTargetTable[index];
            yield return new WaitForSeconds(moveTargetSwitchingInterval);
            index = (index + 1) % moveTargetTable.Length;
        }
    }

}
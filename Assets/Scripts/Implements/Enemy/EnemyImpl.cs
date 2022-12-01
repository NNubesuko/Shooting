using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Systemk;
using Systemk.Util;

public class EnemyImpl : TriggerObject, Enemy {

    public EnemyHP HP { get; private set; }
    public EnemyAP AP { get; private set; }
    public EnemyMoveSpeed MoveSpeed { get; private set; }
    public EnemyMoveSpeedMagnification Magnification { get; private set; }
    public Vector2[] MoveTargetTable { get; private set; }

    public bool wasAttacked { get; protected set; }

    private Timer tableChangeTimer;
    private Vector2 target;
    private Vector2 p;
    private int index = 0;

    /*
     * ステータスを初期化するメソッド
     */
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

    /*
     * 通常移動のメソッド
     */
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

    /*
     * ダメージのメソッド, IDamagableより実装
     */
    public void Damage(AP ap) {
        HP -= ap;
    }
    
    /*
     * 死亡時のメソッド, IDamagableより実装
     */
    public void Death() {
        if (HP == EnemyHP.Of(0)) {
            gameObject.SetActive(false);
        }
    }

    /*
     * 通常攻撃のメソッド
     */
    public void Attack(Player player) {
        player.Damage(AP);
    }

    /*
     * 敵オブジェクトが非アクティブになった場合のメソッド
     */
    private void OnDisable() {
        HP = null;
        AP = null;
        MoveSpeed = null;
        Magnification = null;
        MoveTargetTable = null;

        tableChangeTimer = null;

        GC.Collect();
    }

}

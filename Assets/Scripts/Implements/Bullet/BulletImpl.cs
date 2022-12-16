using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KataokaLib.System;

public class BulletImpl : TriggerObject, Bullet {

    public BulletAP AP { get; private set; }
    public BulletMoveSpeed MoveSpeed { get; private set; }

    public bool wasAttacked { get; protected set; }

    public void Init(
        BulletAP ap,
        BulletMoveSpeed moveSpeed
    ) {
        AP = ap;
        MoveSpeed = moveSpeed;
    }

    public void Move() {
        Vector2 velocity = transform.position;
        velocity.y += MoveSpeed * Time.deltaTime;
        transform.position = velocity;
    }

    public void Attack(Enemy enemy) {
        enemy.Damage(AP);
    }

    private void OnDisable() {
        AP = null;
        MoveSpeed = null;

        GC.Collect();
    }

}

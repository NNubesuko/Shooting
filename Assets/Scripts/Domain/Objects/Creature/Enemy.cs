using System;
using Systemk;
using Systemk.Exceptions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class Enemy {

    private EnemyHP hp;
    private EnemyAP ap;
    private EnemyMoveSpeed speed;

    private Vector2 target;
    private Vector2 p;

    private Enemy(EnemyHP hp, EnemyAP ap, EnemyMoveSpeed speed) {
        this.hp = hp;
        this.ap = ap;
        this.speed = speed;
    }

    public static Enemy Generate(EnemyHP hp, EnemyAP ap, EnemyMoveSpeed speed) {
        return new Enemy(hp, ap, speed);
    }

    public void Move(Transform transform, float magnification) {
        Vector2 velocity = transform.position;
        p += (target - velocity) * speed.Value * Time.deltaTime;
        p -= p * magnification * Time.deltaTime;
        velocity += p * Time.deltaTime;
        transform.position = velocity;
    }

    public void SubHP(EnemyHP subHP) {
        hp -= subHP;
    }

    public IEnumerator TableControl(Vector2[] moveTargetTable, float moveTargetSwitchingInterval) {
        int index = 0;
        while (true) {
            target = moveTargetTable[index];
            yield return new WaitForSeconds(moveTargetSwitchingInterval);
            index = (index + 1) % moveTargetTable.Length;
        }
    }

    public EnemyHP HP {
        get { return hp; }
    }

    public EnemyAP AP {
        get { return ap; }
    }

    public EnemyMoveSpeed Speed {
        get { return speed; }
    }

    public override string ToString() {
        return $"HP: {hp}, AP: {ap}, Speed: {speed}";
    }

    public override int GetHashCode() {
        return (hp, ap, speed).GetHashCode();
    }

    public override bool Equals(object obj) {
        return obj is Enemy other && this.Equals(other);
    }

    public bool Equals(Enemy other) {
        return this.GetHashCode() == other.GetHashCode();
    }

    public static bool operator==(Enemy lhEnemy, Enemy rhEnemy) {
        return lhEnemy.Equals(rhEnemy);
    }

    public static bool operator!=(Enemy lhEnemy, Enemy rhEnemy) {
        return !(lhEnemy == rhEnemy);
    }

}

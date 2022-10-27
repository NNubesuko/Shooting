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

    private Enemy(EnemyHP hp, EnemyAP ap, EnemyMoveSpeed speed) {
        this.hp = hp;
        this.ap = ap;
        this.speed = speed;
    }

    public static Enemy Generate(EnemyHP hp, EnemyAP ap, EnemyMoveSpeed speed) {
        return new Enemy(hp, ap, speed);
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

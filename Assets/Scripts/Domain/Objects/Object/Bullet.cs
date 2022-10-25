using System;
using Systemk;
using Systemk.Exceptions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class Bullet {

    private BulletType type;
    private BulletAP ap;
    private BulletSpeed speed;

    private static Dictionary<BulletType, Bullet> bulletDict =
    new Dictionary<BulletType, Bullet>() {
        {
            BulletType.Normal,
            new Bullet(
                BulletType.Normal,
                BulletAP.Of(10),
                BulletSpeed.Of(7)
            )
        },
        {
            BulletType.Head,
            new Bullet(
                BulletType.Head,
                BulletAP.Of(50),
                BulletSpeed.Of(3)
            )
        }
    };

    private Bullet(BulletType type, BulletAP ap, BulletSpeed speed) {
        this.type = type;
        this.ap = ap;
        this.speed = speed;
    }

    public static Bullet Generate(BulletType type) {
        return bulletDict[type];
    }

    public BulletType Type {
        get { return type; }
    }

    public BulletAP AP {
        get { return ap; }
    }

    public BulletSpeed Speed {
        get { return speed; }
    }

    public override string ToString() {
        return $"Type: {type}, AP: {ap}, Speed: {speed}";
    }

    public override int GetHashCode() {
        return (type, ap, speed).GetHashCode();
    }

    public override bool Equals(object obj) {
        return obj is Bullet other && this.Equals(other);
    }

    public bool Equals(Bullet other) {
        return this.GetHashCode() == other.GetHashCode();
    }

}
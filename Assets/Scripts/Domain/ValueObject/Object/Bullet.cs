using System;
using Systemk;
using System.Collections;
using System.Collections.Generic;

public sealed class Bullet {

    private BulletType type;
    private BulletAP ap;
    private BulletSpeed speed;

    private Bullet(BulletType type, BulletAP ap, BulletSpeed speed) {
        this.type = type;
        this.ap = ap;
        this.speed = speed;
    }

    public static Bullet Of(BulletType type) {
        return bulletDict[type];
    }

    private static Dictionary<BulletType, Bullet> bulletDict = new Dictionary<BulletType, Bullet>() {
        {
            BulletType.Normal,
            new Bullet(
                BulletType.Normal,
                BulletAP.Of(10),
                BulletSpeed.Of(25)
            )
        },
        {
            BulletType.Head,
            new Bullet(
                BulletType.Head,
                BulletAP.Of(50),
                BulletSpeed.Of(10)
            )
        }
    };

    public BulletType Type {
        get { return type; }
    }

    public BulletAP AP {
        get { return ap; }
    }

    public BulletSpeed Speed {
        get { return speed; }
    }

}

public enum BulletType {
    Normal,
    Head
}
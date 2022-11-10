using System.Collections;
using System.Collections.Generic;
using Systemk.Util;
using UnityEngine;

public class BulletImpl : TriggerObject, Bullet {

    public BulletInfo Info { get; private set; }

    private Dictionary<BulletType, BulletInfo> bulletDict =
    new Dictionary<BulletType, BulletInfo>() {
        {
            BulletType.Normal,
            new BulletInfo(
                BulletType.Normal,
                BulletAP.Of(10),
                BulletSpeed.Of(7)
            )
        },
        {
            BulletType.Head,
            new BulletInfo(
                BulletType.Normal,
                BulletAP.Of(50),
                BulletSpeed.Of(3)
            )
        }
    };

    public virtual void Init(BulletType type) {
        Info = bulletDict[type];
    }

    public virtual void Move() {
        Vector3 velocity = transform.position;
        velocity.y += Info.Speed.Value * Time.deltaTime;
        transform.position = velocity;
    }

    public struct BulletInfo {
        public BulletType Type { get; private set; }
        public BulletAP AP { get; private set; }
        public BulletSpeed Speed { get; private set; }

        public BulletInfo(BulletType type, BulletAP ap, BulletSpeed speed) {
            Type = type;
            AP = ap;
            Speed = speed;
        }
    }

}

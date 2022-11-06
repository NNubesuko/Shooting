using System.Collections;
using System.Collections.Generic;
using Systemk.Util;
using UnityEngine;

public class BulletImpl : TriggerObject, Bullet {

    protected BulletInfo info;

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
        info = bulletDict[type];
    }

    public virtual void Move() {
        Vector3 velocity = transform.position;
        velocity.y += info.speed.Value * Time.deltaTime;
        transform.position = velocity;
    }

    protected struct BulletInfo {
        public BulletType type;
        public BulletAP ap;
        public BulletSpeed speed;

        public BulletInfo(BulletType type, BulletAP ap, BulletSpeed speed) {
            this.type = type;
            this.ap = ap;
            this.speed = speed;
        }
    }

}

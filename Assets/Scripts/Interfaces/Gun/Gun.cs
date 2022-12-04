using System.Collections.Generic;
using UnityEngine;

public interface Gun {

    GameObject BulletObject { get; }
    BulletsMaxCount MaxCount { get; }
    BulletsCount Count { get; }
    GunFiringRate Rate { get; }

    void Init(
        GameObject bulletObject,
        BulletsMaxCount maxCount,
        GunFiringRate rate
    );

    void Fire();

}
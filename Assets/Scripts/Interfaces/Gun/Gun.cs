using System.Collections.Generic;
using UnityEngine;

public interface Gun {

    GameObject BulletObject { get; }
    BulletsCount Count { get; }
    List<GameObject> Bullets { get; }
    GunFiringRate Rate { get; }

    void Init(
        GameObject bulletObject,
        BulletsCount count,
        GunFiringRate rate
    );

    void Fire();

}
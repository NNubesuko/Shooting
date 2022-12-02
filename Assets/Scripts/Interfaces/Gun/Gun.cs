using System.Collections.Generic;
using UnityEngine;

public interface Gun {

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
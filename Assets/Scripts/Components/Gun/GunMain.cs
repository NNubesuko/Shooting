using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunMain : GunImpl {

    [SerializeField] private GameObject bulletObject;
    [SerializeField] private int bulletsCount;
    [SerializeField] private float firingRate;

    private void Awake() {
        Init(
            bulletObject,
            BulletsCount.Of(bulletsCount),
            GunFiringRate.Of(firingRate)
        );
    }

    private void Update() {
        Fire();
    }

}

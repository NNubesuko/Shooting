using UnityEngine;

public class GunMain : GunImpl {

    [SerializeField] private GameObject bulletObject;
    [SerializeField] private int bulletsMaxCount;
    [SerializeField] private float firingRate;

    private void Awake() {
        Init(
            bulletObject,
            BulletsMaxCount.Of(bulletsMaxCount),
            GunFiringRate.Of(firingRate)
        );
    }

    private void Update() {
        Fire();
    }

}

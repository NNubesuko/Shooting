using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunImpl : MonoBehaviour, Gun {

    public BulletsCount Count { get; private set; }
    public List<GameObject> Bullets { get; private set; } = new List<GameObject>();
    public GunFiringRate Rate { get; private set; }

    public void Init(
        GameObject bulletObject,
        BulletsCount count,
        GunFiringRate rate
    ) {
        Count = count;

        for (int i = 0; Count > i; i++) {
            GameObject bullet =
                Instantiate(bulletObject, this.transform.position, Quaternion.identity);
            bullet.transform.parent = this.gameObject.transform;
            Bullets.Add(bullet);
        }

        Rate = rate;
    }

    public void Fire() {
    }

}

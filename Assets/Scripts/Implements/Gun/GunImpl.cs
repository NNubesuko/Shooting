using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Systemk;

public class GunImpl : MonoBehaviour, Gun {

    public GameObject BulletObject { get; private set; }
    public BulletsCount Count { get; private set; }
    public List<GameObject> Bullets { get; private set; } = new List<GameObject>();
    public GunFiringRate Rate { get; private set; }

    private float currentTime = 0f;

    public void Init(
        GameObject bulletObject,
        BulletsCount count,
        GunFiringRate rate
    ) {
        BulletObject = bulletObject;
        Count = count;

        for (int i = 0; Count > i; i++) {
            GameObject bullet =
                Instantiate(BulletObject, this.transform.position, Quaternion.identity);
            bullet.transform.parent = this.gameObject.transform;
            bullet.SetActive(false);
            Bullets.Add(bullet);
        }

        Rate = rate;
    }

    public void Fire() {
        if (Bullets.Count == 0) return;

        currentTime += Time.deltaTime;

        if (Inputk.GetKeyDown(KeyCode.Return) && Rate <= currentTime) {
            FireHelper();
        }

        if (Inputk.GetKey(KeyCode.Return) && Rate <= currentTime) {
            FireHelper();
        }
    }

    private void FireHelper() {
        currentTime = 0f;
        Bullets[0].transform.parent = null;
        Bullets[0].SetActive(true);
        Bullets.Remove(Bullets[0]);
    }

}

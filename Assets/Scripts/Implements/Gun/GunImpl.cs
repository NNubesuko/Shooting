using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Systemk;

public class GunImpl : MonoBehaviour, Gun {

    public GameObject BulletObject { get; private set; }
    public BulletsMaxCount MaxCount { get; private set; }
    public BulletsCount Count { get; private set; } = BulletsCount.Of(0);
    public GunFiringRate Rate { get; private set; }

    private float currentTime = 0f;
    private Quaternion identity = Quaternion.identity;

    public void Init(
        GameObject bulletObject,
        BulletsMaxCount maxCount,
        GunFiringRate rate
    ) {
        BulletObject = bulletObject;
        MaxCount = maxCount;
        Rate = rate;
    }

    public void Fire() {
        if (Count >= MaxCount) return;

        currentTime += Time.deltaTime;

        if (Inputk.GetKeyDown(KeyCode.Return) && Rate <= currentTime) {
            FireHelper();
        }

        if (Inputk.GetKey(KeyCode.Return) && Rate <= currentTime) {
            FireHelper();
        }
    }

    private void FireHelper() {
        Count++;
        currentTime = 0;
        Instantiate(BulletObject, transform.position, identity);
    }

    /*
     * 銃オブジェクトが非アクティブになった場合のメソッド
     ! GameAdmin専用
     */
    public void OnGameOver() {
        BulletObject = null;
        MaxCount = null;
        Count = null;
        Rate = null;

        GC.Collect();
    }

}

using System;
using Systemk;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalBulletMain : TriggerObject {

    private Bullet bullet;

    private void Awake() {
        bullet = Bullet.Generate(BulletType.Normal);
    }

    private void Update() {
        Vector3 velocity = transform.position;
        velocity.y += bullet.Speed.Value * Time.deltaTime;
        transform.position = velocity;
    }

    protected override void OnTriggerEnterAndStay2DEvent(Collider2D collider) {
        if (collider.gameObject.CompareTag("Enemy")) {
            Destroy(collider.gameObject);
            Destroy(this.gameObject);
        }

        if (collider.gameObject.CompareTag("Wall")) {
            Destroy(this.gameObject);
        }
    }

    private void OnDestroy() {
        bullet = null;
        GC.Collect();
    }

}

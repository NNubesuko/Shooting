using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMain : TriggerObject {

    [SerializeField] private int type;

    private Bullet bullet;

    private void Awake() {
        bullet = Bullet.Generate(BulletType.Of(type));
    }

    private void Update() {
        Vector3 velocity = transform.position;
        velocity.y += bullet.Speed.Value * Time.deltaTime;
        transform.position = velocity;
    }

    protected override void OnTriggerEnterAndStay2DEvent(Collider2D collider) {
        if (bullet == null) return;
        if (transform.parent != null) return;

        if (collider.gameObject.CompareTag("Enemy")) {
            Enemy enemyScript = collider.GetComponent<EnemyMain>().Enemy;
            enemyScript.SubHP(EnemyHP.Of(bullet.AP.Value));
            this.gameObject.SetActive(false);
        }

        if (collider.gameObject.CompareTag("Wall")) {
            this.gameObject.SetActive(false);
        }
    }

    private void OnDisable() {
        bullet = null;
        GC.Collect();
    }

}

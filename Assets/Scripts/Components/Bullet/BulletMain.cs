using System;
using System.Collections;
using System.Collections.Generic;
using Systemk.Util;
using UnityEngine;

public class BulletMain : BulletImpl {

    [SerializeField] private int t;

    private void Awake() {
        Init(BulletType.Of(t));
    }

    private void Update() {
        Move();
    }

    protected override void OnTriggerEnterAndStay2DEvent(Collider2D collider) {
        if (transform.parent != null) return;

        if (collider.gameObject.CompareTag("Enemy")) {
            Enemy enemyScript = collider.GetComponent<EnemyMain>();
            enemyScript.SubHP(EnemyHP.Of(info.ap.Value));
            this.gameObject.SetActive(false);
        }

        if (collider.gameObject.CompareTag("Wall")) {
            this.gameObject.SetActive(false);
        }
    }

}

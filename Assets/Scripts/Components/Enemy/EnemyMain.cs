using System;
using System.Collections;
using System.Collections.Generic;
using Systemk.Util;
using UnityEngine;

public class EnemyMain : EnemyImpl {

    private void OnEnable() {
        StartCoroutine(TableControl());
    }

    private void Update() {
        Move();
        Death();
    }

    protected override void OnTriggerEnter2DEvent(Collider2D collider) {
        GameObject gameObject = collider.gameObject;

        if (gameObject.name == "DownWall") {
            this.gameObject.SetActive(false);
        }

        if (gameObject.CompareTag("Player")) {
            Player.SubHP(PlayerHP.Of(AP.Value));
        }
    }

    private void OnDisable() {
        GC.Collect();
    }

}

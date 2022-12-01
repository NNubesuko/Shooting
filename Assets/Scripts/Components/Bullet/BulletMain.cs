using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMain : BulletImpl {

    private void Awake() {
        Init(
            BulletAP.Of(10),
            BulletMoveSpeed.Of(7f)
        );
    }

    private void Update() {
        Move();
    }

    protected override void OnTriggerEnterAndStay2DEvent(Collider2D collider) {
        GameObject gameObject = collider.gameObject;
        wasAttacked = gameObject.CompareTag("Enemy");

        if (wasAttacked) {
            Attack(gameObject.GetComponent<EnemyMain>());
        }

        this.gameObject.SetActive(false);
    }

}

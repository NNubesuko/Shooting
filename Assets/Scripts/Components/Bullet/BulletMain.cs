using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMain : BulletImpl {

    [SerializeField] private int ap;
    [SerializeField] private float moveSpeed;

    private void Awake() {
        Init(
            BulletAP.Of(ap),
            BulletMoveSpeed.Of(moveSpeed)
        );
    }

    private void Update() {
        Move();
    }

    protected override void OnTriggerEnterAndStay2DEvent(Collider2D collider) {
        GameObject gameObject = collider.gameObject;

        if (gameObject.CompareTag("Enemy")) {
            wasAttacked = gameObject.CompareTag("Enemy");
            Attack(gameObject.GetComponent<EnemyMain>());
            this.gameObject.SetActive(false);
        }

        if (gameObject.CompareTag("Wall")) {
            this.gameObject.SetActive(false);
        }
    }

}

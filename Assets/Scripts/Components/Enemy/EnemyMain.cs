using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMain : EnemyImpl {

    private void Update() {
        Move();
        Death();
    }

    protected override void OnTriggerEnter2DEvent(Collider2D collider) {
        GameObject gameObject = collider.gameObject;

        if (gameObject.name.Equals("Player")) {
            wasAttacked = gameObject.name.Equals("Player");
            Attack(gameObject.GetComponent<PlayerMain>());
        }

        if (gameObject.name.Equals("DownWall")) {
            this.gameObject.SetActive(false);
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalBulletMain : MonoBehaviour {

    private Bullet bullet;

    private void Awake() {
        bullet = Bullet.Generate(BulletType.Normal);
    }

    private void Update() {
        Vector3 velocity = transform.position;
        velocity.y += bullet.Speed.Value * Time.deltaTime;
        transform.position = velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Enemy")) {
            // TODO: 敵のHPを減らす
            // hp - bullet.AP.Value
        }
    }

}

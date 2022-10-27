using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun {

    private int numberBullets;
    private List<Object> bullets;

    public Gun(int numberBullets, Vector2 playerPosition) {
        this.numberBullets = numberBullets;
        for (int i = 0; i < numberBullets; i++) {
            // GameObject bullet = (GameObject)Resources.Load ("Prefabs/NormalBullet");
            // bullets.Add(Instantiate(bullet, playerPosition, Quaternion.identity));
        }
    }

}

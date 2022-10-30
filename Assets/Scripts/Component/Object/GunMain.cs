using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunMain : MonoBehaviour {

    [SerializeField] private int numberBullets;
    [SerializeField] private GameObject normalBullet;
    [SerializeField] private int fireRate = 5;

    private List<GameObject> bullets = new List<GameObject>();

    private int fireCount = 0;

    private void Awake() {
        for (int i = 0; i < numberBullets; i++) {
            GameObject bullet =
                Instantiate(normalBullet, this.transform.position, Quaternion.identity);
            bullet.transform.parent = this.gameObject.transform;
            bullets.Add(bullet);
        }
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Return) && numberBullets != 0) {
            fireCount = 0;
            Fire();
        }

        if (Input.GetKey(KeyCode.Return)) {
            fireCount++;

            if (fireCount % fireRate == 0 && numberBullets != 0) {
                fireCount = 0;
                Fire();
            }
        }
    }

    private void Fire() {
        numberBullets -= 1;
        bullets[numberBullets].transform.parent = null;
        bullets[numberBullets].GetComponent<BulletMain>().enabled = true;
    }

    public int NumberBullets {
        get { return numberBullets; }
    }

}

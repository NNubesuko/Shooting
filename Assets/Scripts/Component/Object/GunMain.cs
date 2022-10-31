using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunMain : MonoBehaviour {

    [SerializeField] private int numberBullets;
    [SerializeField] private GameObject normalBullet;
    [SerializeField] private float fireRate;

    private List<GameObject> bullets = new List<GameObject>();
    private float fireCount;

    private void Awake() {
        for (int i = 0; i < numberBullets; i++) {
            GameObject bullet =
                Instantiate(normalBullet, this.transform.position, Quaternion.identity);
            bullet.transform.parent = this.gameObject.transform;
            bullets.Add(bullet);
        }

        fireCount = fireRate;
    }

    private void Update() {
        if (numberBullets == 0) return;

        fireCount += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Return) && fireCount >= fireRate) {
            Fire();
        }

        if (Input.GetKey(KeyCode.Return) && fireCount >= fireRate) {
            Fire();
        }
    }

    private void Fire() {
        fireCount = 0f;
        numberBullets -= 1;
        bullets[numberBullets].transform.parent = null;
        bullets[numberBullets].GetComponent<BulletMain>().enabled = true;
    }

    public int NumberBullets {
        get { return numberBullets; }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunMain : MonoBehaviour {

    [SerializeField] private int numberBullets;
    [SerializeField] private GameObject normalBullet;

    private List<GameObject> bullets = new List<GameObject>();

    private void Awake() {
        for (int i = 0; i < numberBullets; i++) {
            GameObject bullet = Instantiate(normalBullet, this.transform.position, Quaternion.identity);
            bullet.transform.parent = this.gameObject.transform;
            bullets.Add(bullet);
        }
        StartCoroutine(FireCorutine());
    }

    private void Fire() {
        numberBullets -= 1;
        bullets[numberBullets].transform.parent = null;
        bullets[numberBullets].GetComponent<NormalBulletMain>().enabled = true;
    }

    private IEnumerator FireCorutine() {
        while (numberBullets != 0) {
            if (Input.GetKey(KeyCode.Return)) {
                Fire();
            }
            yield return new WaitForSeconds(0.2f);
        }
    }

    public int NumberBullets {
        get { return numberBullets; }
    }

}

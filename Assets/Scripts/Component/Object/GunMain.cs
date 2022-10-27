using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunMain : MonoBehaviour {

    [SerializeField] private int numberBullets;
    [SerializeField] private GameObject normalBullet;

    private List<GameObject> bullets;

    private void Awake() {
        for (int i = 0; i < numberBullets; i++) {
            bullets.Add(Instantiate(normalBullet, this.transform.position, Quaternion.identity));
        }
    }

    private void Update() {
        // TODO: キー入力を実装 コルーチンの方が良き？
        /*
         * if () {
         *     Fire();
         * }
         */
    }

    private void Fire() {
        numberBullets -= 1;
        bullets[numberBullets].GetComponent<NormalBulletMain>().enabled = true;
    }

    public int NumberBullets {
        get { return bullets.Count; }
    }

}

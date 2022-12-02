using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using Systemk;

namespace Tests {

    [Description("銃のテスト")]
    public class GunTest {

        private GameObject gunObject = null;
        private GunMain gunScript = null;

        [OneTimeSetUp]
        public void OneTimeSetUp() {
            SceneManager.LoadSceneAsync("Stage1").completed += _ => {
                gunObject = GameObject.Find("Gun");
                gunScript = gunObject.GetComponent<GunMain>();
            };
        }

        [UnityTest]
        [Order(1)]
        [Description("[正常] 銃オブジェクトが存在する場合に、変数に格納されること")]
        public IEnumerator GunObjectExists() {
            Assert.That(gunObject, Is.Not.Null);
            yield return null;
        }

        [UnityTest]
        [Order(2)]
        [Description("[正常] 銃スクリプトが存在する場合に、変数に格納されること")]
        public IEnumerator GunScriptExists() {
            Assert.That(gunScript, Is.Not.Null);
            yield return null;
        }

        [UnityTest]
        [Order(3)]
        [Description("[正常] 銃のステータスが初期化された場合に、正常に初期化されること")]
        public IEnumerator ValidGunStatus() {
            // List<GameObject> Bullets = new List<GameObject>();
            // for (int i = 0; i < 10; i++) {
            // }

            yield return null;
        }

        // [UnityTest]
        // [Order(3)]
        // [Description("[正常] 発射キーを入力した場合に、弾丸が１発のみ発射されること")]
        // public IEnumerator FireKeyToFireBullet() {
        //     int lastBulletsCount = gunScript.Bullets.Count;
        //     yield return new WaitUntil(() => Inputk.GetKeyDown(KeyCode.Return));
        //     int currentBulletsCount = lastBulletsCount - 1;

        //     Assert.That(currentBulletsCount, Is.EqualTo(lastBulletsCount));
        // }

    }

}

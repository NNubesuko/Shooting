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
            GameObject bulletObject = (GameObject)Resources.Load("Prefab/Bullet");
            BulletsCount bulletsCount = BulletsCount.Of(10);
            GunFiringRate gunFiringRate = GunFiringRate.Of(0.15f);

            gunScript.Init(
                bulletObject,
                bulletsCount,
                gunFiringRate
            );

            Assert.That(
                gunScript.BulletObject,
                Is.EqualTo((GameObject)Resources.Load("Prefab/Bullet"))
            );
            Assert.That(gunScript.Count, Is.EqualTo(BulletsCount.Of(10)));
            Assert.That(gunScript.Rate, Is.EqualTo(GunFiringRate.Of(0.15f)));
            yield return null;
        }

        [UnityTest]
        [Order(4)]
        [Description("[正常] ステータスが初期化された場合に、指定した弾数の弾丸が生成されていること")]
        public IEnumerator ValidBulletsCount() {
            BulletsCount bulletsCount = BulletsCount.Of(gunScript.Bullets.Count);
            Assert.That(bulletsCount, Is.EqualTo(gunScript.Count));
            yield return null;
        }

        [UnityTest]
        [Order(5)]
        [Description("[正常] 発射キーを一瞬入力した場合に、弾丸が１発のみ発射されること")]
        public IEnumerator FireKeyDownToFireBullet() {
            int lastCount = gunScript.Bullets.Count;
            yield return new WaitUntil(() => Inputk.GetKeyDown(KeyCode.Return));
            int currentCount = gunScript.Bullets.Count;
            
            Assert.That(currentCount, Is.LessThan(lastCount));
        }

        [UnityTest]
        [Order(6)]
        [Description("[正常] 発射キーを一定時間長押しした場合に、弾数が０になっていること")]
        public IEnumerator FireKeyToFireBullet() {
            yield return new WaitUntil(() => {
                return gunScript.Bullets.Count == 0 && Inputk.GetKey(KeyCode.Return);
            });
            Assert.That(gunScript.Bullets.Count, Is.EqualTo(0));
        }

    }

}

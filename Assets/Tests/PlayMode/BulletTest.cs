using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

namespace Tests {

    [Description("弾丸のテスト")]
    public class BulletTest {

        private GameObject bulletObject;
        private BulletMain bulletScript;

        [OneTimeSetUp]
        public void OneTimeSetUp() {
            SceneManager.LoadSceneAsync("Stage1").completed += _ => {
                bulletObject = GameObject.Find("Bullet");
                bulletScript = bulletObject.GetComponent<BulletMain>();
            };
        }

        [UnityTest]
        [Order(1)]
        [Description("[正常] 弾丸オブジェクトが存在する場合に、変数に格納されること")]
        public IEnumerator BulletObjectExists() {
            Assert.That(bulletObject, Is.Not.Null);
            yield return null;
        }

        [UnityTest]
        [Order(2)]
        [Description("[正常] 弾丸オブジェクトが存在する場合に、変数に格納されること")]
        public IEnumerator BulletScriptExists() {
            Assert.That(bulletScript, Is.Not.Null);
            yield return null;
        }

        [UnityTest]
        [Order(3)]
        [Description("[正常] 敵のステータスが初期化された場合に、正常に初期化されること")]
        public IEnumerator ValidPlayerStatus() {
            BulletAP bulletAP = BulletAP.Of(10);
            BulletMoveSpeed bulletMoveSpeed = BulletMoveSpeed.Of(7f);

            bulletScript.Init(
                bulletAP,
                bulletMoveSpeed
            );

            Assert.That(bulletScript.AP, Is.EqualTo(bulletAP));
            Assert.That(bulletScript.MoveSpeed, Is.EqualTo(bulletMoveSpeed));
            yield return null;
        }

        [UnityTest]
        [Order(4)]
        [Description("[正常] 常時上方向に移動していること")]
        public IEnumerator ValidMove() {
            Vector2 lastPosition = bulletObject.transform.position;
            yield return null;
            Vector2 currentPosition = bulletObject.transform.position;

            Assert.That(currentPosition.y, Is.GreaterThan(lastPosition.y));
        }

    }

}

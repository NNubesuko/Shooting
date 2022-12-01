using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

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
        [Description("[正常] 銃オブジェクトが存在する場合に、変数に格納されること")]
        public IEnumerator GunObjectExists() {
            Assert.That(gunObject, Is.Not.Null);
            yield return null;
        }

        [UnityTest]
        [Description("[正常] 銃スクリプトが存在する場合に、変数に格納されること")]
        public IEnumerator GunScriptExists() {
            Assert.That(gunScript, Is.Not.Null);
            yield return null;
        }

    }

}

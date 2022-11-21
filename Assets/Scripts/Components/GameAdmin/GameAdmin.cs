using System.Collections;
using System.Collections.Generic;
using Systemk;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameAdmin : MonoBehaviour {

    [SerializeField] PlayerMain playerScript;

    private void Awake() {
        GameAdministrator.HiddenCursor();

        PlayerHPk playerHP = new PlayerHPk(50);
        PlayerHPk addHP = new PlayerHPk(60);
        EnemyHPk enemyHP = new EnemyHPk(60);
        Debug.Log(playerHP < addHP);
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            GameAdministrator.QuitGame();
        }

        if (playerScript.IsDeath) {
            Invoke(nameof(ReturnTitleScene), 3f);
        }
    }

    private void ReturnTitleScene() {
        SceneManager.LoadScene("Title");
    }

}

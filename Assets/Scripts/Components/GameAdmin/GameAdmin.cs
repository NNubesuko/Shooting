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

        PlayerHPk hp = new PlayerHPk(100);
        Debug.Log(hp);
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

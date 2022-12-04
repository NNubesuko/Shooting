using System.Collections;
using System.Collections.Generic;
using Systemk;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameAdmin : MonoBehaviour {

    [SerializeField] private GameObject player;

    public PlayerMain PlayerScript { get; private set; }

    private void Awake() {
        GameAdministrator.SetFPS(60);
        GameAdministrator.HiddenCursor();

        PlayerScript = player.GetComponent<PlayerMain>();
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            GameAdministrator.QuitGame();
        }

        if (PlayerScript.IsDeath) {
            Invoke(nameof(ReturnTitleScene), 3f);
        }
    }

    private void ReturnTitleScene() {
        PlayerScript.WhenGameOver();
        SceneManager.LoadScene("Title");
    }

}

using System.Collections;
using System.Collections.Generic;
using Systemk;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameAdmin : MonoBehaviour {

    [SerializeField] private GameObject player;
    [SerializeField] private GameObject gun;
    [SerializeField] private EnemyGenerator enemyAdmin;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject gameClearPanel;

    public PlayerMain PlayerScript { get; private set; }
    public GunMain GunScript { get; private set; }

    private void Awake() {
        GameAdministrator.SetFPS(60);
        GameAdministrator.HiddenCursor();

        PlayerScript = player.GetComponent<PlayerMain>();
        GunScript = gun.GetComponent<GunMain>();
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            GameAdministrator.QuitGame();
        }

        if (PlayerScript.IsDeath) {
            gameOverPanel.SetActive(true);
            Invoke(nameof(ReturnTitleScene), 3f);
        }

        if (enemyAdmin.WasLastEnemyDefeated) {
            gameClearPanel.SetActive(true);
            Invoke(nameof(ReturnTitleScene), 3f);
        }
    }

    private void ReturnTitleScene() {
        PlayerScript.WhenGameOver();
        SceneManager.LoadScene("Title");
    }

}

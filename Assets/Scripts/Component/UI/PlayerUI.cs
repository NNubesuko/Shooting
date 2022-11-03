using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour {

    [SerializeField] private PlayerMain playerMain;
    [SerializeField] private Text scoreText;
    [SerializeField] private Slider playerHPBar;

    private Player player;
    // private int score = 0;

    private void Start() {
        player = playerMain.Player;
        // player = GameObject.Find("Player").GetComponent<PlayerMain>().Player;
    }

    private void Update() {
        scoreText.text = "Score: " + player.Score;
        playerHPBar.value = (float)player.HP.Value / PlayerHP.MAX;
    }

}

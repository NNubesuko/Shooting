using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour {

    [SerializeField] private Text scoreText;
    [SerializeField] private Slider playerHPBar;

    private Player player;
    private int score = 0;

    private void Start() {
        player = GameObject.Find("Player").GetComponent<PlayerMain>().Player;
    }

    private void Update() {
        scoreText.text = "Score: " + score.ToString();
        playerHPBar.value = (float)player.HP.Value / PlayerHP.MAX;
    }

    public void AddScore(int addScore) {
        score += addScore;
    }

}

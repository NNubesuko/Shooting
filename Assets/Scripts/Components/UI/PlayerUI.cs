using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour {

    [SerializeField] private PlayerMain playerMain;
    [SerializeField] private Text scoreText;
    [SerializeField] private Slider playerHPBar;
    [SerializeField] private Slider playerStaminaBar;

    private Player player;

    private void Start() {
        player = playerMain;
    }

    private void Update() {
        scoreText.text = "Score: " + player.Score;
        playerHPBar.value = (float)player.HP.Value / PlayerHP.MAX;
        playerStaminaBar.value = player.Stamina.Value / PlayerStamina.MAX;
    }

}

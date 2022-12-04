using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour {

    [SerializeField] private GameAdmin gameAdmin;
    [SerializeField] private Text scoreText;
    [SerializeField] private Slider playerHPBar;
    [SerializeField] private Slider playerStaminaBar;

    private Player playerMain;

    private void Start() {
        playerMain = gameAdmin.PlayerScript;
    }

    private void Update() {
        scoreText.text = $"Score: {playerMain.Score}";
        playerHPBar.value = (float)playerMain.HP.Value / playerMain.HP.MAX;
        playerStaminaBar.value = (float)playerMain.Stamina.Value / playerMain.Stamina.MAX;
    }

}

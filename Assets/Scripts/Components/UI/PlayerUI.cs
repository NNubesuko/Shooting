using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour {

    [SerializeField] private GameAdmin gameAdmin;
    [SerializeField] private Text scoreText;
    [SerializeField] private Text bulletsCountText;
    [SerializeField] private Slider playerHPBar;
    [SerializeField] private Slider playerStaminaBar;

    private Player playerScript;
    private Gun gunScript;

    private void Start() {
        playerScript = gameAdmin.PlayerScript;
        gunScript = gameAdmin.GunScript;
    }

    private void Update() {
        int currnetBullets = (gunScript.MaxCount - gunScript.Count).ToValue();
        int maxBullets = gunScript.MaxCount.ToValue();
        scoreText.text = "スコア: " + playerScript.Score;
        bulletsCountText.text = "残弾数: " + currnetBullets + " / " + maxBullets;
        playerHPBar.value = (float)playerScript.HP.ToValue() / playerScript.HP.MAX;
        playerStaminaBar.value = (float)playerScript.Stamina.ToValue() / playerScript.Stamina.MAX;
    }

}

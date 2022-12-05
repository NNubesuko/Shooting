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
        int currnetBullets = gunScript.MaxCount.Value - gunScript.Count.Value;
        scoreText.text = $"Score: {playerScript.Score}";
        bulletsCountText.text = $"Bullets : {currnetBullets} / {gunScript.MaxCount.Value}";
        playerHPBar.value = (float)playerScript.HP.Value / playerScript.HP.MAX;
        playerStaminaBar.value = (float)playerScript.Stamina.Value / playerScript.Stamina.MAX;
    }

}

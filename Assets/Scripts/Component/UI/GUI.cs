using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUI : MonoBehaviour {

    [SerializeField] private Slider playerHPBar;

    private Player player;

    private void Start() {
        player = GameObject.Find("Player").GetComponent<PlayerMain>().Player;
    }

    private void Update() {
        playerHPBar.value = (float)player.HP.Value / PlayerHP.MAX;
    }

}

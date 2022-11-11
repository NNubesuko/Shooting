using System.Collections;
using System.Collections.Generic;
using Systemk;
using UnityEngine;
using UnityEngine.UI;

public class GameAdmin : MonoBehaviour {

    private void Awake() {
        GameAdministrator.HiddenCursor();
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            GameAdministrator.QuitGame();
        }
    }

}

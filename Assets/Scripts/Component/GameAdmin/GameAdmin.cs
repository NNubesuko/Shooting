using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameAdmin : MonoBehaviour {

    private void Awake() {
        Cursor.visible = false;
    }

    private void Update() {
        EndGame();
    }

    private void EndGame() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
            #else
                Application.Quit();
            #endif
        }
    }

}

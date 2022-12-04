using Systemk;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleAdmin : MonoBehaviour {

    private void Awake() {
        GameAdministrator.DisplayCursor();
    }

    public void OnClickStage1Button() {
        SceneManager.LoadScene("Stage1");
    }

    public void OnClickQuitButton() {
        GameAdministrator.QuitGame();
    }

}

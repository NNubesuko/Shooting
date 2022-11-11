using UnityEngine;

namespace Systemk {

    public class GameAdministrator {

        public static void DisplayCursor() {
            Cursor.visible = true;
        }

        public static void HiddenCursor() {
            Cursor.visible = false;
        }

        public static void QuitGame() {
            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
            #else
                Application.Quit();
            #endif
        }

    }

}
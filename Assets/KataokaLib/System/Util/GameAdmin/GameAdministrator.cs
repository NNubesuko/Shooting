using System;
using UnityEngine;
using UnityEngine.Scripting;

namespace KataokaLib.System {

    public class GameAdministrator {

        public static void SetFPS(int fps) {
            Application.targetFrameRate = fps;
        }

        public static void DisplayCursor() {
            Cursor.visible = true;
        }

        public static void HiddenCursor() {
            Cursor.visible = false;
        }

        public static void EableDebugLog() {
            Debug.unityLogger.logEnabled = true;
        }

        public static void DisableDebugLog() {
            Debug.unityLogger.logEnabled = false;
        }

        public static void GarbageCollect() {
            GC.Collect();
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
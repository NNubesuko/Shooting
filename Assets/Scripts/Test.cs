using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Profiling;

public class Test : MonoBehaviour {

    [SerializeField] private Text fpsText;
    [SerializeField] private Text usedText;
    [SerializeField] private Text unusedText;
    [SerializeField] private Text totalText;

    private void Update() {
        float fps = 1f / Time.deltaTime;
        fpsText.text = fps.ToString("0.0") + " FPS";

        float used = ( Profiler.GetTotalAllocatedMemoryLong() >> 10 ) / 1024f;
        float unused = ( Profiler.GetTotalUnusedReservedMemoryLong() >> 10 ) / 1024f;
        float total = ( Profiler.GetTotalReservedMemoryLong() >> 10 ) / 1024f;

        usedText.text = used.ToString("0.0") + " MB";
        unusedText.text = unused.ToString("0.0") + " MB";
        totalText.text = total.ToString("0.0") + " MB";

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

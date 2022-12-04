using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Profiling;
using Systemk;

public class ProfilingUI : MonoBehaviour {

    [SerializeField] private Text fpsText;
    [SerializeField] private Text usedText;
    [SerializeField] private Text unusedText;
    [SerializeField] private Text totalText;

    private bool isDisplay = false;

    private void Update() {
        float fps = 1f / Time.deltaTime;

        float used = ( Profiler.GetTotalAllocatedMemoryLong() >> 10 ) / 1024f;
        float unused = ( Profiler.GetTotalUnusedReservedMemoryLong() >> 10 ) / 1024f;
        float total = ( Profiler.GetTotalReservedMemoryLong() >> 10 ) / 1024f;

        if (Inputk.GetKeyDown(KeyCode.P)) {
            isDisplay = !isDisplay;
        }

        if (isDisplay) {
            fpsText.text = $"{fps.ToString("0.0")} FPS";
            usedText.text = $"Used memory: {used.ToString("0.0")} MB";
            unusedText.text = $"Unused memory: {unused.ToString("0.0")} MB";
            totalText.text = $"Total memory: {total.ToString("0.0")} MB";
        } else {
            fpsText.text = "";
            usedText.text = "";
            unusedText.text = "";
            totalText.text = "";
        }
    }

}

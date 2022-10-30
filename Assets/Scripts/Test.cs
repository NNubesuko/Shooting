using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour {

    [SerializeField] private Text fpsText;

    private void Update() {
        float fps = 1f / Time.deltaTime;
        fpsText.text = $"FPS: {fps}";
    }

}

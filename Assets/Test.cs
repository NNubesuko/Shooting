using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

    [SerializeField] private Transform target;
    [SerializeField, Range(0.001f, 10f)] private float f = 0f;
    [SerializeField, Range(0f, 10f)] private float z = 0f;
    [SerializeField, Range(-10f, 10f)] private float r = 0f;
    [SerializeField, Range(0f, 10f)] private float moveSpeed;
    [SerializeField] private AnimationCurve curve;

    private SecondOrderDynamics secondOrderDynamics;

    private void Awake() {
        // 初期化
        secondOrderDynamics = new SecondOrderDynamics(f, z, r, target.position);
    }

    private void Update() {
        // 移動
        transform.position = secondOrderDynamics.Update(
            f,
            z,
            r,
            Time.deltaTime * moveSpeed,
            target.position
        );

        // グラフの描画
        curve = secondOrderDynamics.DisplayCurve(f, z, r, curve);
    }

}
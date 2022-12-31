using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

    [SerializeField] private Transform target;
    [SerializeField, Range(0f, 10f)] private float f = 0f;
    [SerializeField, Range(0f, 5f)] private float z = 0f;
    [SerializeField, Range(-1f, 1f)] private float r = 0f;

    private SecondOrderDynamics secondOrderDynamics;

    private void Awake() {
        secondOrderDynamics = new SecondOrderDynamics(f, z, r, target.position);
    }

    private void Update() {
        secondOrderDynamics.UpdateConstants(f, z, r);
        transform.position = secondOrderDynamics.Update(Time.deltaTime, target.position);
    }

}

public class SecondOrderDynamics {

    private Vector3 targetInitPosition, targetLastPosition;
    private Vector3 playerResultPosition, playerLastResultPosition;
    private float k1, k2, k3;

    public SecondOrderDynamics(float f, float z, float r, Vector3 target) {
        UpdateConstants(f, z, r);

        targetInitPosition = target;
        targetLastPosition = default;
        playerResultPosition = target;
        playerLastResultPosition = Vector3.zero;
    }

    public void UpdateConstants(float f, float z, float r) {
        k1 = z / (MathF.PI * f);
        k2 = 1 / ((2 * MathF.PI * f) * (2 * MathF.PI * f));
        k3 = r * z / (2 * MathF.PI * f);
    }

    public Vector3 Update(float T, Vector3 x) {
        if (targetLastPosition == default) {
            targetLastPosition = (x - targetInitPosition) / T;
            targetInitPosition = x;
        }

        playerResultPosition += T * playerLastResultPosition;
        playerLastResultPosition += T * (x + k3 * targetLastPosition - playerResultPosition - k1 * playerLastResultPosition) / k2;

        // ターゲットの過去の位置を保存
        targetLastPosition = x;

        return playerResultPosition;
    }

}

// y -> y
// yd -> y'
// y + k1y + k2y = x + k3x;

// x -> target
// y -> me

// T -> frame rate

// y[n] -> last my position
// y[n + 1] -> update my position
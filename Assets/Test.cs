using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

    [SerializeField] private Transform target;
    [SerializeField, Range(0.001f, 10f)] private float f = 0f;
    [SerializeField, Range(0f, 5f)] private float z = 0f;
    [SerializeField, Range(-10f, 10f)] private float r = 0f;
    [SerializeField] private AnimationCurve curve = new AnimationCurve();

    private SecondOrderDynamics secondOrderDynamics;
    private SecondOrderDynamics displaySecondOrderDynamics;

    private float timeRate = 0.01f;

    private void Awake() {
        secondOrderDynamics = new SecondOrderDynamics(f, z, r, target.position);
        
        Display();
    }

    private void Update() {
        secondOrderDynamics.UpdateConstants(f, z, r);
        transform.position = secondOrderDynamics.Update(Time.deltaTime, target.position);

        displaySecondOrderDynamics.UpdateConstants(f, z, r);
        if (!displaySecondOrderDynamics.ChangeConstants) return;

        Display();
    }

    private void Display() {
        curve = new AnimationCurve();

        Vector3 displayTarget = Vector3.zero;
        displaySecondOrderDynamics = new SecondOrderDynamics(f, z, r, displayTarget);

        int count = (int)MathF.Round(1 / timeRate);
        for (int i = 0; i <= count; i++) {
            float currentTime = timeRate * i;
            displayTarget = Vector3.one;

            Vector3 result = displaySecondOrderDynamics.Update(timeRate, displayTarget);
            curve.AddKey(new Keyframe(currentTime, result.y));
        }
    }

}


// semi-implicit euler method
// y + k1y. + k2y.. = x + k3x.
// y(t) + k1y'(t) + k2y"(t) = x(t) + k3x'(t)
// y + k1 dy/dt + k2 d^2y / dt^2 = x + k3 dx/dt
public class SecondOrderDynamics {

    public bool ChangeConstants { get; private set; }

    private Vector3 targetInitPosition, targetLastPosition;
    private Vector3 playerResultPosition, playerLastResultPosition;
    private float w, z, d, k1, k2, k3;
    private float lk1, lk2, lk3;

    public SecondOrderDynamics(float f, float z, float r, Vector3 target) {
        UpdateConstants(f, z, r);

        targetInitPosition = target;
        targetLastPosition = default;
        playerResultPosition = target;
        playerLastResultPosition = Vector3.zero;
    }

    public void UpdateConstants(float f, float z, float r) {
        this.w = 2 * MathF.PI * f;
        this.z = z;
        this.d = this.w * MathF.Sqrt( MathF.Abs(z * z - 1) );

        k1 = z / (MathF.PI * f);
        k2 = 1 / (this.w * this.w);
        k3 = r * z / this.w;

        if (k1 != lk1 || k2 != lk2 || k3 != lk3) {
            ChangeConstants = true;
        } else {
            ChangeConstants = false;
        }

        lk1 = k1;
        lk2 = k2;
        lk3 = k3;
    }

    public Vector3 Update(float T, Vector3 x) {
        if (targetLastPosition == default) {
            targetLastPosition = (x - targetInitPosition) / T;
            targetInitPosition = x;
        }

        float k1_stable, k2_stable;

        if (w * T < z) {
            k1_stable = k1;
            k2_stable = Max(k2, T*T/2 + T*k1/2, T*k1);
        } else {
            float t1 = MathF.Exp(-z * w * T);
            float alpha = 2 * t1 * (z <= 1 ? MathF.Cos(T * d) : MathF.Cosh(T * d));
            float beta = t1 * t1;
            float t2 = T / (1 + beta - alpha);
            k1_stable = (1 - beta) * t2;
            k2_stable = T * t2;
        }

        playerResultPosition = playerResultPosition + T * playerLastResultPosition;
        playerLastResultPosition =
            playerLastResultPosition +
            T *
            (x + k3 * targetLastPosition - playerResultPosition - k1 * playerLastResultPosition) /
            k2_stable;

        // ターゲットの過去の位置を保存
        targetLastPosition = x;

        return playerResultPosition;
    }

    public float Max(float first, float second, float thrid) {
        float maxFirstOrSecond = MathF.Max(first, second);
        return MathF.Max(maxFirstOrSecond, thrid);
    }

}

// y -> playerResultPosition
// yd -> playerLastResultPosition

// y -> y
// yd -> y'
// y + k1y + k2y = x + k3x;

// x -> target
// y -> me

// T -> frame rate

// y[n] -> last my position
// y[n + 1] -> update my position
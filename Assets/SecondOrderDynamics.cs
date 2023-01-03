using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// semi-implicit euler method
// y + k1y. + k2y.. = x + k3x.
// y(t) + k1y'(t) + k2y"(t) = x(t) + k3x'(t)
// y + k1 (dy/dt) + k2 (d^2y/dt^2) = x + k3 (dx/dt)
// (dy/dt), (dx/dt) -> 角速度などで使用される微分

// y -> playerResultPosition
// yd -> playerLastResultPosition

// y -> y
// yd -> y'
// y + k1y + k2y = x + k3x;

// x -> target
// y -> me

// timeRate -> frame rate

// y[n] -> last my position
// y[n + 1] -> update my position
public class SecondOrderDynamics {

    private Vector3 targetInitPosition, targetLastPosition;
    private Vector3 playerResultPosition, playerLastResultPosition;
    private float _w, _z, _d;
    private float f, z, r;
    private float lf, lz, lr;
    private float k1, k2, k3;

    public SecondOrderDynamics(float f, float z, float r, Vector3 target) {
        UpdateConstants(f, z, r);

        targetInitPosition = target;
        targetLastPosition = default;
        playerResultPosition = target;
        playerLastResultPosition = Vector3.zero;
    }

    public bool IsChangeConstants(float f, float z, float r) {
        this.f = f;
        this.z = z;
        this.r = r;

        bool isChangeConstants;
        if ( f != lf || z != lz || r != lr ) {
            isChangeConstants = true;
        } else {
            isChangeConstants = false;
        }

        lf = f;
        lz = z;
        lr = r;

        return isChangeConstants;
    }

    public void UpdateConstants(float f, float z, float r) {
        _w = 2 * Mathf.PI * f;
        _z = z;
        _d = _w * Mathf.Sqrt( Mathf.Abs(z * z - 1) );

        k1 = z / (Mathf.PI * f);
        k2 = 1 / (_w * _w);
        k3 = r * z / _w;
    }

    public Vector3 Update(float timeRate, Vector3 x) {
        InitTarget(timeRate, x);

        float k1_stable, k2_stable;
        if (_w * timeRate < _z) {
            k1_stable = k1;
            k2_stable = Max(k2, timeRate*timeRate/2 + timeRate*k1/2, timeRate*k1);
        } else {
            float t1 = Mathf.Exp(-_z * _w * timeRate);
            float alpha = 2 * t1 * (_z <= 1 ? Mathf.Cos(timeRate * _d) : Cosh(timeRate * _d));
            float beta = t1 * t1;
            float t2 = timeRate / (1 + beta - alpha);
            k1_stable = (1 - beta) * t2;
            k2_stable = timeRate * t2;
        }

        playerResultPosition = playerResultPosition + timeRate * playerLastResultPosition;
        playerLastResultPosition =
            playerLastResultPosition +
            timeRate *
            (x + k3 * targetLastPosition - playerResultPosition - k1 * playerLastResultPosition) /
            k2_stable;

        // ターゲットの過去の位置を保存
        targetLastPosition = x;

        return playerResultPosition;
    }

    public Vector3 Update(float f, float z, float r, float timeRate, Vector3 x) {
        if (IsChangeConstants(f, z, r)) {
            UpdateConstants(f, z, r);
        }

        return Update(timeRate, x);
    }

    private void InitTarget(float timeRate, Vector3 x) {
        if (targetLastPosition == default) {
            targetLastPosition = (x - targetInitPosition) / timeRate;
            targetInitPosition = x;
        }
    }

    /*
     * グラフの描画
     */
    public AnimationCurve DisplayCurve(float f, float z, float r, AnimationCurve curve) {
        curve = new AnimationCurve();

        float timeRate = 0.01f;
        Vector3 target = Vector3.zero;
        SecondOrderDynamics display = new SecondOrderDynamics(f, z, r, target);

        for (int i = 0; i <= 200; i++) {
            float currentTime = timeRate * i;

            target = Vector3.one;
            Vector3 currentPos = display.Update(f, z, r, timeRate, target);
            
            curve.AddKey(new Keyframe(currentTime, currentPos.y));
        }

        return curve;
    }

    private float Max(float first, float second, float thrid) {
        float maxFirstOrSecond = Mathf.Max(first, second);
        return Mathf.Max(maxFirstOrSecond, thrid);
    }

    private float Cosh(float x) {
        return ( Mathf.Exp(x) + Mathf.Exp(-x) ) / 2;
    }

}
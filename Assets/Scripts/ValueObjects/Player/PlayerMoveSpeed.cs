using UnityEngine;
using Systemk;

public class PlayerMoveSpeed : Speed {

    private PlayerMoveSpeed(float value) : base(value, 0f, 10f) {
    }

    public static PlayerMoveSpeed Of(float value) {
        return new PlayerMoveSpeed(value);
    }

    /*
     * 移動速度と入力方向を乗算するメソッド
     */
    public static Vector2 operator*(PlayerMoveSpeed speed, Vector2 axis) {
        return speed.Value * axis;
    }

}

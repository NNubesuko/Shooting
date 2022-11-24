using UnityEngine;
using Systemk;

public class PlayerMoveSpeed : Speed {

    private PlayerMoveSpeed(float value) : base(value, 0f, 10f) {
    }

    public static PlayerMoveSpeed Of(float value) {
        return new PlayerMoveSpeed(value);
    }

    /*
     * 移動速度と Inputk.GetAxis() をかけ合わせたいため、その判定として Inputk を引数として指定する
     */
    public static Vector2 operator*(PlayerMoveSpeed moveSpeed, Inputk input) {
        return moveSpeed.Value * Inputk.GetAxis();
    }

}

using UnityEngine;

/*
 * プレイヤーの回避速度のクラス
 */
public class PlayerEvasionSpeed : Speed {

    private PlayerEvasionSpeed(float value) : base(value, 0f, 100f) {
    }

    public static PlayerEvasionSpeed Of(float value) {
        return new PlayerEvasionSpeed(value);
    }

    /*
     * 回避速度とフレーム秒を乗算するメソッド
     */
    public static float operator*(PlayerEvasionSpeed speed, float deltaTime) {
        return speed.Value * deltaTime;
    }

}
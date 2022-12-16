using UnityEngine;

/*
 * プレイヤーの回避距離のクラス
 */
public class PlayerEvasionDistance : Distance {

    private PlayerEvasionDistance(float value) : base(value, 0f, 10f) {
    }

    public static PlayerEvasionDistance Of(float value) {
        return new PlayerEvasionDistance(value);
    }

    /*
     * 回避距離と入力方向を乗算するメソッド
     */
    public static Vector2 operator*(PlayerEvasionDistance distance, Vector2 axis) {
        return distance.Value * axis;
    }

}
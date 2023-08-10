using UnityEngine;

public class PlayerAvoidsDistance : Distance {

    private PlayerAvoidsDistance(float value) : base(value, 0f, 10f) {
    }

    public static PlayerAvoidsDistance Of(float value) {
        return new PlayerAvoidsDistance(value);
    }

    /*
     * 回避距離と入力方向を乗算するメソッド
     */
    public static Vector2 operator*(PlayerAvoidsDistance distance, Vector2 axis) {
        return distance.Value * axis;
    }

}
using UnityEngine;

/*
 * 敵の移動速度のクラス
 */
public class EnemyMoveSpeed : Speed {

    private EnemyMoveSpeed(float value) : base(value, 0f, 10f) {
    }

    public static EnemyMoveSpeed Of(float value) {
        return new EnemyMoveSpeed(value);
    }

    public static Vector2 operator*(EnemyMoveSpeed speed, Vector2 targetPosition) {
        return speed.Value * targetPosition;
    }

}
using UnityEngine;

/*
 * 敵の移動倍率のクラス
 */
public class EnemyMoveSpeedMagnification : Magnification {

    private EnemyMoveSpeedMagnification(float value) : base(value, 0f, 10f) {
    }

    public static EnemyMoveSpeedMagnification Of(float value) {
        return new EnemyMoveSpeedMagnification(value);
    }

    public static Vector2 operator*(EnemyMoveSpeedMagnification magnification, Vector2 vector2) {
        return magnification.Value * vector2;
    }

}

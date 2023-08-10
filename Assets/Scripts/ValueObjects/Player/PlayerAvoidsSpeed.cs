public class PlayerAvoidsSpeed : Speed
{
    private PlayerAvoidsSpeed(float value) : base(value, 0f, 100f) {
    }

    public static PlayerAvoidsSpeed Of(float value) {
        return new PlayerAvoidsSpeed(value);
    }

    /*
     * 回避速度とフレーム秒を乗算するメソッド
     */
    public static float operator*(PlayerAvoidsSpeed speed, float deltaTime) {
        return speed.Value * deltaTime;
    }
}
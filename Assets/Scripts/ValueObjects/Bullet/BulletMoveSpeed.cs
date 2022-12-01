public class BulletMoveSpeed : Speed {

    private BulletMoveSpeed(float value) : base(value, 0f, 100f) {
    }

    public static BulletMoveSpeed Of(float value) {
        return new BulletMoveSpeed(value);
    }

    public static float operator*(BulletMoveSpeed speed, float deltaTime) {
        return speed.Value * deltaTime;
    }

}
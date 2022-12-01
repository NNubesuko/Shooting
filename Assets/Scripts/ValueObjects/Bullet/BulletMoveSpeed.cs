public class BulletMoveSpeed : Speed {

    private BulletMoveSpeed(float value) : base(value, 0f, 100f) {
    }

    public static BulletMoveSpeed Of(float value) {
        return new BulletMoveSpeed(value);
    }

}
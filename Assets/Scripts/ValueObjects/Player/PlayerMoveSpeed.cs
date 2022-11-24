public class PlayerMoveSpeed : Speed {

    private PlayerMoveSpeed(float value) : base(value, 0f, 10f) {
    }

    public static PlayerMoveSpeed Of(float value) {
        return new PlayerMoveSpeed(value);
    }

}

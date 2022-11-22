public class PlayerMoveSpeed : Speed {

    private PlayerMoveSpeed(int value) : base(value, 0, 10) {
    }

    public static PlayerMoveSpeed Of(int value) {
        return new PlayerMoveSpeed(value);
    }

}

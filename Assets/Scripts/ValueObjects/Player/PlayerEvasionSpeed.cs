public class PlayerEvasionSpeed : Speed {

    private PlayerEvasionSpeed(float value) : base(value, 0f, 100f) {
    }

    public static PlayerEvasionSpeed Of(float value) {
        return new PlayerEvasionSpeed(value);
    }

}
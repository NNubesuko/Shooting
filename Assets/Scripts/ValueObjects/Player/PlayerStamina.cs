public class PlayerStamina : Stamina {

    private PlayerStamina(float value) : base(value, 0f, 100f) {
    }

    public static PlayerStamina Of(float value) {
        return new PlayerStamina(value);
    }

}
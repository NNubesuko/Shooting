using Systemk;

/*
 * プレイヤーのスタミナのクラス
 */
public class PlayerStamina : Stamina {

    private PlayerStamina(float value) : base(value, 0f, 100f) {
    }

    public static PlayerStamina Of(float value) {
        return new PlayerStamina(value);
    }

    public static PlayerStamina operator+(PlayerStamina lhStamina, PlayerStamina rhStamina) {
        float value = Mathk.KeepValueWithinRange<float>(
            lhStamina.Value + rhStamina.Value,
            lhStamina.MIN,
            lhStamina.MAX
        );

        return new PlayerStamina(value);
    }

    public static PlayerStamina operator-(PlayerStamina lhStamina, PlayerStamina rhStamina) {
        float value = Mathk.KeepValueWithinRange<float>(
            lhStamina.Value - rhStamina.Value,
            lhStamina.MIN,
            lhStamina.MAX
        );

        return new PlayerStamina(value);
    }

}
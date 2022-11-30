/*
 * プレイヤーの体力のクラス
 */
public class PlayerHP : HP {

    private PlayerHP(int value) : base(value, 0, 100) {
    }

    public static PlayerHP Of(int value) {
        return new PlayerHP(value);
    }

}

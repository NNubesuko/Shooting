/*
 * 敵の体力のクラス
 */
public class EnemyHP : HP {

    private EnemyHP(int value) : base(value, 0, 1000) {
    }

    public static EnemyHP Of(int value) {
        return new EnemyHP(value);
    }

}
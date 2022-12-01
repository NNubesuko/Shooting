/*
 * 敵の体力のクラス
 */
public class EnemyHP : HP {

    private EnemyHP(int value) : base(value, 0, 1000) {
    }

    public static EnemyHP Of(int value) {
        return new EnemyHP(value);
    }

    public static EnemyHP operator-(EnemyHP hp, AP ap) {
        return new EnemyHP(hp.Value - ap.Value);
    }

}
/*
 * 敵の攻撃力のクラス
 */
public class EnemyAP : AP {

    private EnemyAP(int value) : base(value, 0, 100) {
    }

    public static EnemyAP Of(int value) {
        return new EnemyAP(value);
    }

}
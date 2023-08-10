using KataokaLib.System;

/*
 * 敵の体力のクラス
 */
public class EnemyHP : HP {

    private EnemyHP(int value) : base(value, 0, 1000) {
    }

    public static EnemyHP Of(int value) {
        return new EnemyHP(value);
    }

    public static EnemyHP operator-(EnemyHP hp, Ap ap) {
        if (ReferenceEquals(ap, null)) return hp;

        int value = Mathk.KeepValueWithinRange<int>(
            hp.Value - ap.Value,
            hp.MIN,
            hp.MAX
        );
        
        return new EnemyHP(value);
    }

}
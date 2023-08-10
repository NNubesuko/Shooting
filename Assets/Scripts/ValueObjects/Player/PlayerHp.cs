using System;
using KataokaLib.AutoTest;
using KataokaLib.System;

/*
 * プレイヤーの体力のクラス
 */
[ValueObject("Player", 0, 100)]
public class PlayerHp : HP {

    private PlayerHp(int value) : base(value, 0, 100) {
    }

    public static PlayerHp Of(int value) {
        return new PlayerHp(value);
    }

    public static PlayerHp operator-(PlayerHp hp, Ap ap) {
        int value = Mathk.KeepValueWithinRange<int>(
            hp.Value - ap.Value,
            hp.MIN,
            hp.MAX
        );

        return new PlayerHp(value);
    }

}

using KataokaLib.AutoTest;
using KataokaLib.System;

/*
 * プレイヤーの体力のクラス
 */
[ValueObject("Player", 0, 100)]
public class PlayerHP : HP {

    private PlayerHP(int value) : base(value, 0, 100) {
    }

    public static PlayerHP Of(int value) {
        return new PlayerHP(value);
    }

    public static PlayerHP operator-(PlayerHP hp, AP ap) {
        int value = Mathk.KeepValueWithinRange<int>(
            hp.Value - ap.Value,
            hp.MIN,
            hp.MAX
        );

        return new PlayerHP(value);
    }

}

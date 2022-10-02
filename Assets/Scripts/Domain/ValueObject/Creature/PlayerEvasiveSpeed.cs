using System;
using Systemk;
using UnityEngine;

/**
 * * プレイヤーの回避速度を格納するクラス
 */
public sealed class PlayerEvasiveSpeed {

    private int value;

    public const int MIN = 0;
    public const int MAX = 100;

    private PlayerEvasiveSpeed(int value) {
        ExceptionHandler.ThrowWhenInvalidValue<ArgumentException>(
            value,
            MIN,
            MAX,
            new ArgumentException(ExceptionMessage.argumentExceptionMessage)
        );

        this.value = value;
    }

    public static PlayerEvasiveSpeed Of(int value) {
        return new PlayerEvasiveSpeed(value);
    }

    public override string ToString() {
        return $"{value}";
    }

    public int Value {
        get { return value; }
    }

    public static PlayerEvasiveSpeed operator+(PlayerEvasiveSpeed lhHP, PlayerEvasiveSpeed rhHP) {
        int value = lhHP.Value + rhHP.Value;
        value = Mathk.KeepValueWithinRange(value, MIN, MAX);

        return new PlayerEvasiveSpeed(value);
    }

    public static PlayerEvasiveSpeed operator-(PlayerEvasiveSpeed lhHP, PlayerEvasiveSpeed rhHP) {
        int value = lhHP.Value - rhHP.Value;
        value = Mathk.KeepValueWithinRange(value, MIN, MAX);

        return new PlayerEvasiveSpeed(value);
    }

    public static PlayerEvasiveSpeed operator*(PlayerEvasiveSpeed lhHP, PlayerEvasiveSpeed rhHP) {
        int value = lhHP.Value * rhHP.Value;
        value = Mathk.KeepValueWithinRange(value, MIN, MAX);

        return new PlayerEvasiveSpeed(value);
    }

    public static PlayerEvasiveSpeed operator/(PlayerEvasiveSpeed lhHP, PlayerEvasiveSpeed rhHP) {
        if (rhHP.Value == 0)
            throw new DivideByZeroException(ExceptionMessage.divideByZeroExceptionMessage);

        int value = lhHP.Value / rhHP.Value;
        value = Mathk.KeepValueWithinRange(value, MIN, MAX);
        
        return new PlayerEvasiveSpeed(value);
    }

}

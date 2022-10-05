using System;
using Systemk;
using Systemk.Exceptions;
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

    public override int GetHashCode() {
        return new { value, MIN, MAX }.GetHashCode();
    }

    public override bool Equals(object obj) {
        if (obj == null) return false;
        if (obj == this) return true;

        if (obj is PlayerEvasiveSpeed otherPlayerEvasiveSpeed) {
            if (this.GetHashCode() == otherPlayerEvasiveSpeed.GetHashCode()) {
                return true;
            }
        }

        return false;
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

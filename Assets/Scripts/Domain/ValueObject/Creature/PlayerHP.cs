using System;
using Systemk;
using Systemk.Exceptions;

/**
 * * プレイヤーの体力を格納するクラス
 */
public struct PlayerHP {

    private int value;

    public const int MIN = 0;
    public const int MAX = 100;

    private PlayerHP(int value) {
        ExceptionHandler.ThrowWhenInvalidValue<ArgumentException>(
            value,
            MIN,
            MAX,
            new ArgumentException(ExceptionMessage.argumentExceptionMessage)
        );

        this.value = value;
    }

    public static PlayerHP Of(int value) {
        return new PlayerHP(value);
    }

    public override string ToString() {
        return $"{value}";
    }

    public override int GetHashCode() {
        return new { value, MIN, MAX }.GetHashCode();
    }

    public override bool Equals(object obj) {
        if (obj == null) return false;
        // if (obj == this) return true;

        if (obj is PlayerHP otherPlayerHP) {
            if (this.GetHashCode() == otherPlayerHP.GetHashCode()) {
                return true;
            }
        }

        return false;
    }

    public int Value {
        get { return value; }
    }
    
    public static PlayerHP operator+(PlayerHP lhHP, PlayerHP rhHP) {
        int value = lhHP.Value + rhHP.Value;
        value = Mathk.KeepValueWithinRange(value, MIN, MAX);

        return new PlayerHP(value);
    }

    public static PlayerHP operator-(PlayerHP lhHP, PlayerHP rhHP) {
        int value = lhHP.Value - rhHP.Value;
        value = Mathk.KeepValueWithinRange(value, MIN, MAX);

        return new PlayerHP(value);
    }

    public static PlayerHP operator*(PlayerHP lhHP, PlayerHP rhHP) {
        int value = lhHP.Value * rhHP.Value;
        value = Mathk.KeepValueWithinRange(value, MIN, MAX);

        return new PlayerHP(value);
    }

    public static PlayerHP operator/(PlayerHP lhHP, PlayerHP rhHP) {
        if (rhHP.Value == 0)
            throw new DivideByZeroException(ExceptionMessage.divideByZeroExceptionMessage);

        int value = lhHP.Value / rhHP.Value;
        value = Mathk.KeepValueWithinRange(value, MIN, MAX);
        
        return new PlayerHP(value);
    }

}

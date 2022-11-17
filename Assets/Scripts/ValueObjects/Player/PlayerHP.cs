using System;
using Systemk;
using Systemk.Exceptions;

/*
 * * プレイヤーの体力を格納する構造体
 */
public struct PlayerHP {

    public int Value { get; private set; }

    public const int MIN = 0;
    public const int MAX = 100;

    private PlayerHP(int value) {
        ExceptionHandler.ThrowWhenInvalidValue<ArgumentException>(
            value,
            MIN,
            MAX,
            new ArgumentException(ExceptionMessage.argumentExceptionMessage)
        );

        Value = value;
    }

    public static PlayerHP Of(int value) {
        return new PlayerHP(value);
    }

    public override string ToString() {
        return $"{Value}";
    }

    public override int GetHashCode() {
        return (Value, MIN, MAX).GetHashCode();
    }

    public override bool Equals(object obj) {
        return obj is PlayerHP other && this.Equals(other);
    }

    public bool Equals(PlayerHP other) {
        return this.GetHashCode() == other.GetHashCode();
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

    public static bool operator==(PlayerHP lhHP, PlayerHP rhHP) {
        return lhHP.Equals(rhHP);
    }

    public static bool operator!=(PlayerHP lhHP, PlayerHP rhHP) {
        return !(lhHP == rhHP);
    }

    public static bool operator<(PlayerHP lhHP, PlayerHP rhHP) {
        return lhHP.Value < rhHP.Value;
    }

    public static bool operator>(PlayerHP lhHP, PlayerHP rhHP) {
        return lhHP.Value > rhHP.Value;
    }

    public static bool operator<=(PlayerHP lhHP, PlayerHP rhHP) {
        return lhHP.Value <= rhHP.Value;
    }

    public static bool operator>=(PlayerHP lhHP, PlayerHP rhHP) {
        return lhHP.Value >= rhHP.Value;
    }

}

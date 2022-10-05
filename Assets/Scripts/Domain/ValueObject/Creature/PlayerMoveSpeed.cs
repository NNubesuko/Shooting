using System;
using Systemk;
using Systemk.Exceptions;

/**
 * * プレイヤーの移動速度を格納するクラス
 */
public sealed class PlayerMoveSpeed {

    private int value;

    public const int MIN = 0;
    public const int MAX = 10;

    public PlayerMoveSpeed(int value) {
        AssignRestrictedIntValueToValue(value);
    }

    public static PlayerMoveSpeed Of(int value) {
        return new PlayerMoveSpeed(value);
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

        if (obj is PlayerMoveSpeed otherPlayerMoveSpeed) {
            if (this.GetHashCode() == otherPlayerMoveSpeed.GetHashCode()) {
                return true;
            }
        }

        return false;
    }

    private void AssignRestrictedIntValueToValue(int value) {
        ExceptionHandler.ThrowWhenInvalidValue<ArgumentException>(
            value,
            MIN,
            MAX,
            new ArgumentException(ExceptionMessage.argumentExceptionMessage)
        );

        this.value = value;
    }

    public int Value {
        get { return value; }
    }

    public static PlayerMoveSpeed operator+(PlayerMoveSpeed lhSpeed, PlayerMoveSpeed rhSpeed) {
        int value = lhSpeed.Value + rhSpeed.Value;
        value = Mathk.KeepValueWithinRange(value, MIN, MAX);

        return new PlayerMoveSpeed(value);
    }

    public static PlayerMoveSpeed operator-(PlayerMoveSpeed lhSpeed, PlayerMoveSpeed rhSpeed) {
        int value = lhSpeed.Value - rhSpeed.Value;
        value = Mathk.KeepValueWithinRange(value, MIN, MAX);

        return new PlayerMoveSpeed(value);
    }

    public static PlayerMoveSpeed operator*(PlayerMoveSpeed lhSpeed, PlayerMoveSpeed rhSpeed) {
        int value = lhSpeed.Value * rhSpeed.Value;
        value = Mathk.KeepValueWithinRange(value, MIN, MAX);

        return new PlayerMoveSpeed(value);
    }

    public static PlayerMoveSpeed operator/(PlayerMoveSpeed lhSpeed, PlayerMoveSpeed rhSpeed) {
        if (rhSpeed.Value == 0)
            throw new DivideByZeroException(ExceptionMessage.divideByZeroExceptionMessage);

        int value = lhSpeed.Value / rhSpeed.Value;
        value = Mathk.KeepValueWithinRange(value, MIN, MAX);
        
        return new PlayerMoveSpeed(value);
    }

}

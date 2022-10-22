using System;
using Systemk;
using Systemk.Exceptions;
using UnityEngine;

/**
 * * プレイヤーの回避速度を格納するクラス
 */
public struct PlayerEvasiveSpeed {

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

    public int Value {
        get { return value; }
    }

    public override string ToString() {
        return $"{value}";
    }

    public override int GetHashCode() {
        return (value, MIN, MAX).GetHashCode();
    }

    public override bool Equals(object obj) {
        return obj is PlayerEvasiveSpeed other && this.Equals(other);
    }

    public bool Equals(PlayerEvasiveSpeed other) {
        return this.GetHashCode() == other.GetHashCode();
    }

    public static PlayerEvasiveSpeed operator+(
        PlayerEvasiveSpeed lhSpeed, PlayerEvasiveSpeed rhSpeed
    ) {
        int value = lhSpeed.Value + rhSpeed.Value;
        value = Mathk.KeepValueWithinRange(value, MIN, MAX);

        return new PlayerEvasiveSpeed(value);
    }

    public static PlayerEvasiveSpeed operator-(
        PlayerEvasiveSpeed lhSpeed, PlayerEvasiveSpeed rhSpeed
    ) {
        int value = lhSpeed.Value - rhSpeed.Value;
        value = Mathk.KeepValueWithinRange(value, MIN, MAX);

        return new PlayerEvasiveSpeed(value);
    }

    public static PlayerEvasiveSpeed operator*(
        PlayerEvasiveSpeed lhSpeed, PlayerEvasiveSpeed rhSpeed
    ) {
        int value = lhSpeed.Value * rhSpeed.Value;
        value = Mathk.KeepValueWithinRange(value, MIN, MAX);

        return new PlayerEvasiveSpeed(value);
    }

    public static PlayerEvasiveSpeed operator/(
        PlayerEvasiveSpeed lhSpeed, PlayerEvasiveSpeed rhSpeed
    ) {
        if (rhSpeed.Value == 0)
            throw new DivideByZeroException(ExceptionMessage.divideByZeroExceptionMessage);

        int value = lhSpeed.Value / rhSpeed.Value;
        value = Mathk.KeepValueWithinRange(value, MIN, MAX);
        
        return new PlayerEvasiveSpeed(value);
    }

    public static bool operator==(PlayerEvasiveSpeed lhSpeed, PlayerEvasiveSpeed rhSpeed) {
        return lhSpeed.Equals(rhSpeed);
    }

    public static bool operator!=(PlayerEvasiveSpeed lhSpeed, PlayerEvasiveSpeed rhSpeed) {
        return !(lhSpeed == rhSpeed);
    }

    public static bool operator<(PlayerEvasiveSpeed lhSpeed, PlayerEvasiveSpeed rhSpeed) {
        return lhSpeed.Value < rhSpeed.Value;
    }

    public static bool operator>(PlayerEvasiveSpeed lhSpeed, PlayerEvasiveSpeed rhSpeed) {
        return lhSpeed.Value > rhSpeed.Value;
    }

    public static bool operator<=(PlayerEvasiveSpeed lhSpeed, PlayerEvasiveSpeed rhSpeed) {
        return lhSpeed.Value <= rhSpeed.Value;
    }

    public static bool operator>=(PlayerEvasiveSpeed lhSpeed, PlayerEvasiveSpeed rhSpeed) {
        return lhSpeed.Value >= rhSpeed.Value;
    }

}

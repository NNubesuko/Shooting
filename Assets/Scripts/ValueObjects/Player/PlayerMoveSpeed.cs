using System;
using Systemk;
using Systemk.Exceptions;

/**
 * * プレイヤーの移動速度を格納するクラス
 */
public struct PlayerMoveSpeed {

    private int value;

    public const int MIN = 0;
    public const int MAX = 10;

    private PlayerMoveSpeed(int value) {
        ExceptionHandler.ThrowWhenInvalidValue<ArgumentException>(
            value,
            MIN,
            MAX,
            new ArgumentException(ExceptionMessage.argumentExceptionMessage)
        );

        this.value = value;
    }

    public static PlayerMoveSpeed Of(int value) {
        return new PlayerMoveSpeed(value);
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
        return obj is PlayerMoveSpeed other && this.Equals(other);
    }

    public bool Equals(PlayerMoveSpeed other) {
        return this.GetHashCode() == other.GetHashCode();
    }

    public static PlayerMoveSpeed operator+(
        PlayerMoveSpeed lhSpeedSpeed, PlayerMoveSpeed rhSpeedSpeed
    ) {
        int value = lhSpeedSpeed.Value + rhSpeedSpeed.Value;
        value = Mathk.KeepValueWithinRange(value, MIN, MAX);

        return new PlayerMoveSpeed(value);
    }

    public static PlayerMoveSpeed operator-(
        PlayerMoveSpeed lhSpeedSpeed, PlayerMoveSpeed rhSpeedSpeed
    ) {
        int value = lhSpeedSpeed.Value - rhSpeedSpeed.Value;
        value = Mathk.KeepValueWithinRange(value, MIN, MAX);

        return new PlayerMoveSpeed(value);
    }

    public static PlayerMoveSpeed operator*(
        PlayerMoveSpeed lhSpeedSpeed, PlayerMoveSpeed rhSpeedSpeed
    ) {
        int value = lhSpeedSpeed.Value * rhSpeedSpeed.Value;
        value = Mathk.KeepValueWithinRange(value, MIN, MAX);

        return new PlayerMoveSpeed(value);
    }

    public static PlayerMoveSpeed operator/(
        PlayerMoveSpeed lhSpeedSpeed, PlayerMoveSpeed rhSpeedSpeed
    ) {
        if (rhSpeedSpeed.Value == 0)
            throw new DivideByZeroException(ExceptionMessage.divideByZeroExceptionMessage);

        int value = lhSpeedSpeed.Value / rhSpeedSpeed.Value;
        value = Mathk.KeepValueWithinRange(value, MIN, MAX);
        
        return new PlayerMoveSpeed(value);
    }

    public static bool operator==(PlayerMoveSpeed lhSpeed, PlayerMoveSpeed rhSpeed) {
        return lhSpeed.Equals(rhSpeed);
    }

    public static bool operator!=(PlayerMoveSpeed lhSpeed, PlayerMoveSpeed rhSpeed) {
        return !(lhSpeed == rhSpeed);
    }

    public static bool operator<(PlayerMoveSpeed lhSpeed, PlayerMoveSpeed rhSpeed) {
        return lhSpeed.Value < rhSpeed.Value;
    }

    public static bool operator>(PlayerMoveSpeed lhSpeed, PlayerMoveSpeed rhSpeed) {
        return lhSpeed.Value > rhSpeed.Value;
    }

    public static bool operator<=(PlayerMoveSpeed lhSpeed, PlayerMoveSpeed rhSpeed) {
        return lhSpeed.Value <= rhSpeed.Value;
    }

    public static bool operator>=(PlayerMoveSpeed lhSpeed, PlayerMoveSpeed rhSpeed) {
        return lhSpeed.Value >= rhSpeed.Value;
    }

}

using System;
using Systemk;
using Systemk.Exceptions;

public struct BulletSpeed {

    private int value;

    private const int MIN = 0;
    private const int MAX = 100;

    private BulletSpeed(int value) {
        ExceptionHandler.ThrowWhenInvalidValue<ArgumentException>(
            value,
            MIN,
            MAX,
            new ArgumentException(ExceptionMessage.argumentExceptionMessage)
        );

        this.value = value;
    }

    public static BulletSpeed Of(int value) {
        return new BulletSpeed(value);
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
        return obj is BulletSpeed other && this.Equals(other);
    }

    public bool Equals(BulletSpeed other) {
        return this.GetHashCode() == other.GetHashCode();
    }

    public static BulletSpeed operator+(BulletSpeed lhSpeed, BulletSpeed rhSpeed) {
        int value = lhSpeed.Value + rhSpeed.Value;
        value = Mathk.KeepValueWithinRange(value, MIN, MAX);

        return new BulletSpeed(value);
    }

    public static BulletSpeed operator-(BulletSpeed lhSpeed, BulletSpeed rhSpeed) {
        int value = lhSpeed.Value - rhSpeed.Value;
        value = Mathk.KeepValueWithinRange(value, MIN, MAX);

        return new BulletSpeed(value);
    }

    public static BulletSpeed operator*(BulletSpeed lhSpeed, BulletSpeed rhSpeed) {
        int value = lhSpeed.Value * rhSpeed.Value;
        value = Mathk.KeepValueWithinRange(value, MIN, MAX);

        return new BulletSpeed(value);
    }

    public static BulletSpeed operator/(BulletSpeed lhSpeed, BulletSpeed rhSpeed) {
        if (rhSpeed.Value == 0)
            throw new DivideByZeroException(ExceptionMessage.divideByZeroExceptionMessage);

        int value = lhSpeed.Value / rhSpeed.Value;
        value = Mathk.KeepValueWithinRange(value, MIN, MAX);

        return new BulletSpeed(value);
    }

    public static bool operator==(BulletSpeed lhSpeed, BulletSpeed rhSpeed) {
        return lhSpeed.Equals(rhSpeed);
    }

    public static bool operator!=(BulletSpeed lhSpeed, BulletSpeed rhSpeed) {
        return !(lhSpeed == rhSpeed);
    }

    public static bool operator<(BulletSpeed lhSpeed, BulletSpeed rhSpeed) {
        return lhSpeed.Value < rhSpeed.Value;
    }

    public static bool operator>(BulletSpeed lhSpeed, BulletSpeed rhSpeed) {
        return lhSpeed.Value > rhSpeed.Value;
    }

    public static bool operator<=(BulletSpeed lhSpeed, BulletSpeed rhSpeed) {
        return lhSpeed.Value <= rhSpeed.Value;
    }

    public static bool operator>=(BulletSpeed lhSpeed, BulletSpeed rhSpeed) {
        return lhSpeed.Value >= rhSpeed.Value;
    }

}
using System;
using Systemk;
using Systemk.Exceptions;

public sealed class BulletSpeed {

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

    public override string ToString() {
        return $"{value}";
    }

    public override int GetHashCode() {
        return new { value, MIN, MAX }.GetHashCode();
    }

    public override bool Equals(object obj) {
        if (obj == null) return false;
        if (obj == this) return true;

        if (obj is BulletSpeed otherBulletSpeed) {
            if (this.GetHashCode() == otherBulletSpeed.GetHashCode()) {
                return true;
            }
        }

        return false;
    }

    public int Value {
        get { return value; }
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

}
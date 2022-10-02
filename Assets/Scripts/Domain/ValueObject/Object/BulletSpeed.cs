using System;
using Systemk;

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

    public int Value {
        get { return value; }
    }

    public static BulletSpeed operator+(BulletSpeed lhAP, BulletSpeed rhAP) {
        int value = lhAP.Value + rhAP.Value;
        value = Mathk.KeepValueWithinRange(value, MIN, MAX);

        return new BulletSpeed(value);
    }

    public static BulletSpeed operator-(BulletSpeed lhAP, BulletSpeed rhAP) {
        int value = lhAP.Value - rhAP.Value;
        value = Mathk.KeepValueWithinRange(value, MIN, MAX);

        return new BulletSpeed(value);
    }

    public static BulletSpeed operator*(BulletSpeed lhAP, BulletSpeed rhAP) {
        int value = lhAP.Value * rhAP.Value;
        value = Mathk.KeepValueWithinRange(value, MIN, MAX);

        return new BulletSpeed(value);
    }

    public static BulletSpeed operator/(BulletSpeed lhAP, BulletSpeed rhAP) {
        int value = lhAP.Value / rhAP.Value;
        value = Mathk.KeepValueWithinRange(value, MIN, MAX);

        return new BulletSpeed(value);
    }

}
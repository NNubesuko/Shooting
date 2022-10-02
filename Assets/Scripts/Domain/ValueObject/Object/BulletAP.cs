using System;
using Systemk;

public sealed class BulletAP {

    private int value;

    public const int MIN = 1;
    public const int MAX = 100;

    private BulletAP(int value) {
        ExceptionHandler.ThrowWhenInvalidValue<ArgumentException>(
            value,
            MIN,
            MAX,
            new ArgumentException(ExceptionMessage.argumentExceptionMessage)
        );

        this.value = value;
    }

    public static BulletAP Of(int value) {
        return new BulletAP(value);
    }

    public override string ToString() {
        return $"{value}";
    }

    public int Value {
        get { return value; }
    }

    public static BulletAP operator+(BulletAP lhAP, BulletAP rhAP) {
        int value = lhAP.Value + rhAP.Value;
        value = Mathk.KeepValueWithinRange(value, MIN, MAX);

        return new BulletAP(value);
    }

    public static BulletAP operator-(BulletAP lhAP, BulletAP rhAP) {
        int value = lhAP.Value - rhAP.Value;
        value = Mathk.KeepValueWithinRange(value, MIN, MAX);

        return new BulletAP(value);
    }

    public static BulletAP operator*(BulletAP lhAP, BulletAP rhAP) {
        int value = lhAP.Value * rhAP.Value;
        value = Mathk.KeepValueWithinRange(value, MIN, MAX);

        return new BulletAP(value);
    }

    public static BulletAP operator/(BulletAP lhAP, BulletAP rhAP) {
        int value = lhAP.Value / rhAP.Value;
        value = Mathk.KeepValueWithinRange(value, MIN, MAX);

        return new BulletAP(value);
    }

}
using System;
using Systemk;
using Systemk.Exceptions;

public struct BulletAP {

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
        return obj is BulletAP other && this.Equals(other);
    }

    public bool Equals(BulletAP other) {
        return this.GetHashCode() == other.GetHashCode();
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

    public static bool operator==(BulletAP lhAP, BulletAP rhAP) {
        return lhAP.Equals(rhAP);
    }

    public static bool operator!=(BulletAP lhAP, BulletAP rhAP) {
        return !(lhAP == rhAP);
    }

    public static bool operator<(BulletAP lhAP, BulletAP rhAP) {
        return lhAP.Value < rhAP.Value;
    }

    public static bool operator>(BulletAP lhAP, BulletAP rhAP) {
        return lhAP.Value > rhAP.Value;
    }

    public static bool operator<=(BulletAP lhAP, BulletAP rhAP) {
        return lhAP.Value <= rhAP.Value;
    }

    public static bool operator>=(BulletAP lhAP, BulletAP rhAP) {
        return lhAP.Value >= rhAP.Value;
    }

}
using System;
using Systemk;
using Systemk.Exceptions;

public struct BulletAP {

    public int Value { get; private set; }

    public const int MIN = 1;
    public const int MAX = 100;

    private BulletAP(int value) {
        ExceptionHandler.ThrowWhenInvalidValue<ArgumentException>(
            value,
            MIN,
            MAX,
            new ArgumentException(ExceptionMessage.argumentExceptionMessage)
        );

        Value = value;
    }

    public static BulletAP Of(int value) {
        return new BulletAP(value);
    }

    public override string ToString() {
        return $"{Value}";
    }

    public override int GetHashCode() {
        return (Value, MIN, MAX).GetHashCode();
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
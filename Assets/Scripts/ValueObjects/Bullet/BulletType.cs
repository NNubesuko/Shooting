using System;
using Systemk;
using Systemk.Exceptions;

public struct BulletType {

    public int Value { get; private set; }

    public const int MIN = 0;
    public const int MAX = 1;

    public static readonly BulletType Normal = new BulletType(0);
    public static readonly BulletType Head = new BulletType(1);

    private BulletType(int value) {
        ExceptionHandler.ThrowWhenInvalidValue<BulletTypeNotFoundException>(
            value,
            MIN,
            MAX,
            new BulletTypeNotFoundException(ExceptionMessage.bulletTypeNotFoundExceptionMessage)
        );

        Value = value;
    }

    public override string ToString() {
        return $"{Value}";
    }

    public override int GetHashCode() {
        return (Value, MIN, MAX).GetHashCode();
    }

    public override bool Equals(object obj) {
        return obj is BulletType other && this.Equals(other);
    }

    public bool Equals(BulletType other) {
        return this.GetHashCode() == other.GetHashCode();
    }

    public static BulletType Of(int value) {
        ExceptionHandler.ThrowWhenEnumDoesNotExist<BulletTypeNotFoundException>(
            MIN,
            MAX,
            new BulletTypeNotFoundException(ExceptionMessage.bulletTypeNotFoundExceptionMessage),
            Normal.Value,
            Head.Value
        );

        return new BulletType(value);
    }

}
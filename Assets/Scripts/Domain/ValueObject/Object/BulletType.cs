using System;
using Systemk;
using Systemk.Exceptions;

public sealed class BulletType {

    private int value;

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

        this.value = value;
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

        if (obj is BulletType otherBulletType) {
            if (this.GetHashCode() == otherBulletType.GetHashCode()) {
                return true;
            }
        }

        return false;
    }

    public int Value {
        get { return value; }
    }

    /**
     * * 意図しない型変換を防ぐため、明示的な型変換のみ実装
     */
    public static explicit operator BulletType(int value) {
        return new BulletType(value);
    }

}

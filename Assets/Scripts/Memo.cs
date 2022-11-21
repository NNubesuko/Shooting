using System;

// ! c# 11 のジェネリクス同士の演算に対応できたら、対応したい

public class ExceptionHandlerk {

    public static void ThrowsWHenInValidValue(int value, int MIN, int MAX, Exception exception) {
        if (value < MIN || value > MAX) throw exception;
    }

    public static void ThrowsWHenInValidValue<T>(T value, T MIN, T MAX, Exception exception) {
        if ((dynamic)value < (dynamic)MIN || (dynamic)value > (dynamic)MAX) throw exception;
    }

    public static Exception ArgumentException(string param) {
        return new ArgumentException(ExceptionMessagek.argumentExceptionMessage ,param);
    }

}

public class ExceptionMessagek {

    public const string argumentExceptionMessage = "不正な値が渡されました";

}

public interface ISingleValueObject<T> {

    T Value { get; }
    T MIN { get; }
    T MAX { get; }

}

public abstract class SingleValueObject<T> : ISingleValueObject<T> {

    public T Value { get; }
    public T MIN { get; }
    public T MAX { get; }

    protected SingleValueObject(T value, T MIN, T MAX) {
        this.MIN = MIN;
        this.MAX = MAX;

        ExceptionHandlerk.ThrowsWHenInValidValue(
            value,
            MIN,
            MAX,
            ExceptionHandlerk.ArgumentException(nameof(value))
        );

        Value = value;
    }

    public override string ToString() {
        return $"{Value}";
    }

    public override int GetHashCode() {
        return (Value, MIN, MAX, GetType().Name).GetHashCode();
    }

    public override bool Equals(object obj) {
        if (ReferenceEquals(obj, null)) return false;
        if (ReferenceEquals(this, obj)) return true;

        return obj is SingleValueObject<T> other && Equals(other);
    }

    public bool Equals(SingleValueObject<T> other) {
        return this.GetHashCode() == other.GetHashCode();
    }

    public static bool ClassEquals(SingleValueObject<T> lh, SingleValueObject<T> rh) {
        return lh.GetType().Name.Equals(rh.GetType().Name);
    }

    public static bool operator==(SingleValueObject<T> lh, SingleValueObject<T> rh) {
        return lh.Equals(rh);
    }

    public static bool operator!=(SingleValueObject<T> lh, SingleValueObject<T> rh) {
        return !(lh == rh);
    }

    /*
     * 型が異なる場合に、スローを投げるのもあり
     */
    public static bool operator<(SingleValueObject<T> lh, SingleValueObject<T> rh) {
        return ClassEquals(lh, rh) && (dynamic)lh.Value < (dynamic)rh.Value;
    }

    public static bool operator>(SingleValueObject<T> lh, SingleValueObject<T> rh) {
        return ClassEquals(lh, rh) && (dynamic)lh.Value > (dynamic)rh.Value;
    }

    public static bool operator<=(SingleValueObject<T> lh, SingleValueObject<T> rh) {
        return ClassEquals(lh, rh) && (dynamic)lh.Value <= (dynamic)rh.Value;
    }

    public static bool operator>=(SingleValueObject<T> lh, SingleValueObject<T> rh) {
        return ClassEquals(lh, rh) && (dynamic)lh.Value >= (dynamic)rh.Value;
    }

}

public abstract class HP : SingleValueObject<int> {

    protected HP(int value, int MIN, int MAX) : base(value, MIN, MAX) {
    }

}

public class PlayerHPk : HP {

    public PlayerHPk(int value) : base(value, 0, 100) {
    }

}

public class EnemyHPk : HP {

    public EnemyHPk(int value) : base(value, 0, 1000) {
    }

}

using System;

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

// public abstract class HP : ISingleValueObjectable<int> {

//     public int Value { get; }
//     public int MIN { get; }
//     public int MAX { get; }

//     protected HP(int value, int MIN, int MAX) {
//         this.MIN = MIN;
//         this.MAX = MAX;

//         ExceptionHandlerk.ThrowsWHenInValidValue(
//             value,
//             MIN,
//             MAX,
//             new ArgumentException(ExceptionMessagek.argumentExceptionMessage, nameof(value))
//         );

//         Value = value;
//     }

//     public override string ToString() {
//         return $"{Value}";
//     }

//     public override int GetHashCode() {
//         return (Value, MIN, MAX, GetType().Name).GetHashCode();
//     }

//     public override bool Equals(object obj) {
//         if (ReferenceEquals(obj, null)) return false;
//         if (ReferenceEquals(this, obj)) return true;

//         return obj is HP other && Equals(other);
//     }

//     public bool Equals(HP other) {
//         return this.GetHashCode() == other.GetHashCode();
//     }

//     public static bool ClassEquals(HP lhHP, HP rhHP) {
//         return lhHP.GetType().Name.Equals(rhHP.GetType().Name);
//     }

//     public static bool operator==(HP lhHP, HP rhHP) {
//         return lhHP.Equals(rhHP);
//     }

//     public static bool operator!=(HP lhHP, HP rhHP) {
//         return !(lhHP == rhHP);
//     }

//     public static bool operator<(HP lhHP, HP rhHP) {
//         return ClassEquals(lhHP, rhHP) && lhHP.Value < rhHP.Value;
//     }

//     public static bool operator>(HP lhHP, HP rhHP) {
//         return ClassEquals(lhHP, rhHP) && lhHP.Value < rhHP.Value;
//     }

//     public static bool operator<=(HP lhHP, HP rhHP) {
//         return ClassEquals(lhHP, rhHP) && lhHP.Value <= rhHP.Value;
//     }

//     public static bool operator>=(HP lhHP, HP rhHP) {
//         return ClassEquals(lhHP, rhHP) && lhHP.Value <= rhHP.Value;
//     }

// }

// public class PlayerHPk : HP {

//     private PlayerHPk(int value) : base(value, 0, 100) {
//     }

//     public static PlayerHPk Of(int value) {
//         return new PlayerHPk(value);
//     }

// }

// public class EnemyHPk : HP {

//     private EnemyHPk(int value) : base(value, 0, 1000) {
//     }

//     public static EnemyHPk Of(int value) {
//         return new EnemyHPk(value);
//     }

// }

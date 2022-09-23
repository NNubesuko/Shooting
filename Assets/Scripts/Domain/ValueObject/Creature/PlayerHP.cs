using System;
using Systemk;

public sealed class PlayerHP {

    private int value;

    public const int MIN = 0;
    public const int MAX = 100;

    private PlayerHP(int value) {
        ExceptionHandler.ThrowWhenInvalidValue<ArgumentException>(
            value,
            MIN,
            MAX,
            new ArgumentException(ExceptionMessage.argumentExceptionMessage)
        );

        this.value = value;
    }

    public static PlayerHP Of(int value) {
        return new PlayerHP(value);
    }

    public override string ToString() {
        return $"{value}";
    }

    public int Value {
        get { return value; }
    }

    public static PlayerHP operator+(PlayerHP lhHP, PlayerHP rhHP) {
        int value = lhHP.Value + rhHP.Value;

        ExceptionHandler.ThrowWhenInvalidValue<ArithmeticException>(
            value,
            MIN,
            MAX,
            new ArithmeticException(ExceptionMessage.arithmeticExceptionMessage)
        );

        return new PlayerHP(value);
    }

    public static PlayerHP operator-(PlayerHP lhHP, PlayerHP rhHP) {
        int value = lhHP.Value - rhHP.Value;

        ExceptionHandler.ThrowWhenInvalidValue<ArithmeticException>(
            value,
            MIN,
            MAX,
            new ArithmeticException(ExceptionMessage.arithmeticExceptionMessage)
        );

        return new PlayerHP(value);
    }

    public static PlayerHP operator*(PlayerHP lhHP, PlayerHP rhHP) {
        int value = lhHP.Value * rhHP.Value;

        ExceptionHandler.ThrowWhenInvalidValue<ArithmeticException>(
            value,
            MIN,
            MAX,
            new ArithmeticException(ExceptionMessage.arithmeticExceptionMessage)
        );

        return new PlayerHP(value);
    }

    public static PlayerHP operator/(PlayerHP lhHP, PlayerHP rhHP) {
        if (rhHP.Value == 0)
            throw new DivideByZeroException(ExceptionMessage.divideByZeroExceptionMessage);

        int value = lhHP.Value / rhHP.Value;
        return new PlayerHP(value);
    }

}

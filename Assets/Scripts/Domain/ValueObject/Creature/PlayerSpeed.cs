using System;
using Systemk;

public sealed class PlayerSpeed {

    private int value;

    public const int MIN = 0;
    public const int MAX = 10;

    public PlayerSpeed(int value) {
        AssignRestrictedIntValueToValue(value);
    }

    public static PlayerSpeed Of(int value) {
        return new PlayerSpeed(value);
    }

    public override string ToString() {
        return $"{value}";
    }

    private void AssignRestrictedIntValueToValue(int value) {
        ExceptionHandler.ThrowWhenInvalidValue<ArgumentException>(
            value,
            MIN,
            MAX,
            new ArgumentException(ExceptionMessage.argumentExceptionMessage)
        );

        this.value = value;
    }

    public int Value {
        get { return value; }
    }

    public static PlayerSpeed operator+(PlayerSpeed lhSpeed, PlayerSpeed rhSpeed) {
        int value = lhSpeed.Value + rhSpeed.Value;

        ExceptionHandler.ThrowWhenInvalidValue<ArithmeticException>(
            value,
            MIN,
            MAX,
            new ArithmeticException(ExceptionMessage.arithmeticExceptionMessage)
        );

        return new PlayerSpeed(value);
    }

    public static PlayerSpeed operator-(PlayerSpeed lhSpeed, PlayerSpeed rhSpeed) {
        int value = lhSpeed.Value - rhSpeed.Value;

        ExceptionHandler.ThrowWhenInvalidValue<ArithmeticException>(
            value,
            MIN,
            MAX,
            new ArithmeticException(ExceptionMessage.arithmeticExceptionMessage)
        );

        return new PlayerSpeed(value);
    }

    public static PlayerSpeed operator*(PlayerSpeed lhSpeed, PlayerSpeed rhSpeed) {
        int value = lhSpeed.Value * rhSpeed.Value;

        ExceptionHandler.ThrowWhenInvalidValue<ArithmeticException>(
            value,
            MIN,
            MAX,
            new ArithmeticException(ExceptionMessage.arithmeticExceptionMessage)
        );

        return new PlayerSpeed(value);
    }

    public static PlayerSpeed operator/(PlayerSpeed lhSpeed, PlayerSpeed rhSpeed) {
        if (rhSpeed.Value == 0)
            throw new DivideByZeroException(ExceptionMessage.divideByZeroExceptionMessage);

        int value = lhSpeed.Value / rhSpeed.Value;
        return new PlayerSpeed(value);
    }

}

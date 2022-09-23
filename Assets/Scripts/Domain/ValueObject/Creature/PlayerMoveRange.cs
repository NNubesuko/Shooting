using System;
using Systemk;

public class PlayerMoveRange {

    private float lowValue;
    private float highValue;

    public const float MIN = -100f;
    public const float MAX = 100f;

    public PlayerMoveRange(float lowValue, float highValue) {
        AssignRestrictedIntValueToValue(lowValue, highValue);
    }

    public static PlayerMoveRange Of(float lowValue, float highValue) {
        return new PlayerMoveRange(lowValue, highValue);
    }

    public override string ToString() {
        return $"{lowValue}, {highValue}";
    }

    /**
     * 範囲を扱うクラスのため、低い値と高い値が同じ値ではおかしい。
     * そのため、低い値が高い値より大きい（同数は含めない）場合は、スローを投げるようにしている。
     */
    private void AssignRestrictedIntValueToValue(float lowValue, float highValue) {
        ExceptionHandler.ThrowWhenInvalidValue<ArgumentException>(
            lowValue,
            highValue,
            MIN,
            MAX,
            new ArgumentException(ExceptionMessage.argumentExceptionMessage)
        );

        ExceptionHandler.ThrowWhenLowValueGiggerThanHighValue<ArgumentException>(
            lowValue,
            highValue,
            new ArgumentException(ExceptionMessage.argumentExceptionMessage)
        );

        this.lowValue = lowValue;
        this.highValue = highValue;
    }

    public float LowValue {
        get { return lowValue; }
    }

    public float HighValue {
        get { return highValue; }
    }

    public static PlayerMoveRange operator+(PlayerMoveRange lhRange, PlayerMoveRange rhRange) {
        PlayerMoveRange value = PlayerMoveRange.Of(
            lhRange.LowValue + rhRange.LowValue,
            lhRange.HighValue + rhRange.HighValue
        );

        ExceptionHandler.ThrowWhenInvalidValue<ArithmeticException>(
            value.LowValue,
            value.HighValue,
            MIN,
            MAX,
            new ArithmeticException(ExceptionMessage.arithmeticExceptionMessage)
        );

        return value;
    }

    public static PlayerMoveRange operator-(PlayerMoveRange lhRange, PlayerMoveRange rhRange) {
        PlayerMoveRange value = PlayerMoveRange.Of(
            lhRange.LowValue - rhRange.LowValue,
            lhRange.HighValue - rhRange.HighValue
        );

        ExceptionHandler.ThrowWhenInvalidValue<ArithmeticException>(
            value.LowValue,
            value.HighValue,
            MIN,
            MAX,
            new ArithmeticException(ExceptionMessage.arithmeticExceptionMessage)
        );

        return value;
    }

    public static PlayerMoveRange operator*(PlayerMoveRange lhRange, PlayerMoveRange rhRange) {
        PlayerMoveRange value = PlayerMoveRange.Of(
            lhRange.LowValue * rhRange.LowValue,
            lhRange.HighValue * rhRange.HighValue
        );

        ExceptionHandler.ThrowWhenInvalidValue<ArithmeticException>(
            value.LowValue,
            value.HighValue,
            MIN,
            MAX,
            new ArithmeticException(ExceptionMessage.arithmeticExceptionMessage)
        );

        return value;
    }

    public static PlayerMoveRange operator/(PlayerMoveRange lhRange, PlayerMoveRange rhRange) {
        if (rhRange.LowValue == 0f || rhRange.HighValue == 0f)
            throw new DivideByZeroException(ExceptionMessage.divideByZeroExceptionMessage);

        PlayerMoveRange value = PlayerMoveRange.Of(
            lhRange.LowValue / rhRange.LowValue,
            lhRange.HighValue / rhRange.HighValue
        );

        return value;
    }

}
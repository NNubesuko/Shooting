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
     * 低い値が大きい値より大きい場合に、スローを投げるようにしている
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
        ExceptionHandler.ThrowWhenInvalidValue<ArithmeticException>(
            lhRange.LowValue + rhRange.LowValue,
            lhRange.HighValue + rhRange.HighValue,
            MIN,
            MAX,
            new ArithmeticException(ExceptionMessage.arithmeticExceptionMessage)
        );

        return PlayerMoveRange.Of(
            lhRange.LowValue + rhRange.LowValue,
            lhRange.HighValue + rhRange.HighValue
        );
    }

    public static PlayerMoveRange operator-(PlayerMoveRange lhRange, PlayerMoveRange rhRange) {
        ExceptionHandler.ThrowWhenInvalidValue<ArithmeticException>(
            lhRange.LowValue - rhRange.LowValue,
            lhRange.HighValue - rhRange.HighValue,
            MIN,
            MAX,
            new ArithmeticException(ExceptionMessage.arithmeticExceptionMessage)
        );

        return PlayerMoveRange.Of(
            lhRange.LowValue - rhRange.LowValue,
            lhRange.HighValue - rhRange.HighValue
        );
    }

    public static PlayerMoveRange operator*(PlayerMoveRange lhRange, PlayerMoveRange rhRange) {
        ExceptionHandler.ThrowWhenInvalidValue<ArithmeticException>(
            lhRange.LowValue * rhRange.LowValue,
            lhRange.HighValue * rhRange.HighValue,
            MIN,
            MAX,
            new ArithmeticException(ExceptionMessage.arithmeticExceptionMessage)
        );

        return PlayerMoveRange.Of(
            lhRange.LowValue * rhRange.LowValue,
            lhRange.HighValue * rhRange.HighValue
        );
    }

    public static PlayerMoveRange operator/(PlayerMoveRange lhRange, PlayerMoveRange rhRange) {
        if (rhRange.LowValue == 0f || rhRange.HighValue == 0f)
            throw new DivideByZeroException(ExceptionMessage.divideByZeroExceptionMessage);

        return PlayerMoveRange.Of(
            lhRange.LowValue / rhRange.LowValue,
            lhRange.HighValue / rhRange.HighValue
        );
    }

}
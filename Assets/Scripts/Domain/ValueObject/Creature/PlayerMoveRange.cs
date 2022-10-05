using System;
using Systemk;
using Systemk.Exceptions;
using UnityEngine;

public sealed class PlayerMoveRange {

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

    public override int GetHashCode() {
        return new { lowValue, highValue, MIN, MAX }.GetHashCode();
    }

    public override bool Equals(object obj) {
        if (obj == null) return false;
        if (obj == this) return true;

        if (obj is PlayerMoveRange otherPlayerMoveRange) {
            if (this.GetHashCode() == otherPlayerMoveRange.GetHashCode()) {
                return true;
            }
        }

        return false;
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

    public static float KeepPositionWithinRange(
        float position,
        PlayerMoveRange playerMoveRange
    ) {
        if (position < playerMoveRange.LowValue) {
            return playerMoveRange.LowValue;
        }

        if (position > playerMoveRange.HighValue) {
            return playerMoveRange.HighValue;
        }

        return position;
    }

    public float LowValue {
        get { return lowValue; }
    }

    public float HighValue {
        get { return highValue; }
    }

    public static PlayerMoveRange operator+(PlayerMoveRange lhRange, PlayerMoveRange rhRange) {
        float[] resultLowValueAndHighValue = Mathk.KeepValueWithinRange(
            lhRange.LowValue + rhRange.LowValue,
            lhRange.HighValue + rhRange.HighValue,
            MIN,
            MAX
        );

        return PlayerMoveRange.Of(
            resultLowValueAndHighValue[0],
            resultLowValueAndHighValue[1]
        );
    }

    public static PlayerMoveRange operator-(PlayerMoveRange lhRange, PlayerMoveRange rhRange) {
        float[] resultLowValueAndHighValue = Mathk.KeepValueWithinRange(
            lhRange.LowValue - rhRange.LowValue,
            lhRange.HighValue - rhRange.HighValue,
            MIN,
            MAX
        );

        return PlayerMoveRange.Of(
            resultLowValueAndHighValue[0],
            resultLowValueAndHighValue[1]
        );
    }

    public static PlayerMoveRange operator*(PlayerMoveRange lhRange, PlayerMoveRange rhRange) {
        float[] resultLowValueAndHighValue = Mathk.KeepValueWithinRange(
            lhRange.LowValue * rhRange.LowValue,
            lhRange.HighValue * rhRange.HighValue,
            MIN,
            MAX
        );

        return PlayerMoveRange.Of(
            resultLowValueAndHighValue[0],
            resultLowValueAndHighValue[1]
        );
    }

    public static PlayerMoveRange operator/(PlayerMoveRange lhRange, PlayerMoveRange rhRange) {
        if (rhRange.LowValue == 0f || rhRange.HighValue == 0f)
            throw new DivideByZeroException(ExceptionMessage.divideByZeroExceptionMessage);

        float lowValue = lhRange.LowValue / rhRange.LowValue;
        float highValue = lhRange.HighValue / rhRange.HighValue;

        lowValue = Mathk.KeepValueWithinRange(
            lowValue,
            highValue,
            MIN,
            MAX
        )[0];

        highValue = Mathk.KeepValueWithinRange(
            lowValue,
            highValue,
            MIN,
            MAX
        )[1];

        return PlayerMoveRange.Of(lowValue, highValue);
    }

}
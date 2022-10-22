using System;
using Systemk;
using Systemk.Exceptions;
using UnityEngine;

public struct PlayerMoveRange {

    private float lowValue;
    private float highValue;

    public const float MIN = -100f;
    public const float MAX = 100f;

    /**
     * 低い値が大きい値より大きい場合に、スローを投げるようにしている
     */
    public PlayerMoveRange(float lowValue, float highValue) {
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

    public static PlayerMoveRange Of(float lowValue, float highValue) {
        return new PlayerMoveRange(lowValue, highValue);
    }

    public float LowValue {
        get { return lowValue; }
    }

    public float HighValue {
        get { return highValue; }
    }

    public override string ToString() {
        return $"{lowValue}, {highValue}";
    }

    public override int GetHashCode() {
        return (lowValue, highValue, MIN, MAX).GetHashCode();
    }

    public override bool Equals(object obj) {
        return obj is PlayerMoveRange other && this.Equals(other);
    }

    public bool Equals(PlayerMoveRange other) {
        return this.GetHashCode() == other.GetHashCode();
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

    public static bool operator==(PlayerMoveRange lhRange, PlayerMoveRange rhRange) {
        return lhRange.Equals(rhRange);
    }

    public static bool operator!=(PlayerMoveRange lhRange, PlayerMoveRange rhRange) {
        return !(lhRange == rhRange);
    }

    // public static bool operator<(PlayerMoveRange lhRange, PlayerMoveRange rhRange) {
    //     return lhRange.lowValue < rhRange.lowValue && 
    //     // return lhRange.Value < rhRange.Value;
    // }

    // public static bool operator>(PlayerMoveRange lhRange, PlayerMoveRange rhRange) {
    //     // return lhRange.Value > rhRange.Value;
    // }

    // public static bool operator<=(PlayerMoveRange lhRange, PlayerMoveRange rhRange) {
    //     // return lhRange.Value <= rhRange.Value;
    // }

    // public static bool operator>=(PlayerMoveRange lhRange, PlayerMoveRange rhRange) {
    //     // return lhRange.Value >= rhRange.Value;
    // }

}
using System;
using Systemk;
using Systemk.Exceptions;
using UnityEngine;

public struct PlayerMoveRange {

    public float LowValue { get; private set; }
    public float HighValue { get; private set; }

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

        LowValue = lowValue;
        HighValue = highValue;
    }

    public static PlayerMoveRange Of(float lowValue, float highValue) {
        return new PlayerMoveRange(lowValue, highValue);
    }

    public float Size {
        get { return Mathf.Abs(HighValue - LowValue); }
    }

    public override string ToString() {
        return $"{LowValue}, {HighValue}";
    }

    public override int GetHashCode() {
        return (LowValue, HighValue, MIN, MAX).GetHashCode();
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

    public static Vector2 KeepPositionWithinRange(
        Vector2 velocity,
        PlayerMoveRange moveHorizontalRange,
        PlayerMoveRange moveVerticalRange
    ) {
        velocity.x = KeepPositionWithinRange(velocity.x, moveHorizontalRange);
        velocity.y = KeepPositionWithinRange(velocity.y, moveVerticalRange);

        return velocity;
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

    public static bool operator<(PlayerMoveRange lhRange, PlayerMoveRange rhRange) {
        return lhRange.Size < rhRange.Size;
    }

    public static bool operator>(PlayerMoveRange lhRange, PlayerMoveRange rhRange) {
        return lhRange.Size > rhRange.Size;
    }

    public static bool operator<=(PlayerMoveRange lhRange, PlayerMoveRange rhRange) {
        return lhRange.Size <= rhRange.Size;
    }

    public static bool operator>=(PlayerMoveRange lhRange, PlayerMoveRange rhRange) {
        return lhRange.Size >= rhRange.Size;
    }

}
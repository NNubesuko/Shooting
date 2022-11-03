using System;
using System.Collections;
using System.Collections.Generic;
using Systemk;
using Systemk.Exceptions;
using UnityEngine;

/*
 * * プレイヤーの獲得スコアを格納する構造体
 */
public struct PlayerScore {

    private int value;
    
    public const int MIN = 0;
    public const int MAX = int.MaxValue;

    private PlayerScore(int value) {
        ExceptionHandler.ThrowWhenInvalidValue<ArgumentException>(
            value,
            MIN,
            MAX,
            new ArgumentException(ExceptionMessage.argumentExceptionMessage)
        );

        this.value = value;
    }

    public static PlayerScore Of(int value) {
        return new PlayerScore(value);
    }

    public int Value {
        get { return value; }
    }

    public override string ToString() {
        return $"{value}";
    }

    public override int GetHashCode() {
        return (value, MIN, MAX).GetHashCode();
    }

    public override bool Equals(object obj) {
        return obj is PlayerScore other && this.Equals(other);
    }

    public bool Equals(PlayerScore other) {
        return this.GetHashCode() == other.GetHashCode();
    }

    public static PlayerScore operator+(PlayerScore lhScore, PlayerScore rhScore) {
        int value = lhScore.Value + rhScore.Value;
        value = Mathk.KeepValueWithinRange(value, MIN, MAX);

        return new PlayerScore(value);
    }

    public static PlayerScore operator-(PlayerScore lhScore, PlayerScore rhScore) {
        int value = lhScore.Value - rhScore.Value;
        value = Mathk.KeepValueWithinRange(value, MIN, MAX);

        return new PlayerScore(value);
    }

    public static PlayerScore operator*(PlayerScore lhScore, PlayerScore rhScore) {
        int value = lhScore.Value * rhScore.Value;
        value = Mathk.KeepValueWithinRange(value, MIN, MAX);

        return new PlayerScore(value);
    }

    public static PlayerScore operator/(PlayerScore lhScore, PlayerScore rhScore) {
        if (rhScore.Value == 0)
            throw new DivideByZeroException(ExceptionMessage.divideByZeroExceptionMessage);

        int value = lhScore.Value / rhScore.Value;
        value = Mathk.KeepValueWithinRange(value, MIN, MAX);

        return new PlayerScore(value);
    }

    public static bool operator==(PlayerScore lhScore, PlayerScore rhScore) {
        return lhScore.Equals(rhScore);
    }

    public static bool operator!=(PlayerScore lhScore, PlayerScore rhScore) {
        return !(lhScore == rhScore);
    }

    public static bool operator<(PlayerScore lhScore, PlayerScore rhScore) {
        return lhScore.Value < rhScore.Value;
    }

    public static bool operator>(PlayerScore lhScore, PlayerScore rhScore) {
        return lhScore.Value > rhScore.Value;
    }

    public static bool operator<=(PlayerScore lhScore, PlayerScore rhScore) {
        return lhScore.Value <= rhScore.Value;
    }

    public static bool operator>=(PlayerScore lhScore, PlayerScore rhScore) {
        return lhScore.Value >= rhScore.Value;
    }

}

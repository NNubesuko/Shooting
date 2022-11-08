using System;
using System.Collections;
using System.Collections.Generic;
using Systemk;
using Systemk.Exceptions;
using UnityEngine;

/*
 * * 敵の獲得ポイントを格納する構造体
 */
public struct EnemyPoint {

    public int Value { get; private set; }

    private const int MIN = 0;
    private const int MAX = 100;

    private EnemyPoint(int value) {
        ExceptionHandler.ThrowWhenInvalidValue<ArgumentException>(
            value,
            MIN,
            MAX,
            new ArgumentException(ExceptionMessage.argumentExceptionMessage)
        );

        Value = value;
    }

    public static EnemyPoint Of(int value) {
        return new EnemyPoint(value);
    }

    public override string ToString() {
        return $"{Value}";
    }

    public override int GetHashCode() {
        return (Value, MIN, MAX).GetHashCode();
    }

    public override bool Equals(object obj) {
        return obj is EnemyPoint other && this.Equals(other);
    }

    public bool Equals(EnemyPoint other) {
        return this.GetHashCode() == other.GetHashCode();
    }

    public static EnemyPoint operator+(EnemyPoint lhPoint, EnemyPoint rhPoint) {
        int value = lhPoint.Value + rhPoint.Value;
        value = Mathk.KeepValueWithinRange(value, MIN, MAX);

        return new EnemyPoint(value);
    }

    public static EnemyPoint operator-(EnemyPoint lhPoint, EnemyPoint rhPoint) {
        int value = lhPoint.Value - rhPoint.Value;
        value = Mathk.KeepValueWithinRange(value, MIN, MAX);

        return new EnemyPoint(value);
    }

    public static EnemyPoint operator*(EnemyPoint lhPoint, EnemyPoint rhPoint) {
        int value = lhPoint.Value * rhPoint.Value;
        value = Mathk.KeepValueWithinRange(value, MIN, MAX);

        return new EnemyPoint(value);
    }

    public static EnemyPoint operator/(EnemyPoint lhPoint, EnemyPoint rhPoint) {
        if (rhPoint.Value == 0)
            throw new DivideByZeroException(ExceptionMessage.divideByZeroExceptionMessage);

        int value = lhPoint.Value / rhPoint.Value;
        value = Mathk.KeepValueWithinRange(value, MIN, MAX);

        return new EnemyPoint(value);
    }

    public static bool operator==(EnemyPoint lhPoint, EnemyPoint rhPoint) {
        return lhPoint.Equals(rhPoint);
    }

    public static bool operator!=(EnemyPoint lhPoint, EnemyPoint rhPoint) {
        return !(lhPoint == rhPoint);
    }

    public static bool operator<(EnemyPoint lhPoint, EnemyPoint rhPoint) {
        return lhPoint.Value < rhPoint.Value;
    }

    public static bool operator>(EnemyPoint lhPoint, EnemyPoint rhPoint) {
        return lhPoint.Value > rhPoint.Value;
    }

    public static bool operator<=(EnemyPoint lhPoint, EnemyPoint rhPoint) {
        return lhPoint.Value <= rhPoint.Value;
    }

    public static bool operator>=(EnemyPoint lhPoint, EnemyPoint rhPoint) {
        return lhPoint.Value >= rhPoint.Value;
    }

}

using System;
using System.Collections;
using System.Collections.Generic;
using Systemk;
using Systemk.Exceptions;
using UnityEngine;

public struct EnemyPoint {

    private int value;

    private const int MIN = 0;
    private const int MAX = 100;

    private EnemyPoint(int value) {
        ExceptionHandler.ThrowWhenInvalidValue<ArgumentException>(
            value,
            MIN,
            MAX,
            new ArgumentException(ExceptionMessage.argumentExceptionMessage)
        );

        this.value = value;
    }

    public static EnemyPoint Of(int value) {
        return new EnemyPoint(value);
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

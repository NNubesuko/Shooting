using System;
using System.Collections;
using System.Collections.Generic;
using Systemk;
using Systemk.Exceptions;
using UnityEngine;

public struct EnemyMoveSpeed {

    public int Value { get; private set; }

    public const int MIN = 0;
    public const int MAX = 25;

    private EnemyMoveSpeed(int value) {
        ExceptionHandler.ThrowWhenInvalidValue<ArgumentException>(
            value,
            MIN,
            MAX,
            new ArgumentException(ExceptionMessage.argumentExceptionMessage)
        );

        Value = value;
    }

    public static EnemyMoveSpeed Of(int value) {
        return new EnemyMoveSpeed(value);
    }

    public override string ToString() {
        return $"{Value}";
    }

    public override int GetHashCode() {
        return (Value, MIN, MAX).GetHashCode();
    }

    public override bool Equals(object obj) {
        return obj is EnemyMoveSpeed other && this.Equals(other);
    }

    public bool Equals(EnemyMoveSpeed other) {
        return this.GetHashCode() == other.GetHashCode();
    }

    public static EnemyMoveSpeed operator+(EnemyMoveSpeed lhSpeed, EnemyMoveSpeed rhSpeed) {
        int value = lhSpeed.Value + rhSpeed.Value;
        value = Mathk.KeepValueWithinRange(value, MIN, MAX);

        return new EnemyMoveSpeed(value);
    }

    public static EnemyMoveSpeed operator-(EnemyMoveSpeed lhSpeed, EnemyMoveSpeed rhSpeed) {
        int value = lhSpeed.Value - rhSpeed.Value;
        value = Mathk.KeepValueWithinRange(value, MIN, MAX);

        return new EnemyMoveSpeed(value);
    }

    public static EnemyMoveSpeed operator*(EnemyMoveSpeed lhSpeed, EnemyMoveSpeed rhSpeed) {
        int value = lhSpeed.Value * rhSpeed.Value;
        value = Mathk.KeepValueWithinRange(value, MIN, MAX);

        return new EnemyMoveSpeed(value);
    }

    public static EnemyMoveSpeed operator/(EnemyMoveSpeed lhSpeed, EnemyMoveSpeed rhSpeed) {
        if (rhSpeed.Value == 0)
            throw new DivideByZeroException(ExceptionMessage.divideByZeroExceptionMessage);

        int value = lhSpeed.Value / rhSpeed.Value;
        value = Mathk.KeepValueWithinRange(value, MIN, MAX);

        return new EnemyMoveSpeed(value);
    }

    public static bool operator==(EnemyMoveSpeed lhSpeed, EnemyMoveSpeed rhSpeed) {
        return lhSpeed.Equals(rhSpeed);
    }

    public static bool operator!=(EnemyMoveSpeed lhSpeed, EnemyMoveSpeed rhSpeed) {
        return !(lhSpeed == rhSpeed);
    }

    public static bool operator<(EnemyMoveSpeed lhSpeed, EnemyMoveSpeed rhSpeed) {
        return lhSpeed.Value < rhSpeed.Value;
    }

    public static bool operator>(EnemyMoveSpeed lhSpeed, EnemyMoveSpeed rhSpeed) {
        return lhSpeed.Value > rhSpeed.Value;
    }

    public static bool operator<=(EnemyMoveSpeed lhSpeed, EnemyMoveSpeed rhSpeed) {
        return lhSpeed.Value <= rhSpeed.Value;
    }

    public static bool operator>=(EnemyMoveSpeed lhSpeed, EnemyMoveSpeed rhSpeed) {
        return lhSpeed.Value >= rhSpeed.Value;
    }

}

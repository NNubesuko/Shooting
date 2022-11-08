using System;
using System.Collections;
using System.Collections.Generic;
using Systemk;
using Systemk.Exceptions;
using UnityEngine;

/*
 * * 敵の攻撃力を格納する構造体
 */
public struct EnemyAP {

    public int Value { get; private set; }

    public const int MIN = 0;
    public const int MAX = 100;

    private EnemyAP(int value) {
        ExceptionHandler.ThrowWhenInvalidValue<ArgumentException>(
            value,
            MIN,
            MAX,
            new ArgumentException(ExceptionMessage.argumentExceptionMessage)
        );

        Value = value;
    }

    public static EnemyAP Of(int value) {
        return new EnemyAP(value);
    }

    public override string ToString() {
        return $"{Value}";
    }

    public override int GetHashCode() {
        return (Value, MIN, MAX).GetHashCode();
    }

    public override bool Equals(object obj) {
        return obj is EnemyAP other && this.Equals(other);
    }

    public bool Equals(EnemyAP other) {
        return this.GetHashCode() == other.GetHashCode();
    }

    public static EnemyAP operator+(EnemyAP lhAP, EnemyAP rhAP) {
        int value = lhAP.Value + rhAP.Value;
        value = Mathk.KeepValueWithinRange(value, MIN, MAX);

        return new EnemyAP(value);
    }

    public static EnemyAP operator-(EnemyAP lhAP, EnemyAP rhAP) {
        int value = lhAP.Value - rhAP.Value;
        value = Mathk.KeepValueWithinRange(value, MIN, MAX);

        return new EnemyAP(value);
    }

    public static EnemyAP operator*(EnemyAP lhAP, EnemyAP rhAP) {
        int value = lhAP.Value * rhAP.Value;
        value = Mathk.KeepValueWithinRange(value, MIN, MAX);

        return new EnemyAP(value);
    }

    public static EnemyAP operator/(EnemyAP lhAP, EnemyAP rhAP) {
        if (rhAP.Value == 0)
            throw new DivideByZeroException(ExceptionMessage.divideByZeroExceptionMessage);

        int value = lhAP.Value / rhAP.Value;
        value = Mathk.KeepValueWithinRange(value, MIN, MAX);

        return new EnemyAP(value);
    }

    public static bool operator==(EnemyAP lhAP, EnemyAP rhAP) {
        return lhAP.Equals(rhAP);
    }

    public static bool operator!=(EnemyAP lhAP, EnemyAP rhAP) {
        return !(lhAP == rhAP);
    }

    public static bool operator<(EnemyAP lhAP, EnemyAP rhAP) {
        return lhAP.Value < rhAP.Value;
    }

    public static bool operator>(EnemyAP lhAP, EnemyAP rhAP) {
        return lhAP.Value > rhAP.Value;
    }

    public static bool operator<=(EnemyAP lhAP, EnemyAP rhAP) {
        return lhAP.Value <= rhAP.Value;
    }

    public static bool operator>=(EnemyAP lhAP, EnemyAP rhAP) {
        return lhAP.Value >= rhAP.Value;
    }

}

using System;
using System.Collections;
using System.Collections.Generic;
using Systemk;
using Systemk.Exceptions;
using UnityEngine;

/*
 * * 敵の体力を格納する構造体
 */
public struct EnemyHP {

    public int Value { get; private set; }

    public const int MIN = 0;
    public const int MAX = 100;

    private EnemyHP(int value) {
        ExceptionHandler.ThrowWhenInvalidValue<ArgumentException>(
            value,
            MIN,
            MAX,
            new ArgumentException(ExceptionMessage.argumentExceptionMessage)
        );

        Value = value;
    }

    public static EnemyHP Of(int value) {
        return new EnemyHP(value);
    }

    public override string ToString() {
        return $"{Value}";
    }

    public override int GetHashCode() {
        return (Value, MIN, MAX).GetHashCode();
    }

    public override bool Equals(object obj) {
        return obj is EnemyHP other && this.Equals(other);
    }

    public bool Equals(EnemyHP other) {
        return this.GetHashCode() == other.GetHashCode();
    }

    public static EnemyHP operator+(EnemyHP lhHP, EnemyHP rhHP) {
        int value = lhHP.Value + rhHP.Value;
        value = Mathk.KeepValueWithinRange(value, MIN, MAX);

        return new EnemyHP(value);
    }

    public static EnemyHP operator-(EnemyHP lhHP, EnemyHP rhHP) {
        int value = lhHP.Value - rhHP.Value;
        value = Mathk.KeepValueWithinRange(value, MIN, MAX);

        return new EnemyHP(value);
    }

    public static EnemyHP operator*(EnemyHP lhHP, EnemyHP rhHP) {
        int value = lhHP.Value * rhHP.Value;
        value = Mathk.KeepValueWithinRange(value, MIN, MAX);

        return new EnemyHP(value);
    }

    public static EnemyHP operator/(EnemyHP lhHP, EnemyHP rhHP) {
        if (rhHP.Value == 0)
            throw new DivideByZeroException(ExceptionMessage.divideByZeroExceptionMessage);

        int value = lhHP.Value / rhHP.Value;
        value = Mathk.KeepValueWithinRange(value, MIN, MAX);

        return new EnemyHP(value);
    }

    public static bool operator==(EnemyHP lhHP, EnemyHP rhHP) {
        return lhHP.Equals(rhHP);
    }

    public static bool operator!=(EnemyHP lhHP, EnemyHP rhHP) {
        return !(lhHP == rhHP);
    }

    public static bool operator<(EnemyHP lhHP, EnemyHP rhHP) {
        return lhHP.Value < rhHP.Value;
    }

    public static bool operator>(EnemyHP lhHP, EnemyHP rhHP) {
        return lhHP.Value > rhHP.Value;
    }

    public static bool operator<=(EnemyHP lhHP, EnemyHP rhHP) {
        return lhHP.Value <= rhHP.Value;
    }

    public static bool operator>=(EnemyHP lhHP, EnemyHP rhHP) {
        return lhHP.Value >= rhHP.Value;
    }

}
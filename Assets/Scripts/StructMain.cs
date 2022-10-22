using System;
using Systemk;
using Systemk.Exceptions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct StructMain {

    private int value;

    public const int MIN = 0;
    public const int MAX = 10;

    private StructMain(int value) {
        ExceptionHandler.ThrowWhenInvalidValue<ArgumentException>(
            value,
            MIN,
            MAX,
            new ArgumentException(ExceptionMessage.argumentExceptionMessage)
        );

        this.value = value;
    }

    public static StructMain Of(int value) {
        return new StructMain(value);
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
        return obj is StructMain other && this.Equals(other);
    }

    public bool Equals(StructMain structMain) {
        return this.GetHashCode() == structMain.GetHashCode();
    }

    public static StructMain operator+(StructMain lhs, StructMain rhs) {
        int value = lhs.Value + rhs.Value;
        value = Mathk.KeepValueWithinRange(value, MIN, MAX);

        return new StructMain(value);
    }

    public static StructMain operator-(StructMain lhs, StructMain rhs) {
        int value = lhs.Value - rhs.Value;
        value = Mathk.KeepValueWithinRange(value, MIN, MAX);

        return new StructMain(value);
    }

    public static StructMain operator*(StructMain lhs, StructMain rhs) {
        int value = lhs.Value * rhs.Value;
        value = Mathk.KeepValueWithinRange(value, MIN, MAX);

        return new StructMain(value);
    }

    public static StructMain operator/(StructMain lhs, StructMain rhs) {
        if (rhs.Value == 0)
            throw new DivideByZeroException(ExceptionMessage.divideByZeroExceptionMessage);

        int value = lhs.Value / rhs.Value;
        value = Mathk.KeepValueWithinRange(value, MIN, MAX);

        return new StructMain(value);
    }

    public static bool operator==(StructMain lhs, StructMain rhs) {
        return lhs.Equals(rhs);
    }

    public static bool operator!=(StructMain lhs, StructMain rhs) {
        return !(lhs == rhs);
    }

    public static bool operator<(StructMain lhs, StructMain rhs) {
        return lhs.Value < rhs.Value;
    }

    public static bool operator>(StructMain lhs, StructMain rhs) {
        return lhs.Value > rhs.Value;
    }

    public static bool operator<=(StructMain lhs, StructMain rhs) {
        return lhs.Value <= rhs.Value;
    }

    public static bool operator>=(StructMain lhs, StructMain rhs) {
        return lhs.Value >= rhs.Value;
    }

}

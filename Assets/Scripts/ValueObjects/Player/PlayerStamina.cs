using System;
using Systemk;
using Systemk.Exceptions;

/*
 * * プレイヤーのスタミナを格納する構造体
 */
public struct PlayerStamina {

    private int value;

    public const int MIN = 0;
    public const int MAX = 100;

    private PlayerStamina(int value) {
        ExceptionHandler.ThrowWhenInvalidValue<ArgumentException>(
            value,
            MIN,
            MAX,
            new ArgumentException(ExceptionMessage.argumentExceptionMessage)
        );

        this.value = value;
    }

    public static PlayerStamina Of(int value) {
        return new PlayerStamina(value);
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
        return obj is PlayerStamina other && this.Equals(other);
    }

    public bool Equals(PlayerStamina other) {
        return this.GetHashCode() == other.GetHashCode();
    }
    
    public static PlayerStamina operator+(PlayerStamina lhStamina, PlayerStamina rhStamina) {
        int value = lhStamina.Value + rhStamina.Value;
        value = Mathk.KeepValueWithinRange(value, MIN, MAX);

        return new PlayerStamina(value);
    }

    public static PlayerStamina operator-(PlayerStamina lhStamina, PlayerStamina rhStamina) {
        int value = lhStamina.Value - rhStamina.Value;
        value = Mathk.KeepValueWithinRange(value, MIN, MAX);

        return new PlayerStamina(value);
    }

    public static PlayerStamina operator*(PlayerStamina lhStamina, PlayerStamina rhStamina) {
        int value = lhStamina.Value * rhStamina.Value;
        value = Mathk.KeepValueWithinRange(value, MIN, MAX);

        return new PlayerStamina(value);
    }

    public static PlayerStamina operator/(PlayerStamina lhStamina, PlayerStamina rhStamina) {
        if (rhStamina.Value == 0)
            throw new DivideByZeroException(ExceptionMessage.divideByZeroExceptionMessage);

        int value = lhStamina.Value / rhStamina.Value;
        value = Mathk.KeepValueWithinRange(value, MIN, MAX);
        
        return new PlayerStamina(value);
    }

    public static bool operator==(PlayerStamina lhStamina, PlayerStamina rhStamina) {
        return lhStamina.Equals(rhStamina);
    }

    public static bool operator!=(PlayerStamina lhStamina, PlayerStamina rhStamina) {
        return !(lhStamina == rhStamina);
    }

    public static bool operator<(PlayerStamina lhStamina, PlayerStamina rhStamina) {
        return lhStamina.Value < rhStamina.Value;
    }

    public static bool operator>(PlayerStamina lhStamina, PlayerStamina rhStamina) {
        return lhStamina.Value > rhStamina.Value;
    }

    public static bool operator<=(PlayerStamina lhStamina, PlayerStamina rhStamina) {
        return lhStamina.Value <= rhStamina.Value;
    }

    public static bool operator>=(PlayerStamina lhStamina, PlayerStamina rhStamina) {
        return lhStamina.Value >= rhStamina.Value;
    }

}

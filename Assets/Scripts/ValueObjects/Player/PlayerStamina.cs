using System;
using Systemk;
using Systemk.Exceptions;

/*
 * * プレイヤーのスタミナを格納する構造体
 */
public struct PlayerStamina {

    public float Value { get; private set; }

    public const float MIN = 0f;
    public const float MAX = 100f;

    private PlayerStamina(float value) {
        ExceptionHandler.ThrowWhenInvalidValue<ArgumentException>(
            value,
            MIN,
            MAX,
            new ArgumentException(ExceptionMessage.argumentExceptionMessage)
        );

        Value = value;
    }

    public static PlayerStamina Of(float value) {
        return new PlayerStamina(value);
    }

    public override string ToString() {
        return $"{Value}";
    }

    public override int GetHashCode() {
        return (Value, MIN, MAX).GetHashCode();
    }

    public override bool Equals(object obj) {
        return obj is PlayerStamina other && this.Equals(other);
    }

    public bool Equals(PlayerStamina other) {
        return this.GetHashCode() == other.GetHashCode();
    }
    
    public static PlayerStamina operator+(PlayerStamina lhStamina, PlayerStamina rhStamina) {
        float value = lhStamina.Value + rhStamina.Value;
        value = Mathk.KeepValueWithinRange(value, MIN, MAX);

        return new PlayerStamina(value);
    }

    public static PlayerStamina operator-(PlayerStamina lhStamina, PlayerStamina rhStamina) {
        float value = lhStamina.Value - rhStamina.Value;
        value = Mathk.KeepValueWithinRange(value, MIN, MAX);

        return new PlayerStamina(value);
    }

    public static PlayerStamina operator*(PlayerStamina lhStamina, PlayerStamina rhStamina) {
        float value = lhStamina.Value * rhStamina.Value;
        value = Mathk.KeepValueWithinRange(value, MIN, MAX);

        return new PlayerStamina(value);
    }

    public static PlayerStamina operator/(PlayerStamina lhStamina, PlayerStamina rhStamina) {
        if (rhStamina.Value == 0)
            throw new DivideByZeroException(ExceptionMessage.divideByZeroExceptionMessage);

        float value = lhStamina.Value / rhStamina.Value;
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

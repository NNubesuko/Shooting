using System;
using Systemk;

/**
 * * プレイヤーの移動速度を格納するクラス
 */
public sealed class PlayerMoveSpeed {

    private int value;

    public const int MIN = 0;
    public const int MAX = 10;

    public PlayerMoveSpeed(int value) {
        AssignRestrictedIntValueToValue(value);
    }

    public static PlayerMoveSpeed Of(int value) {
        return new PlayerMoveSpeed(value);
    }

    public override string ToString() {
        return $"{value}";
    }

    private void AssignRestrictedIntValueToValue(int value) {
        ExceptionHandler.ThrowWhenInvalidValue<ArgumentException>(
            value,
            MIN,
            MAX,
            new ArgumentException(ExceptionMessage.argumentExceptionMessage)
        );

        this.value = value;
    }

    public int Value {
        get { return value; }
    }

    /**
     * TODO: すべての演算子はスローを投げるのではなく、MINとMAXで制限をかける
     */
    public static PlayerMoveSpeed operator+(PlayerMoveSpeed lhSpeed, PlayerMoveSpeed rhSpeed) {
        int value = lhSpeed.Value + rhSpeed.Value;

        ExceptionHandler.ThrowWhenInvalidValue<ArithmeticException>(
            value,
            MIN,
            MAX,
            new ArithmeticException(ExceptionMessage.arithmeticExceptionMessage)
        );

        return new PlayerMoveSpeed(value);
    }

    public static PlayerMoveSpeed operator-(PlayerMoveSpeed lhSpeed, PlayerMoveSpeed rhSpeed) {
        int value = lhSpeed.Value - rhSpeed.Value;

        ExceptionHandler.ThrowWhenInvalidValue<ArithmeticException>(
            value,
            MIN,
            MAX,
            new ArithmeticException(ExceptionMessage.arithmeticExceptionMessage)
        );

        return new PlayerMoveSpeed(value);
    }

    public static PlayerMoveSpeed operator*(PlayerMoveSpeed lhSpeed, PlayerMoveSpeed rhSpeed) {
        int value = lhSpeed.Value * rhSpeed.Value;

        ExceptionHandler.ThrowWhenInvalidValue<ArithmeticException>(
            value,
            MIN,
            MAX,
            new ArithmeticException(ExceptionMessage.arithmeticExceptionMessage)
        );

        return new PlayerMoveSpeed(value);
    }

    public static PlayerMoveSpeed operator/(PlayerMoveSpeed lhSpeed, PlayerMoveSpeed rhSpeed) {
        if (rhSpeed.Value == 0)
            throw new DivideByZeroException(ExceptionMessage.divideByZeroExceptionMessage);

        int value = lhSpeed.Value / rhSpeed.Value;
        return new PlayerMoveSpeed(value);
    }

}

using System;

public sealed class PlayerHP {

    private int value;

    public const int MIN = 0;
    public const int MAX = 100;

    private const string argumentExceptionMessage = "不正な値が渡されました。";

    private PlayerHP(int value) {
        AssignRestrictedIntValueToValue(value);
    }

    public static PlayerHP Of(int value) {
        return new PlayerHP(value);
    }

    private void AssignRestrictedIntValueToValue(int value) {
        if (value < MIN || value > MAX) throw new ArgumentException(argumentExceptionMessage);

        this.value = (int)value;
    }

    public int Value {
        get { return value; }
    }

}

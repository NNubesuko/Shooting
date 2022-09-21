using System;

public sealed class PlayerSpeed {

    private int value;

    private int MIN = 0;
    private int MAX = 10;

    private string argumentExceptionMessage = "不正な値が渡されました。";

    public PlayerSpeed(int value) {
        AssignRestrictedIntValueToValue(value);
    }

    public static PlayerSpeed Of(int value) {
        return new PlayerSpeed(value);
    }

    private void AssignRestrictedIntValueToValue(int value) {
        if (value < MIN || value > MAX) throw new ArgumentException(argumentExceptionMessage);

        this.value = value;
    }

    public int Value {
        get { return value; }
    }

}

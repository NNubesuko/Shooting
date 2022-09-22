using System;
using Systemk;

public sealed class PlayerSpeed {

    private int value;

    private int MIN = 0;
    private int MAX = 10;

    public PlayerSpeed(int value) {
        AssignRestrictedIntValueToValue(value);
    }

    public static PlayerSpeed Of(int value) {
        return new PlayerSpeed(value);
    }

    private void AssignRestrictedIntValueToValue(int value) {
        if (value < MIN || value > MAX)
            throw new ArgumentException(ExceptionMessage.argumentExceptionMessage);

        this.value = value;
    }

    public int Value {
        get { return value; }
    }

}

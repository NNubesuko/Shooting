using System;

public class PlayerHP {

    private int value;

    public const int MIN = 0;
    public const int MAX = 100;

    private const string argumentExceptionMessage = "不正な値が渡されました。";

    private PlayerHP() {
        IncludeValue(MIN);
    }

    private PlayerHP(int? value) {
        IncludeValue(value);
    }

    public static PlayerHP Of(int? value) {
        return new PlayerHP(value);
    }

    private void IncludeValue(int? value) {
        try {
            if (value == null) throw new ArgumentException(argumentExceptionMessage);
        } catch (ArgumentException) {
            value = MIN;
        }

        if (value < MIN || value > MAX) throw new ArgumentException(argumentExceptionMessage);

        this.value = (int)value;
    }

    public int Value {
        get { return value; }
    }

}

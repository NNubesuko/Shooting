using KataokaLib.ValueObject;

public abstract class Speed : SingleValueObject<int> {

    protected Speed(int value, int MIN, int MAX) : base(value, MIN, MAX) {
    }

}

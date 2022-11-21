using KataokaLib.ValueObject;

public abstract class HP : SingleValueObject<int> {

    protected HP(int value, int MIN, int MAX) : base(value, MIN, MAX) {
    }

}

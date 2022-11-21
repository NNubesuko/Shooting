using KataokaLib.ValueObject;

public abstract class AP : SingleValueObject<int> {

    protected AP(int value, int MIN, int MAX) : base(value, MIN, MAX) {
    }

}

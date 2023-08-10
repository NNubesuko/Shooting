using KataokaLib.ValueObject;

public abstract class Ap : SingleValueObject<int> {

    protected Ap(int value, int MIN, int MAX) : base(value, MIN, MAX) {
    }

}

using KataokaLib.ValueObject;

public abstract class MaxCount : SingleValueObject<int> {

    protected MaxCount(int value, int MIN, int MAX) : base(value, MIN, MAX) {
    }

}
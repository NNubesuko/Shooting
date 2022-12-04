using KataokaLib.ValueObject;

public class MaxCount : SingleValueObject<int> {

    protected MaxCount(int value, int MIN, int MAX) : base(value, MIN, MAX) {
    }

}
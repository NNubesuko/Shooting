using KataokaLib.ValueObject;

public class Count : SingleValueObject<int> {

    protected Count(int value, int MIN, int MAX) : base(value, MIN, MAX) {
    }

}
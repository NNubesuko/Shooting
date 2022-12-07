using KataokaLib.ValueObject;

public abstract class Point : SingleValueObject<int> {

    protected Point(int value, int MIN, int MAX) : base(value, MIN, MAX) {
    }

}
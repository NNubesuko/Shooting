using KataokaLib.ValueObject;

public class Point : SingleValueObject<int> {

    protected Point(int value, int MIN, int MAX) : base(value, MIN, MAX) {
    }

}
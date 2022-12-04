using KataokaLib.ValueObject;

public class Score : SingleValueObject<int> {

    protected Score(int value, int MIN, int MAX) : base(value, MIN, MAX) {
    }

}
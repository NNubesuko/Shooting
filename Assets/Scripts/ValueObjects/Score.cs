using KataokaLib.ValueObject;

public abstract class Score : SingleValueObject<int> {

    protected Score(int value, int MIN, int MAX) : base(value, MIN, MAX) {
    }

}
using KataokaLib.ValueObject;

public abstract class Range : RangeValueObject<float> {

    public Range(float start, float end, float MIN, float MAX) : base(start, end, MIN, MAX) {
    }

}
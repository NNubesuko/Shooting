using KataokaLib.ValueObject;

public abstract class Distance : SingleValueObject<float> {

    protected Distance(float value, float MIN, float MAX) : base(value, MIN, MAX) {
    }

}
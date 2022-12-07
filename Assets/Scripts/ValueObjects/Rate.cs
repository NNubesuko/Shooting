using KataokaLib.ValueObject;

public abstract class Rate : SingleValueObject<float> {

    protected Rate(float value, float MIN, float MAX) : base(value, MIN, MAX) {
    }

}
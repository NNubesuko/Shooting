using KataokaLib.ValueObject;

public class Rate : SingleValueObject<float> {

    protected Rate(float value, float MIN, float MAX) : base(value, MIN, MAX) {
    }

}
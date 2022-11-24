using KataokaLib.ValueObject;

public abstract class Speed : SingleValueObject<float> {

    protected Speed(float value, float MIN, float MAX) : base(value, MIN, MAX) {
    }

}

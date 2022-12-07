using KataokaLib.ValueObject;

public abstract class Magnification : SingleValueObject<float> {

    public Magnification(float value, float MIN, float MAX) : base(value, MIN, MAX) {
    }

}
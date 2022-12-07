using KataokaLib.ValueObject;

public abstract class Stamina : SingleValueObject<float> {

    public Stamina(float value, float MIN, float MAX) : base(value, MIN, MAX) {
    }

}
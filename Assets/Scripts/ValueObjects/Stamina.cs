using KataokaLib.ValueObject;

public class Stamina : SingleValueObject<float> {

    public Stamina(float value, float MIN, float MAX) : base(value, MIN, MAX) {
    }

}
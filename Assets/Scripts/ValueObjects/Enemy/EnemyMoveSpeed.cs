using KataokaLib.ValueObject;

public class EnemyMoveSpeed : SingleValueObject<float> {

    private EnemyMoveSpeed(float value) : base(value, 0f, 10f) {
    }

    public static EnemyMoveSpeed Of(float value) {
        return new EnemyMoveSpeed(value);
    }

}
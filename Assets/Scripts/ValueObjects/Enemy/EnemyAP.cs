using KataokaLib.ValueObject;

public class EnemyAP : SingleValueObject<int> {

    private EnemyAP(int value) : base(value, 0, 100) {
    }

    public static EnemyAP Of(int value) {
        return new EnemyAP(value);
    }

}
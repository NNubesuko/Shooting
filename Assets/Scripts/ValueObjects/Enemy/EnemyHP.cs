using KataokaLib.ValueObject;

public class EnemyHP : SingleValueObject<int> {

    private EnemyHP(int value) : base(value, 0, 1000) {
    }

    public static EnemyHP Of(int value) {
        return new EnemyHP(value);
    }

}
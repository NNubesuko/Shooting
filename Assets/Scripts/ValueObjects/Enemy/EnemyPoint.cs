public class EnemyPoint : Point {

    private EnemyPoint(int value) : base(value, 0, 100) {
    }

    public static EnemyPoint Of(int value) {
        return new EnemyPoint(value);
    }

}
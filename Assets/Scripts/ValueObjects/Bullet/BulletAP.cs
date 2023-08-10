public class BulletAP : Ap {

    private BulletAP(int value) : base(value, 0, 100) {
    }

    public static BulletAP Of(int value) {
        return new BulletAP(value);
    }

}
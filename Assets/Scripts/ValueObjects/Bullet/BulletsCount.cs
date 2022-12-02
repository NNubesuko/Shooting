public class BulletsCount : Count {

    private BulletsCount(int value) : base(value, 0, 300) {
    }

    public static BulletsCount Of(int value) {
        return new BulletsCount(value);
    }

    public static bool operator<(BulletsCount count, int value) {
        return count.Value < value;
    }

    public static bool operator>(BulletsCount count, int value) {
        return count.Value > value;
    }

}
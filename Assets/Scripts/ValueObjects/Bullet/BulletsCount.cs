public class BulletsCount : Count {

    private BulletsCount(int value) : base(value, 0, int.MaxValue) {
    }

    public static BulletsCount Of(int value) {
        return new BulletsCount(value);
    }

    public static BulletsCount operator-(BulletsMaxCount maxCount, BulletsCount count) {
        return new BulletsCount(maxCount.Value - count.Value);
    }

    public static BulletsCount operator++(BulletsCount count) {
        return new BulletsCount(count.Value + 1);
    }

    public static bool operator<=(BulletsCount count, BulletsMaxCount maxCount) {
        return count.Value <= maxCount.Value;
    }

    public static bool operator>=(BulletsCount count, BulletsMaxCount maxCount) {
        return count.Value >= maxCount.Value;
    }

}
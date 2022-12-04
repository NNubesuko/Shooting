public class BulletsMaxCount : MaxCount {

    private BulletsMaxCount(int value) : base(value, 0, int.MaxValue) {
    }

    public static BulletsMaxCount Of(int value) {
        return new BulletsMaxCount(value); 
    }

}

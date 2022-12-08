public class PlayerHorizontalMoveRange : Range {

    private PlayerHorizontalMoveRange(float start, float end) : base(start, end, -10f, 10f) {
    }

    public static PlayerHorizontalMoveRange Of(float start, float end) {
        return new PlayerHorizontalMoveRange(start, end);
    }

}

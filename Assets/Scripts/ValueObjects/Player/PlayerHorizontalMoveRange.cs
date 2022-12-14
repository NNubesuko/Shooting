public class PlayerHorizontalMoveRange : Range {

    private PlayerHorizontalMoveRange(float start, float end) : base(start, end, -10f, 10f) {
    }

    public static PlayerHorizontalMoveRange Of(float start, float end) {
        return new PlayerHorizontalMoveRange(start, end);
    }

    public float WithinRange(float horizontalPosition) {
        if (horizontalPosition < Start) return Start;
        if (horizontalPosition > End) return End;
        return horizontalPosition;
    }

}

public class PlayerVerticalMoveRange : Range {

    private PlayerVerticalMoveRange(float start, float end) : base(start, end, -10f, 10f) {
    }

    public static PlayerVerticalMoveRange Of(float start, float end) {
        return new PlayerVerticalMoveRange(start, end);
    }

    public float WithinRange(float verticalPosition) {
        if (verticalPosition < Start) return Start;
        if (verticalPosition > End) return End;
        return verticalPosition;
    }

}
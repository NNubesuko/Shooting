public class PlayerScore : Score {

    private PlayerScore(int value) : base(value, 0, int.MaxValue) {
    }

    public static PlayerScore Of(int value) {
        return new PlayerScore(value);
    }

    public static PlayerScore operator+(PlayerScore score, Point point) {
        return new PlayerScore(score.Value + point.Value);
    }

}
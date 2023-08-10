public interface Player : IMovable, IDamagable {

    /*
     * プレイヤーのステータスプロパティ
     */
    PlayerHp HP { get; }
    PlayerStamina Stamina { get; }
    PlayerMoveSpeed MoveSpeed { get; }
    PlayerEvasionSpeed EvasionSpeed { get; }
    PlayerEvasionDistance EvasionDistance { get; }
    PlayerHorizontalMoveRange HorizontalMoveRange { get; }
    PlayerVerticalMoveRange VerticalMoveRange { get; }
    PlayerScore Score { get; }
    bool IsDeath { get; }

    /*
     * ステータスの初期化
     */
    void Init(
        PlayerHp hp,
        PlayerStamina stamina,
        PlayerMoveSpeed moveSpeed,
        PlayerEvasionSpeed evasionSpeed,
        PlayerEvasionDistance evasionDistance,
        PlayerHorizontalMoveRange horizontalMoveRange,
        PlayerVerticalMoveRange verticalMoveRange
    );

    void AddScore(Point point);

}
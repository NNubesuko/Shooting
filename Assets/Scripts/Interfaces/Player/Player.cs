public interface Player : IMovable, IDamagable {

    /*
     * プレイヤーのステータスプロパティ
     */
    PlayerHP HP { get; }
    PlayerStamina Stamina { get; }
    PlayerMoveSpeed MoveSpeed { get; }
    PlayerEvasionSpeed EvasionSpeed { get; }
    PlayerEvasionDistance EvasionDistance { get; }
    PlayerScore Score { get; }
    bool IsDeath { get; }

    /*
     * ステータスの初期化
     */
    void Init(
        PlayerHP hp,
        PlayerStamina stamina,
        PlayerMoveSpeed moveSpeed,
        PlayerEvasionSpeed evasionSpeed,
        PlayerEvasionDistance evasionDistance
    );

    void AddScore(Point point);

}
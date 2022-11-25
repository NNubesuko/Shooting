public interface Player : IMovable {

    /*
     * プレイヤーのステータスプロパティ
     */
    PlayerHP HP { get; }
    PlayerStamina Stamina { get; }
    PlayerMoveSpeed MoveSpeed { get; }
    PlayerEvasionSpeed EvasionSpeed { get; }

    /*
     * ステータスの初期化
     */
    void Init(
        PlayerHP hp,
        PlayerStamina stamina,
        PlayerMoveSpeed moveSpeed,
        PlayerEvasionSpeed evasionSpeed
    );

}
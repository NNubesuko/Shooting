public interface Player {

    PlayerHP HP { get; }
    PlayerStamina Stamina { get; }
    PlayerMoveSpeed MoveSpeed { get; }
    PlayerEvasionSpeed EvasionSpeed { get; }

    void Init(
        PlayerHP hp,
        PlayerStamina stamina,
        PlayerMoveSpeed moveSpeed,
        PlayerEvasionSpeed evasionSpeed
    );

}
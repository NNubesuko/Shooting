using Interfaces.Character;

public interface Player : IDamager, IMover {

    PlayerHP HP { get; }
    PlayerStamina Stamina { get; }
    PlayerMoveSpeed MoveSpeed { get; }
    PlayerEvasiveSpeed EvasiveSpeed { get; }
    PlayerMoveRange MoveHorizontalRange { get; }
    PlayerMoveRange MoveVerticalRange { get; }
    PlayerScore Score { get; }

    void Init(
        PlayerHP hp,
        PlayerStamina stamina,
        PlayerMoveSpeed moveSpeed,
        PlayerEvasiveSpeed evasiveSpeed,
        PlayerMoveRange moveHorizontalRange,
        PlayerMoveRange moveVerticalRange
    );

    void AddScore(PlayerScore addScore);

}

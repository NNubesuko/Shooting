public interface Player {

    void Init(
        PlayerHP hp,
        PlayerMoveSpeed moveSpeed,
        PlayerEvasiveSpeed evasiveSpeed,
        PlayerMoveRange moveHorizontalRange,
        PlayerMoveRange moveVerticalRange
    );

    void Move();

    void Death();

    void SubHP(PlayerHP subHP);

    void AddScore(PlayerScore addScore);

    PlayerHP HP { get; }
    
    PlayerScore Score { get; }

}

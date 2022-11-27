public interface Enemy : IMovable {

    EnemyHP HP { get; }
    EnemyAP AP { get; }
    EnemyMoveSpeed MoveSpeed { get; }

    void Init(
        EnemyHP hp,
        EnemyAP ap,
        EnemyMoveSpeed moveSpeed
    );

}
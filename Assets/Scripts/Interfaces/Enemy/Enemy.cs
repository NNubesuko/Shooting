using UnityEngine;

public interface Enemy {

    EnemyHP HP { get; }
    EnemyAP AP { get; }
    EnemyMoveSpeed MoveSpeed { get; }
    EnemyPoint Point { get; }
    float Magnification { get; }
    float MoveTargetSwitchingInterval { get; }
    Vector2[] MoveTargetTable { get; }
    Player Player { get; }

    void Init(
        EnemyHP hp,
        EnemyAP ap,
        EnemyMoveSpeed moveSpeed,
        EnemyPoint point,
        float magnification,
        float moveTargetSwitchingInterval,
        Vector2[] moveTargetTable,
        Player player
    );

    void Move();

    void Death();

    void SubHP(EnemyHP subHP);

}
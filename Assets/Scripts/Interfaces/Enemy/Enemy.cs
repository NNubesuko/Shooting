using UnityEngine;

public interface Enemy : IMovable, IDamagable {

    EnemyHP HP { get; }
    EnemyAP AP { get; }
    EnemyMoveSpeed MoveSpeed { get; }
    EnemyMoveSpeedMagnification Magnification { get; }
    Vector2[] MoveTargetTable { get; }
    EnemyPoint Point { get; }

    void Init(
        EnemyHP hp,
        EnemyAP ap,
        EnemyMoveSpeed moveSpeed,
        EnemyMoveSpeedMagnification magnification,
        Vector2[] moveTargetTable,
        EnemyPoint point
    );

}
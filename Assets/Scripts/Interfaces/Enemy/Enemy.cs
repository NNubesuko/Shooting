using UnityEngine;

public interface Enemy : IMovable {

    EnemyHP HP { get; }
    EnemyAP AP { get; }
    EnemyMoveSpeed MoveSpeed { get; }
    EnemyMoveSpeedMagnification Magnification { get; }
    public Vector2[] MoveTargetTable { get; }

    void Init(
        EnemyHP hp,
        EnemyAP ap,
        EnemyMoveSpeed moveSpeed,
        EnemyMoveSpeedMagnification magnification,
        Vector2[] moveTargetTable
    );

}
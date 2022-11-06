using UnityEngine;

public interface Enemy {

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

using UnityEngine;

namespace ShootingGame.Enemy.Move
{
    public interface IEnemyMoveUseCase
    {
        Vector2 Handle(EnemyMoveInputData inputData);
    }
}
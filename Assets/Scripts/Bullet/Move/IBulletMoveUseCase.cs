using UnityEngine;

namespace ShootingGame.Bullet.Move
{
    public interface IBulletMoveUseCase
    {
        Vector2 Handle(BulletMoveInputData inputData);
    }
}
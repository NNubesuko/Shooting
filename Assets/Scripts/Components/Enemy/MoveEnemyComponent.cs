using Microsoft.Extensions.DependencyInjection;
using ShootingGame;
using ShootingGame.MoveEnemy;
using UnityEngine;

public class MoveEnemyComponent : MonoBehaviour
{
    private IMoveEnemyUseCase _moveEnemyUseCase;

    private void Start()
    {
        _moveEnemyUseCase = DiContainer.ServiceProvider.GetService<IMoveEnemyUseCase>();
    }

    private void Update()
    {
        transform.position = _moveEnemyUseCase.Handle();
    }
}

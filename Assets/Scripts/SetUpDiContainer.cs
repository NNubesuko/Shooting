using System;
using Microsoft.Extensions.DependencyInjection;
using ShootingGame.Components.Player;
using ShootingGame.MoveEnemy;
using ShootingGame.MovePlayer;
using ShootingGame.Player.DeathPlayer;
using UnityEngine;

namespace ShootingGame
{
    public class SetUpDiContainer : MonoBehaviour
    {
        private static IServiceCollection _serviceCollection { get; } = new ServiceCollection();
        public static IServiceProvider ServiceProvider { get; private set; }

        private void Awake()
        {
            Run();
        }

        public static void Run()
        {
            #if UNITY_EDITOR
                SetupDebug();
            #else
                SetupProduct();
            #endif
        
            ServiceProvider = _serviceCollection.BuildServiceProvider();
        }
        
        private static void SetupProduct()
        {
            _serviceCollection.AddTransient<IMovePlayerUseCase, MovePlayerUseCaseImpl>();
            _serviceCollection.AddTransient<IDeathPlayerUseCase, DeathPlayerUseCaseImpl>();
            _serviceCollection.AddTransient<IMoveEnemyUseCase, MoveEnemyUseCaseImpl>();
        }
        
        private static void SetupDebug()
        {
            _serviceCollection.AddTransient<IMovePlayerUseCase, MovePlayerUseCaseImpl>();
            _serviceCollection.AddTransient<IDeathPlayerUseCase, DeathPlayerUseCaseImpl>();
            _serviceCollection.AddTransient<IMoveEnemyUseCase, MoveEnemyUseCaseImpl>();
        }
    }
}
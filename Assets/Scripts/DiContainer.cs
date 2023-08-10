using System;
using Microsoft.Extensions.DependencyInjection;
using ShootingGame.Player.DamagePlayerComponent;
using ShootingGame.Player.PlayerAvoids;
using ShootingGame.Player.PlayerDeath;
using ShootingGame.PlayerMove;
using UnityEngine;

namespace ShootingGame
{
    public class DiContainer : MonoBehaviour
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
            _serviceCollection.AddTransient<IPlayerMoveUseCase, PlayerMoveUseCaseImpl>();
            _serviceCollection.AddTransient<IPlayerAvoidsUseCase, PlayerAvoidsUseCaseImpl>();
            _serviceCollection.AddTransient<IPlayerDamageUseCase, PlayerDamageUseCaseImpl>();
            _serviceCollection.AddTransient<IPlayerDeathUseCase, PlayerDeathUseCaseImpl>();
        }
        
        private static void SetupDebug()
        {
            _serviceCollection.AddTransient<IPlayerMoveUseCase, PlayerMoveUseCaseImpl>();
            _serviceCollection.AddTransient<IPlayerAvoidsUseCase, PlayerAvoidsUseCaseImpl>();
            _serviceCollection.AddTransient<IPlayerDamageUseCase, PlayerDamageUseCaseImpl>();
            _serviceCollection.AddTransient<IPlayerDeathUseCase, PlayerDeathUseCaseImpl>();
        }
    }
}
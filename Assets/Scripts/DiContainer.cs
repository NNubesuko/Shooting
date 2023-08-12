using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using ShootingGame.Components.Player;
using ShootingGame.Player.DamagePlayerComponent;
using ShootingGame.Player.PlayerAvoids;
using ShootingGame.Player.PlayerDeath;
using ShootingGame.Player.PlayerHealStamina;
using ShootingGame.Player.PlayerRepository;
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
            // Player UseCase
            _serviceCollection.AddTransient<IPlayerMoveUseCase, PlayerMoveUseCaseImpl>();
            _serviceCollection.AddTransient<IPlayerHealStaminaUseCase, PlayerHealStaminaUseCaseImpl>();
            _serviceCollection.AddTransient<IPlayerAvoidsUseCase, PlayerAvoidsUseCaseImpl>();
            _serviceCollection.AddTransient<IPlayerDamageUseCase, PlayerDamageUseCaseImpl>();
            _serviceCollection.AddTransient<IPlayerDeathUseCase, PlayerDeathUseCaseImpl>();
            // Player Repository
            _serviceCollection.AddTransient<IPlayerRepository, PlayerRepositoryImpl>();
        }
        
        private static void SetupDebug()
        {
            // Player UseCase
            _serviceCollection.AddTransient<IPlayerMoveUseCase, PlayerMoveUseCaseImpl>();
            _serviceCollection.AddTransient<IPlayerHealStaminaUseCase, PlayerHealStaminaUseCaseImpl>();
            _serviceCollection.AddTransient<IPlayerAvoidsUseCase, PlayerAvoidsUseCaseImpl>();
            _serviceCollection.AddTransient<IPlayerDamageUseCase, PlayerDamageUseCaseImpl>();
            _serviceCollection.AddTransient<IPlayerDeathUseCase, PlayerDeathUseCaseImpl>();
            // Player Repository
            _serviceCollection.AddTransient<IPlayerRepository, PlayerRepositoryImpl>();
        }
    }
}
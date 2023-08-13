using System;
using Microsoft.Extensions.DependencyInjection;
using ShootingGame.Player.Damage;
using ShootingGame.Player.PlayerAvoids;
using ShootingGame.Player.Death;
using ShootingGame.Player.HealStamina;
using ShootingGame.Player.PlayerRepository;
using ShootingGame.Player.Move;
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
            _serviceCollection.AddTransient<IPlayerHealStaminaRepository, PlayerHealStaminaRepositoryImpl>();
            _serviceCollection.AddTransient<IPlayerMoveRepository, PlayerMoveRepositoryImpl>();
            _serviceCollection.AddTransient<IPlayerDamageRepository, PlayerDamageRepositoryImpl>();
            _serviceCollection.AddTransient<IPlayerDeathRepository, PlayerDeathRepositoryImpl>();
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
            _serviceCollection.AddTransient<IPlayerHealStaminaRepository, PlayerHealStaminaRepositoryImpl>();
            _serviceCollection.AddTransient<IPlayerMoveRepository, PlayerMoveRepositoryImpl>();
            _serviceCollection.AddTransient<IPlayerDamageRepository, PlayerDamageRepositoryImpl>();
            _serviceCollection.AddTransient<IPlayerDeathRepository, PlayerDeathRepositoryImpl>();
        }
    }
}
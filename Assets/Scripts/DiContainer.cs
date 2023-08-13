using System;
using Microsoft.Extensions.DependencyInjection;
using ShootingGame.Bullet.Attack;
using ShootingGame.Bullet.Move;
using ShootingGame.Enemy.Attack;
using ShootingGame.Enemy.Damage;
using ShootingGame.Enemy.Death;
using ShootingGame.Enemy.Move;
using ShootingGame.Enemy.UpdateTableIndex;
using ShootingGame.Player.Damage;
using ShootingGame.Player.Avoids;
using ShootingGame.Player.Death;
using ShootingGame.Player.HealStamina;
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
            _serviceCollection.AddTransient<IPlayerMoveRepository, PlayerMoveRepositoryImpl>();
            _serviceCollection.AddTransient<IPlayerHealStaminaRepository, PlayerHealStaminaRepositoryImpl>();
            _serviceCollection.AddTransient<IPlayerAvoidsRepository, PlayerAvoidsRepositoryImpl>();
            _serviceCollection.AddTransient<IPlayerDamageRepository, PlayerDamageRepositoryImpl>();
            _serviceCollection.AddTransient<IPlayerDeathRepository, PlayerDeathRepositoryImpl>();
            
            // Enemy UseCase
            _serviceCollection.AddTransient<IEnemyMoveUseCase, EnemyMoveUseCaseImpl>();
            _serviceCollection.AddTransient<IEnemyUpdateTableIndexUseCase, EnemyUpdateTableIndexUseCaseImpl>();
            _serviceCollection.AddTransient<IEnemyDamageUseCase, EnemyDamageUseCaseImpl>();
            _serviceCollection.AddTransient<IEnemyDeathUseCase, EnemyDeathUseCaseImpl>();
            _serviceCollection.AddTransient<IEnemyAttackUseCase, EnemyAttackUseCaseImpl>();
            // Enemy Repository
            _serviceCollection.AddTransient<IEnemyMoveRepository, EnemyMoveRepositoryImpl>();
            _serviceCollection.AddTransient<IEnemyUpdateTableIndexRepository, EnemyUpdateTableIndexRepositoryImpl>();
            _serviceCollection.AddTransient<IEnemyDamageRepository, EnemyDamageRepositoryImpl>();
            _serviceCollection.AddTransient<IEnemyDeathRepository, EnemyDeathRepositoryImpl>();
            _serviceCollection.AddTransient<IEnemyAttackRepository, EnemyAttackRepositoryImpl>();
            
            // Bullet UseCase
            _serviceCollection.AddTransient<IBulletMoveUseCase, BulletMoveUseCaseImpl>();
            _serviceCollection.AddTransient<IBulletAttackUseCase, BulletAttackUseCaseImpl>();
            // Bullet Repository
            _serviceCollection.AddTransient<IBulletMoveRepository, BulletMoveRepositoryImpl>();
            _serviceCollection.AddTransient<IBulletAttackRepository, BulletAttackRepositoryImpl>();
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
            _serviceCollection.AddTransient<IPlayerMoveRepository, PlayerMoveRepositoryImpl>();
            _serviceCollection.AddTransient<IPlayerHealStaminaRepository, PlayerHealStaminaRepositoryImpl>();
            _serviceCollection.AddTransient<IPlayerAvoidsRepository, PlayerAvoidsRepositoryImpl>();
            _serviceCollection.AddTransient<IPlayerDamageRepository, PlayerDamageRepositoryImpl>();
            _serviceCollection.AddTransient<IPlayerDeathRepository, PlayerDeathRepositoryImpl>();
            
            // Enemy UseCase
            _serviceCollection.AddTransient<IEnemyMoveUseCase, EnemyMoveUseCaseImpl>();
            _serviceCollection.AddTransient<IEnemyUpdateTableIndexUseCase, EnemyUpdateTableIndexUseCaseImpl>();
            _serviceCollection.AddTransient<IEnemyDamageUseCase, EnemyDamageUseCaseImpl>();
            _serviceCollection.AddTransient<IEnemyDeathUseCase, EnemyDeathUseCaseImpl>();
            _serviceCollection.AddTransient<IEnemyAttackUseCase, EnemyAttackUseCaseImpl>();
            // Enemy Repository
            _serviceCollection.AddTransient<IEnemyMoveRepository, EnemyMoveRepositoryImpl>();
            _serviceCollection.AddTransient<IEnemyUpdateTableIndexRepository, EnemyUpdateTableIndexRepositoryImpl>();
            _serviceCollection.AddTransient<IEnemyDamageRepository, EnemyDamageRepositoryImpl>();
            _serviceCollection.AddTransient<IEnemyDeathRepository, EnemyDeathRepositoryImpl>();
            _serviceCollection.AddTransient<IEnemyAttackRepository, EnemyAttackRepositoryImpl>();
            
            // Bullet UseCase
            _serviceCollection.AddTransient<IBulletMoveUseCase, BulletMoveUseCaseImpl>();
            _serviceCollection.AddTransient<IBulletAttackUseCase, BulletAttackUseCaseImpl>();
            // Bullet Repository
            _serviceCollection.AddTransient<IBulletMoveRepository, BulletMoveRepositoryImpl>();
            _serviceCollection.AddTransient<IBulletAttackRepository, BulletAttackRepositoryImpl>();
        }
    }
}
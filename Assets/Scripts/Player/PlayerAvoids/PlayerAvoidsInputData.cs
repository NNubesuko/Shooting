using UnityEngine;

namespace ShootingGame.Player.PlayerAvoids
{
    public class PlayerAvoidsInputData
    {
        internal Vector2 Position { get; }
        internal float DeltaTime { get; }
        internal PlayerAvoidsSpeed AvoidsSpeed { get; }
        internal PlayerAvoidsDistance AvoidsDistance { get; }
        
        private PlayerAvoidsInputData(
            Vector2 position,
            float deltaTime,
            PlayerAvoidsSpeed avoidsSpeed,
            PlayerAvoidsDistance avoidsDistance)
        {
            Position = position;
            DeltaTime = deltaTime;
            AvoidsSpeed = avoidsSpeed;
            AvoidsDistance = avoidsDistance;
        }

        public static PlayerAvoidsInputData Of(
            Vector2 position,
            float deltaTime,
            PlayerAvoidsSpeed avoidsSpeed,
            PlayerAvoidsDistance avoidsDistance)
        {
            return new PlayerAvoidsInputData(position, deltaTime, avoidsSpeed, avoidsDistance);
        }
    }
}
using UnityEngine;

namespace ShootingGame.Player.Avoids
{
    public class PlayerAvoidsInputData
    {
        internal Vector2 Position { get; }
        internal Vector2 MoveDirection { get; }
        internal float DeltaTime { get; }
        internal bool InitiateAvoids { get; }

        private PlayerAvoidsInputData(
            Vector2 position,
            Vector2 moveDirection,
            float deltaTime,
            bool initiateAvoids)
        {
            Position = position;
            MoveDirection = moveDirection;
            DeltaTime = deltaTime;
            InitiateAvoids = initiateAvoids;
        }

        public static PlayerAvoidsInputData Of(
            Vector2 position,
            Vector2 moveDirection,
            float deltaTime,
            bool initiateAvoids)
        {
            return new PlayerAvoidsInputData(position, moveDirection, deltaTime, initiateAvoids);
        }
    }
}
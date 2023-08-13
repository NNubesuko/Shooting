using UnityEngine;

namespace ShootingGame.Player.Move
{
    public class PlayerMoveInputData
    {
        internal Vector2 Position { get; }
        internal Vector2 Axis { get; }
        internal float DeltaTime { get; }

        private PlayerMoveInputData(
            Vector2 position,
            Vector2 axis,
            float deltaTime)
        {
            Position = position;
            Axis = axis;
            DeltaTime = deltaTime;
        }

        public static PlayerMoveInputData Of(
            Vector2 position,
            Vector2 axis,
            float deltaTime)
        {
            return new PlayerMoveInputData(position, axis, deltaTime);
        }
    }
}
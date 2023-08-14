using UnityEngine;

namespace ShootingGame.Gun
{
    public class GunFireInputData
    {
        internal bool IsFiring { get; }
        internal Vector2 Position { get; }
        internal float DeltaTime { get; }
        internal Instantiate InstantiateMethod { get; }
        public delegate void Instantiate(GameObject gameObject, Vector2 position, Quaternion rotation);

        private GunFireInputData(
            bool isFiring,
            Vector2 position,
            float deltaTime,
            Instantiate instantiateMethod)
        {
            IsFiring = isFiring;
            Position = position;
            DeltaTime = deltaTime;
            InstantiateMethod = instantiateMethod;
        }

        public static GunFireInputData Of(
            bool isFiring,
            Vector2 position,
            float deltaTime,
            Instantiate instantiateMethod)
        {
            return new GunFireInputData(isFiring, position, deltaTime, instantiateMethod);
        }
    }
}
using UnityEngine;

namespace ShootingGame.Player.PlayerDeath
{
    public class PlayerDeathInputData
    {
        internal GameObject GameObject { get; }

        private PlayerDeathInputData(GameObject gameObject)
        {
            GameObject = gameObject;
        }

        public static PlayerDeathInputData Of(GameObject gameObject)
        {
            return new PlayerDeathInputData(gameObject);
        }
    }
}
using UnityEngine;

namespace ShootingGame.Player.PlayerDeath
{
    public class PlayerDeathInputData
    {
        internal GameObject GameObject { get; }
        internal PlayerHp Hp { get; }

        private PlayerDeathInputData(GameObject gameObject, PlayerHp hp)
        {
            GameObject = gameObject;
            Hp = hp;
        }

        public static PlayerDeathInputData Of(GameObject gameObject, PlayerHp hp)
        {
            return new PlayerDeathInputData(gameObject, hp);
        }
    }
}
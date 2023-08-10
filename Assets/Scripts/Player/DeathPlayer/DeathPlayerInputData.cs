using UnityEngine;

namespace ShootingGame.Player.DeathPlayer
{
    public class DeathPlayerInputData
    {
        internal GameObject GameObject { get; }
        internal PlayerHp Hp { get; }

        private DeathPlayerInputData(GameObject gameObject, PlayerHp hp)
        {
            GameObject = gameObject;
            Hp = hp;
        }

        public static DeathPlayerInputData Of(GameObject gameObject, PlayerHp hp)
        {
            return new DeathPlayerInputData(gameObject, hp);
        }
    }
}
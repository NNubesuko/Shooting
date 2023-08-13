using UnityEngine;

namespace ShootingGame.Components.Bullet
{
    public class BulletStatus : MonoBehaviour
    {
        [SerializeField] private int ap;
        [SerializeField] private float moveSpeed;

        public int Ap
        {
            get => ap;
            set => ap = value;
        }

        public float MoveSpeed
        {
            get => moveSpeed;
            set => moveSpeed = value;
        }
    }
}
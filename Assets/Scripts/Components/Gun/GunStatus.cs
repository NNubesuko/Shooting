using UnityEngine;

namespace ShootingGame.Components.Gun
{
    public class GunStatus : MonoBehaviour
    {
        [SerializeField] private GameObject bulletObject;
        [SerializeField] private int bulletCount;
        [SerializeField] private int bulletMaxCount;
        [SerializeField] private float fireRate;
        [SerializeField] private float currentFireRate;
        
        public static GunStatus Status { get; private set; }

        private void Awake()
        {
            Status = this;
        }

        public GameObject BulletObject
        {
            get => bulletObject;
            set => bulletObject = value;
        }

        public int BulletCount
        {
            get => bulletCount;
            set => bulletCount = value;
        }

        public int BulletMaxCount
        {
            get => bulletMaxCount;
            set => bulletMaxCount = value;
        }

        public float FireRate
        {
            get => fireRate;
            set => fireRate = value;
        }

        public float CurrentFireRate
        {
            get => currentFireRate;
            set => currentFireRate = value;
        }
    }
}
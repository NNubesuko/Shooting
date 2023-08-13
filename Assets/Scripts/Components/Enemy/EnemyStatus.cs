using UnityEngine;

namespace ShootingGame.Components.Enemy
{
    public class EnemyStatus : MonoBehaviour
    {
        [Header("体力")]
        [SerializeField] private int hp;
        
        [Header("攻撃力")]
        [SerializeField] private int ap;
        
        [Header("移動")]
        [SerializeField] private float moveSpeed;
        [SerializeField] private Vector2[] targetTable;
        [SerializeField] private int tableIndex;
        [SerializeField] private float updateTableIndexInterval;
        
        [Header("判定")]
        [SerializeField] private bool isDeath;

        public int Hp
        {
            get => hp;
            set => hp = value;
        }

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

        public Vector2[] TargetTable
        {
            get => targetTable;
            set => targetTable = value;
        }

        public int TableIndex
        {
            get => tableIndex;
            set => tableIndex = value;
        }

        public float UpdateTableIndexInterval
        {
            get => updateTableIndexInterval;
            set => updateTableIndexInterval = value;
        }

        public bool IsDeath
        {
            get => isDeath;
            set => isDeath = value;
        }
    }
}
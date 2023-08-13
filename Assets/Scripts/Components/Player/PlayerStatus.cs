using System;
using UnityEngine;

namespace ShootingGame.Components.Player
{
    public class PlayerStatus : MonoBehaviour
    {
        [Header("体力")]
        [SerializeField] private int hp;
        
        [Header("移動速度")]
        [SerializeField] private float moveSpeed;
        
        [Header("スタミナ")]
        [SerializeField] private float stamina;
        [SerializeField] private float healStamina;
        [SerializeField] private float healStaminaInterval;
        [SerializeField] private float consumptionStamina;
        
        [Header("回避")]
        [SerializeField] private float avoidsSpeed;
        [SerializeField] private float avoidsDistance;
        
        [Header("移動範囲")]
        [SerializeField] private float startHorizontalRange;
        [SerializeField] private float endHorizontalRange;
        [SerializeField] private float startVerticalRange;
        [SerializeField] private float endVerticalRange;

        [Header("判定")]
        [SerializeField] private bool canMove = true;
        [SerializeField] private bool isAvoiding = false;

        public static PlayerStatus Status { get; private set; }

        private void Awake()
        {
            Status = this;
        }

        public int Hp
        {
            get => hp;
            set => hp = value;
        }

        public float MoveSpeed
        {
            get => moveSpeed;
            set => moveSpeed = value;
        }

        public float Stamina
        {
            get => stamina;
            set => stamina = value;
        }

        public float HealStamina
        {
            get => healStamina;
            set => healStamina = value;
        }

        public float HealStaminaInterval
        {
            get => healStaminaInterval;
            set => healStaminaInterval = value;
        }

        public float ConsumptionStamina
        {
            get => consumptionStamina;
            set => consumptionStamina = value;
        }

        public float AvoidsSpeed
        {
            get => avoidsSpeed;
            set => avoidsSpeed = value;
        }

        public float AvoidsDistance
        {
            get => avoidsDistance;
            set => avoidsDistance = value;
        }

        public float StartHorizontalMoveRange
        {
            get => startHorizontalRange;
            set => startHorizontalRange = value;
        }
        public float EndHorizontalRange
        {
            get => endHorizontalRange;
            set => endHorizontalRange = value;
        }

        public float StartVerticalMoveRange
        {
            get => startVerticalRange;
            set => startVerticalRange = value;
        }
        public float EndVerticalRange
        {
            get => endVerticalRange;
            set => endVerticalRange = value;
        }

        public bool CanMove
        {
            get => canMove;
            set => canMove = value;
        }

        public bool IsAvoiding
        {
            get => isAvoiding;
            set => isAvoiding = value;
        }
    }
}
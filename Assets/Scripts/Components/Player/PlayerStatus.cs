using System;
using UnityEngine;

namespace ShootingGame.Components.Player
{
    public class PlayerStatus : MonoBehaviour
    {
        [SerializeField] private int hp;
        [SerializeField] private float moveSpeed;
        [SerializeField] private float stamina;
        [SerializeField] private float healStamina;
        [SerializeField] private float healStaminaInterval;
        [SerializeField] private float avoidsSpeed;
        [SerializeField] private float avoidsDistance;
        [SerializeField] private float startHorizontalRange;
        [SerializeField] private float endHorizontalRange;
        [SerializeField] private float startVerticalRange;
        [SerializeField] private float endVerticalRange;

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

        public PlayerStamina Stamina
        {
            get => PlayerStamina.Of(stamina);
            set => stamina = value.Value;
        }

        public PlayerStamina HealStamina
        {
            get => PlayerStamina.Of(healStamina);
            set => healStamina = value.Value;
        }

        public TimeSpan HealStaminaInterval
        {
            get => TimeSpan.FromSeconds(healStaminaInterval);
            set => healStaminaInterval = value.Seconds;
        }

        public PlayerAvoidsSpeed AvoidsSpeed
        {
            get => PlayerAvoidsSpeed.Of(avoidsSpeed);
            set => avoidsSpeed = value.Value;
        }

        public PlayerAvoidsDistance AvoidsDistance
        {
            get => PlayerAvoidsDistance.Of(avoidsDistance);
            set => avoidsDistance = value.Value;
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
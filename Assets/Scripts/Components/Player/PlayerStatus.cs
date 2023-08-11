using System;
using UnityEngine;

namespace ShootingGame.Components.Player
{
    public class PlayerStatus : MonoBehaviour
    {
        [SerializeField] private int hp;
        [SerializeField] private float moveSpeed;
        [SerializeField] private float stamina;
        [SerializeField] private float avoidsSpeed;
        [SerializeField] private float avoidsDistance;
        [SerializeField] private float startHorizontalRange;
        [SerializeField] private float endHorizontalRange;
        [SerializeField] private float startVerticalRange;
        [SerializeField] private float endVerticalRange;

        public static PlayerStatus Status { get; private set; }

        private void Awake()
        {
            Status = this;
        }

        public PlayerHp Hp
        {
            get => PlayerHp.Of(hp);
            set => hp = value.Value;
        }

        public PlayerMoveSpeed MoveSpeed
        {
            get => PlayerMoveSpeed.Of(moveSpeed);
            set => moveSpeed = value.Value;
        }

        public PlayerStamina Stamina
        {
            get => PlayerStamina.Of(stamina);
            set => stamina = value.Value;
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

        public PlayerHorizontalMoveRange HorizontalMoveRange
        {
            get => PlayerHorizontalMoveRange.Of(startHorizontalRange, endHorizontalRange);
            set
            {
                startHorizontalRange = value.Start;
                endHorizontalRange = value.End;
            }
        }

        public PlayerVerticalMoveRange VerticalMoveRange
        {
            get => PlayerVerticalMoveRange.Of(startVerticalRange, endVerticalRange);
            set
            {
                startVerticalRange = value.Start;
                endVerticalRange = value.End;
            }
        }
    }
}
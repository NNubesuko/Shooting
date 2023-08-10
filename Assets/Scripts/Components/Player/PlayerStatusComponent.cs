using UnityEngine;

namespace ShootingGame.Components.Player
{
    public class PlayerStatusComponent : MonoBehaviour
    {
        [SerializeField] private int hp;
        [SerializeField] private float moveSpeed;
        [SerializeField] private float startHorizontalRange;
        [SerializeField] private float endHorizontalRange;
        [SerializeField] private float startVerticalRange;
        [SerializeField] private float endVerticalRange;
        [SerializeField] private bool isDeath;
        
        internal PlayerHp Hp
        {
            get => PlayerHp.Of(hp);
            set => hp = value.Value;
        }

        internal PlayerMoveSpeed MoveSpeed
        {
            get => PlayerMoveSpeed.Of(moveSpeed);
            set => moveSpeed = value.Value;
        }

        internal PlayerHorizontalMoveRange HorizontalMoveRange
        {
            get => PlayerHorizontalMoveRange.Of(startHorizontalRange, endHorizontalRange);
            set
            {
                startHorizontalRange = value.Start;
                endHorizontalRange = value.End;
            }
        }

        internal PlayerVerticalMoveRange VerticalMoveRange
        {
            get => PlayerVerticalMoveRange.Of(startVerticalRange, endVerticalRange);
            set
            {
                startVerticalRange = value.Start;
                endVerticalRange = value.End;
            }
        }

        internal bool IsDeath
        {
            get => isDeath;
            set => isDeath = value;
        }
    }
}
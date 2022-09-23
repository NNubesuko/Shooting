using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMain : PlayerImpl {

    [SerializeField] private int hp;
    [SerializeField] private int moveSlowSpeed;
    [SerializeField] private int moveSpeed;
    [SerializeField] private int moveFastSpeed;
    [SerializeField] private Vector2 moveHorizontalRange;
    [SerializeField] private Vector2 moveVerticalRange;

    private void Awake() {
        Init(
            PlayerHP.Of(hp),
            PlayerMoveSpeed.Of(moveSlowSpeed),
            PlayerMoveSpeed.Of(moveSpeed),
            PlayerMoveSpeed.Of(moveFastSpeed),
            moveHorizontalRange,
            moveVerticalRange
        );
    }

    private void Update() {
        Move();
    }

}

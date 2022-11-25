using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMain : PlayerImpl {

    [SerializeField] private int hp;
    [SerializeField] private float stamina;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float evasionSpeed;
    [SerializeField] private float evasionDistance;

    private void Start() {
        Init(
            PlayerHP.Of(hp),
            PlayerStamina.Of(stamina),
            PlayerMoveSpeed.Of(moveSpeed),
            PlayerEvasionSpeed.Of(evasionSpeed),
            PlayerEvasionDistance.Of(evasionDistance)
        );
    }

    private void Update() {
        Move();
        Evasion();
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Systemk;

public class PlayerMain : PlayerImpl {

    [SerializeField] private int hp;
    [SerializeField] private float stamina;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float evasionSpeed;
    [SerializeField] private float evasionDistance;
    [SerializeField] private float staminaConsumption;
    [SerializeField] private float horizontalStart;
    [SerializeField] private float horizontalEnd;
    [SerializeField] private float verticalStart;
    [SerializeField] private float verticalEnd;

    private void Awake() {
        Init(
            PlayerHP.Of(hp),
            PlayerStamina.Of(stamina),
            PlayerMoveSpeed.Of(moveSpeed),
            PlayerEvasionSpeed.Of(evasionSpeed),
            PlayerEvasionDistance.Of(evasionDistance),
            PlayerHorizontalMoveRange.Of(horizontalStart, horizontalEnd),
            PlayerVerticalMoveRange.Of(verticalStart, verticalEnd)
        );
    }

    private void Update() {
        Move();
        Evasion(staminaConsumption);
        RestoreStamina(Time.deltaTime);
        Death();
    }

    

}

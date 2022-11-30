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

    private void Awake() {
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
        Evasion(staminaConsumption);
        RestoreStamina(Time.deltaTime);

        if (Inputk.GetKeyDown(KeyCode.F)) {
            Damage(EnemyAP.Of(10));
        }

        Debug.Log(HP);

        Death();
    }

}

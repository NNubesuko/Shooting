using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Systemk;

public class PlayerImpl : MonoBehaviour, Player {

    public PlayerHP HP { get; private set; }
    public PlayerStamina Stamina { get; private set; }
    public PlayerMoveSpeed MoveSpeed { get; private set; }
    public PlayerEvasionSpeed EvasionSpeed { get; private set; }
    public PlayerEvasionDistance EvasionDistance { get; private set; }

    private Vector2 evasionPosition;
    public bool CanMove { get; private set; } = true;
    public bool IsEvading { get; private set; } = false;

    public void Init(
        PlayerHP hp,
        PlayerStamina stamina,
        PlayerMoveSpeed moveSpeed,
        PlayerEvasionSpeed evasionSpeed,
        PlayerEvasionDistance evasionDistance
    ) {
        HP = hp;
        Stamina = stamina;
        MoveSpeed = moveSpeed;
        EvasionSpeed = evasionSpeed;
        EvasionDistance = evasionDistance;
    }

    /*
     * 通常移動
     */
    public void Move() {
        if (!CanMove) return;

        Vector2 velocity = transform.position;
        velocity += MoveSpeed * Inputk.GetAxis() * Time.deltaTime;
        transform.position = velocity;
    }

    public void Damage(AP ap) {
        HP -= ap;
    }

    public void Death() {
        if (HP == PlayerHP.Of(0)) {
            Debug.Log("死だよ");
            // gameObject.SetActive(false);
        }
    }

    public void Evasion(float staminaConsumption) {
        if (IsEvading) {
            transform.position = Vector2.MoveTowards(
                transform.position,
                evasionPosition,
                EvasionSpeed * Time.deltaTime
            );
        }

        if ((Vector2)transform.position == evasionPosition) {
            CanMove = true;
            IsEvading = false;
        }

        PlayerStamina staminaSubConsumption = Stamina - PlayerStamina.Of(staminaConsumption);
        if (staminaSubConsumption == PlayerStamina.Of(0f)) return;

        if (Inputk.IsMoving() && Inputk.GetKeyDown(KeyCode.Space) && !IsEvading) {
            evasionPosition = (Vector2)transform.position + EvasionDistance * Inputk.GetAxis();
            CanMove = false;
            IsEvading = true;

            Stamina = staminaSubConsumption;
        }
    }

    protected void RestoreStamina(float recoveryAmount) {
        Stamina += PlayerStamina.Of(recoveryAmount);
    }

}

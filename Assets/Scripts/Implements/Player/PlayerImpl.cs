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
    private bool canMove = true;
    private bool isEvading = false;

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
        if (!canMove) return;

        Vector2 velocity = transform.position;
        velocity += MoveSpeed * Inputk.GetAxis() * Time.deltaTime;
        transform.position = velocity;
    }

    public void Evasion() {
        if (Inputk.IsMoving() && Inputk.GetKeyDown(KeyCode.Space) && !isEvading) {
            evasionPosition = (Vector2)transform.position + EvasionDistance * Inputk.GetAxis();
            canMove = false;
            isEvading = true;
        }

        if (isEvading) {
            transform.position = Vector2.MoveTowards(
                transform.position,
                evasionPosition,
                EvasionSpeed * Time.deltaTime
            );
        }

        if ((Vector2)transform.position == evasionPosition) {
            canMove = true;
            isEvading = false;
        }
    }

}

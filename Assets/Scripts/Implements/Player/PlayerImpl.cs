using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Systemk;

public class PlayerImpl : MonoBehaviour, Player {

    public PlayerHP HP { get; private set; }
    public PlayerStamina Stamina { get; private set; }
    public PlayerMoveSpeed MoveSpeed { get; private set; }
    public PlayerEvasionSpeed EvasionSpeed { get; private set; }

    private Vector2 evasionPosition;
    private bool canMove = true;
    private bool isEvading = false;

    public void Init(
        PlayerHP hp,
        PlayerStamina stamina,
        PlayerMoveSpeed moveSpeed,
        PlayerEvasionSpeed evasionSpeed
    ) {
        HP = hp;
        Stamina = stamina;
        MoveSpeed = moveSpeed;
        EvasionSpeed = evasionSpeed;
    }

    /*
     * 通常移動
     */
    public void Move() {
        if (!canMove) return;

        Vector2 velocity = transform.position;
        // MoveSpeed * new Inputk() の使用は、MoveSpeedの定義へ移動して確認してください
        velocity += MoveSpeed * new Inputk() * Time.deltaTime;
        transform.position = velocity;
    }

    public void Evasion() {
        if (Inputk.IsMoving() && Inputk.GetKeyDown(KeyCode.Space) && !isEvading) {
            // 現在地 + 回避距離 * 方向
            // evasionPosition = transform.position * Inputk.GetAxis();
            canMove = false;
            isEvading = true;
        }

        if (isEvading) {
            transform.position = Vector2.MoveTowards(
                transform.position,
                evasionPosition,
                EvasionSpeed * new Time()
            );
        }

        if ((Vector2)transform.position == evasionPosition) {
            canMove = true;
            isEvading = false;
        }
    }

}

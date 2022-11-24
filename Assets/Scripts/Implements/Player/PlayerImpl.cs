using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Systemk;

public class PlayerImpl : MonoBehaviour, Player {

    public PlayerHP HP { get; private set; }
    public PlayerStamina Stamina { get; private set; }
    public PlayerMoveSpeed MoveSpeed { get; private set; }
    public PlayerEvasionSpeed EvasionSpeed { get; private set; }

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
        Vector2 velocity = transform.position;
        // MoveSpeed * new Inputk() の使用は、MoveSpeedの定義へ移動して確認してください
        velocity += MoveSpeed * new Inputk() * Time.deltaTime;
        transform.position = velocity;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

}

using System;
using System.Collections;
using System.Collections.Generic;
using Systemk;
using UnityEngine;

public class PlayerImpl : MonoBehaviour, Player {

    public PlayerHP HP { get; private set; }
    public PlayerStamina Stamina { get; private set; }
    public PlayerMoveSpeed MoveSpeed { get; private set; }
    public PlayerEvasiveSpeed EvasiveSpeed { get; private set; }
    public PlayerMoveRange MoveHorizontalRange { get; private set; }
    public PlayerMoveRange MoveVerticalRange { get; private set; }
    public PlayerScore Score { get; private set; }

    private bool isEvasive = false;
    private float currentEvasiveTime = 0;
    private bool canMove = true;
    private Vector2 currentDirection;

    public virtual void Init(
        PlayerHP hp,
        PlayerStamina stamina,
        PlayerMoveSpeed moveSpeed,
        PlayerEvasiveSpeed evasiveSpeed,
        PlayerMoveRange moveHorizontalRange,
        PlayerMoveRange moveVerticalRange
    ) {
        HP = hp;
        Stamina = stamina;
        MoveSpeed = moveSpeed;
        EvasiveSpeed = evasiveSpeed;
        MoveHorizontalRange = moveHorizontalRange;
        MoveVerticalRange = moveVerticalRange;
        Score = PlayerScore.Of(0);
    }

    public virtual void Move() {
        if (!canMove) return;

        MoveHelper(MoveSpeed);
    }

    public virtual void Evasive(float evasiveStaminaConsumption, float targetEvasiveTime) {
        // 現在の時間が目標の時間以上になるまで回避を続ける
        // 回避が終わり次第プレイヤーを通常移動に戻し、カウントを初期化する
        if (isEvasive && currentEvasiveTime <= targetEvasiveTime) {
            currentEvasiveTime += Time.deltaTime;
            MoveHelper(
                currentDirection.x * EvasiveSpeed.Value * Time.deltaTime,
                currentDirection.y * EvasiveSpeed.Value * Time.deltaTime
            );
        } else {
            canMove = true;
            isEvasive = false;
            currentEvasiveTime = 0;
        }

        if (StaminaHandler(evasiveStaminaConsumption)) return;

        // プレイヤーが移動中かつ回避中ではない場合に、キーを押されたら進行方向を格納し、回避を開始する
        if (Input.GetKeyDown(KeyCode.Space) && Inputk.GetAxis() != Vector2.zero && !isEvasive) {
            canMove = false;
            isEvasive = true;
            currentDirection = Inputk.GetAxis();
            Stamina -= PlayerStamina.Of(evasiveStaminaConsumption);
        }
    }

    public virtual void Death() {
        if (HP.Value == 0) {
            this.gameObject.SetActive(false);
        }
    }

    public virtual void SubHP(PlayerHP subHP) {
        HP -= subHP;
    }

    public virtual void AddScore(PlayerScore addScore) {
        Score += addScore;
    }

    private void MoveHelper(PlayerMoveSpeed moveSpeed) {
        Vector2 currentPosition = transform.position;

        currentPosition += Inputk.GetAxis() * moveSpeed.Value * Time.deltaTime;
        currentPosition = PlayerMoveRange.KeepPositionWithinRange(
            currentPosition,
            MoveHorizontalRange,
            MoveVerticalRange
        );

        transform.position = currentPosition;
    }

    private void MoveHelper(float addPositionX, float addPositionY) {
        Vector2 currentPosition = transform.position;

        float calculatedPositionX = currentPosition.x + addPositionX;
        float calculatedPositionY = currentPosition.y + addPositionY;
        currentPosition = PlayerMoveRange.KeepPositionWithinRange(
            new Vector2(calculatedPositionX,calculatedPositionY),
            MoveHorizontalRange,
            MoveVerticalRange
        );

        transform.position = currentPosition;
    }

    private bool StaminaHandler(float evasiveStaminaConsumption) {
        Stamina += PlayerStamina.Of(Time.deltaTime);
        return Stamina.Value < evasiveStaminaConsumption;
    }

}

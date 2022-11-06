using System;
using System.Collections;
using System.Collections.Generic;
using Systemk;
using UnityEngine;

public class PlayerImpl : MonoBehaviour, Player {

    private PlayerHP hp;
    private PlayerMoveSpeed moveSpeed;
    private PlayerEvasiveSpeed evasiveSpeed;
    private PlayerMoveRange moveHorizontalRange;
    private PlayerMoveRange moveVerticalRange;
    private PlayerScore score;

    private bool isEvasive = false;
    private float currentEvasiveTime = 0;
    private bool canMove = true;
    private Vector2 currentDirection;

    public virtual void Init(
        PlayerHP hp,
        PlayerMoveSpeed moveSpeed,
        PlayerEvasiveSpeed evasiveSpeed,
        PlayerMoveRange moveHorizontalRange,
        PlayerMoveRange moveVerticalRange
    ) {
        this.hp = hp;
        this.moveSpeed = moveSpeed;
        this.evasiveSpeed = evasiveSpeed;
        this.moveHorizontalRange = moveHorizontalRange;
        this.moveVerticalRange = moveVerticalRange;
    }

    public virtual void Move() {
        if (!canMove) return;

        MoveHelper(moveSpeed);
    }

    public void Evasive(float targetEvasiveTime) {
        // プレイヤーが移動中かつ回避中ではない場合に、キーを押されたら進行方向を格納し、回避を開始する
        if (Input.GetKeyDown(KeyCode.Space) && Inputk.GetAxis() != Vector2.zero && !isEvasive) {
            canMove = false;
            isEvasive = true;
            currentDirection = Inputk.GetAxis();
        }

        // 現在の時間が目標の時間以上になるまで回避を続ける
        // 回避が終わり次第プレイヤーを通常移動に戻し、カウントを初期化する
        if (isEvasive && currentEvasiveTime <= targetEvasiveTime) {
            currentEvasiveTime += Time.deltaTime;
            MoveHelper(
                currentDirection.x * evasiveSpeed.Value * Time.deltaTime,
                currentDirection.y * evasiveSpeed.Value * Time.deltaTime
            );
        } else {
            canMove = true;
            isEvasive = false;
            currentEvasiveTime = 0;
        }
    }

    public virtual void Death() {
        if (hp.Value == 0) {
            this.gameObject.SetActive(false);
        }
    }

    public virtual void SubHP(PlayerHP subHP) {
        hp -= subHP;
    }

    public virtual void AddScore(PlayerScore addScore) {
        score += addScore;
    }

    public PlayerHP HP {
        get { return hp; }
    }

    public PlayerScore Score {
        get { return score; }
    }

    private void MoveHelper(PlayerMoveSpeed moveSpeed) {
        Vector2 currentPosition = transform.position;

        currentPosition += Inputk.GetAxis() * moveSpeed.Value * Time.deltaTime;
        currentPosition = PlayerMoveRange.KeepPositionWithinRange(
            currentPosition,
            moveHorizontalRange,
            moveVerticalRange
        );

        transform.position = currentPosition;
    }

    private void MoveHelper(float addPositionX, float addPositionY) {
        Vector2 currentPosition = transform.position;

        float calculatedPositionX = currentPosition.x + addPositionX;
        float calculatedPositionY = currentPosition.y + addPositionY;
        currentPosition = PlayerMoveRange.KeepPositionWithinRange(
            new Vector2(calculatedPositionX,calculatedPositionY),
            moveHorizontalRange,
            moveVerticalRange
        );

        transform.position = currentPosition;
    }

}

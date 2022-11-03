using System.Collections;
using System.Collections.Generic;
using Systemk;
using UnityEngine;

public sealed class Player {

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

    private Player(
        PlayerHP hp,
        PlayerMoveSpeed moveSpeed,
        PlayerEvasiveSpeed evasiveSpeed,
        PlayerMoveRange moveHorizontalRange,
        PlayerMoveRange moveVerticalRange,
        PlayerScore score
    ) {
        this.hp = hp;
        this.moveSpeed = moveSpeed;
        this.evasiveSpeed = evasiveSpeed;
        this.moveHorizontalRange = moveHorizontalRange;
        this.moveVerticalRange = moveVerticalRange;
        this.score = score;
    }

    public static Player Generate(
        PlayerHP hp,
        PlayerMoveSpeed moveSpeed,
        PlayerEvasiveSpeed evasiveSpeed,
        PlayerMoveRange horizontalRange,
        PlayerMoveRange verticalRange,
        PlayerScore score
    ) {
        return new Player(hp, moveSpeed, evasiveSpeed, horizontalRange, verticalRange, score);
    }

    public void Move(Transform transform) {
        if (!canMove) return;

        MoveHandler(transform, moveSpeed);
    }

    /*
     * * プレイヤーが移動（通常移動や回避）する際のヘルプメソッド
     */
    private void MoveHandler(Transform transform, PlayerMoveSpeed speed) {
        Vector2 currentPosition = transform.position;

        currentPosition += Inputk.GetAxis() * speed.Value * Time.deltaTime;
        currentPosition.x = PlayerMoveRange.KeepPositionWithinRange(
            currentPosition.x,
            moveHorizontalRange
        );

        currentPosition.y = PlayerMoveRange.KeepPositionWithinRange(
            currentPosition.y,
            moveVerticalRange
        );

        transform.position = currentPosition;
    }

    private void MoveHelper(Transform transform, float addPositionX, float addPositionY) {
        Vector2 currentPosition = transform.position;

        float calculatedPositionX = currentPosition.x + addPositionX;
        float calculatedPositionY = currentPosition.y + addPositionY;

        currentPosition.x = PlayerMoveRange.KeepPositionWithinRange(
            calculatedPositionX,
            moveHorizontalRange
        );

        currentPosition.y = PlayerMoveRange.KeepPositionWithinRange(
            calculatedPositionY,
            moveVerticalRange
        );

        transform.position = currentPosition;
    }

    public void Evasive(Transform transform, float targetEvasiveTime) {
        if (Input.GetKeyDown(KeyCode.Space) && Inputk.GetAxis() != Vector2.zero && !isEvasive) {
            canMove = false;
            isEvasive = true;
            currentDirection = Inputk.GetAxis();
        }

        if (isEvasive && currentEvasiveTime <= targetEvasiveTime) {
            currentEvasiveTime += Time.deltaTime;
            MoveHelper(
                transform,
                currentDirection.x * evasiveSpeed.Value * Time.deltaTime,
                currentDirection.y * evasiveSpeed.Value * Time.deltaTime
            );
        } else {
            canMove = true;
            isEvasive = false;
            currentEvasiveTime = 0;
        }
    }

    public void SubHP(PlayerHP subHP) {
        hp -= subHP;
    }

    public void AddScore(PlayerScore addScore) {
        score += addScore;
    }

    public PlayerHP HP {
        get { return hp; }
    }

    public PlayerMoveSpeed MoveSpeed {
        get { return moveSpeed; }
    }

    public PlayerEvasiveSpeed EvasiveSpeed {
        get { return evasiveSpeed; }
    }

    public PlayerMoveRange MoveHorizontalRange {
        get { return moveHorizontalRange; }
    }

    public PlayerMoveRange MoveVerticalRange {
        get { return moveVerticalRange; }
    }

    public PlayerScore Score {
        get { return score; }
    }

    public override string ToString() {
        // $"HP: {hp}..." と書くとルーラーを超えてしまい改行できないため、string.Format()を利用する
        return string.Format(
            "HP: {0}, MSpeed: {1}, ESpeed: {2}, HRange: {3}, VRange: {4}",
            hp, moveSpeed, evasiveSpeed, moveHorizontalRange, moveVerticalRange
        );
    }

    public override int GetHashCode() {
        return (hp, moveSpeed, evasiveSpeed, moveHorizontalRange, moveVerticalRange).GetHashCode();
    }

    public override bool Equals(object obj) {
        return obj is Player other && this.Equals(other);
    }

    public bool Equals(Player other) {
        return this.GetHashCode() == other.GetHashCode();
    }

    public static bool operator==(Player lhPlayer, Player rhPlayer) {
        return lhPlayer.Equals(rhPlayer);
    }

    public static bool operator!=(Player lhPlayer, Player rhPlayer) {
        return !(lhPlayer == rhPlayer);
    }

}

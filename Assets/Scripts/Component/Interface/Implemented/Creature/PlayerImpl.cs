using Systemk;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerImpl : MonoBehaviour, Player {

    private PlayerHP _hp;
    private PlayerMoveSpeed _moveSlowSpeed;
    private PlayerMoveSpeed _moveSpeed;
    private PlayerMoveSpeed _moveFastSpeed;
    private PlayerEvasiveSpeed _evasiveSpeed;
    private PlayerMoveRange _moveHorizontalRange;
    private PlayerMoveRange _moveVerticalRange;
    private bool canMove = true;
    private bool isEvasive = false;
    private float evasiveTime = 0.1f;

    public void Init(
        PlayerHP hp,
        PlayerMoveSpeed moveSlowSpeed,
        PlayerMoveSpeed moveSpeed,
        PlayerMoveSpeed moveFastSpeed,
        PlayerEvasiveSpeed evasiveSpeed,
        PlayerMoveRange moveHorizontalRange,
        PlayerMoveRange moveVerticalRange
    ) {
        this._hp = hp;
        this._moveSlowSpeed = moveSlowSpeed;
        this._moveSpeed = moveSpeed;
        this._moveFastSpeed = moveFastSpeed;
        this._evasiveSpeed = evasiveSpeed;
        this._moveHorizontalRange = moveHorizontalRange;
        this._moveVerticalRange = moveVerticalRange;
    }

    public virtual void MoveSlow() {
        if (!canMove) return;

        MoveHandler(_moveFastSpeed);
    }

    public virtual void Move() {
        if (!canMove) return;
        
        MoveHandler(_moveSpeed);
    }

    public virtual void MoveFast() {
        if (!canMove) return;
        
        MoveHandler(_moveFastSpeed);
    }

    /**
     * TODO: 斜め移動した後に横に回避しようとすると、横ではなく斜めに回避してしまう。
     * * 上記の原因：入力した数値がすぐに0に戻らない
     */
    public virtual void Evasive() {
        if (
            (Input.GetAxis("Horizontal") != 0f || Input.GetAxis("Vertical") != 0f) &&
            Input.GetKeyDown(KeyCode.Space) &&
            !isEvasive
        ) {
            canMove = false;
            isEvasive = true;
            Invoke("ResetEvasive", evasiveTime);
            StartCoroutine(
                EvasiveHandler(
                    Mathk.Sign( Input.GetAxis("Horizontal") ),
                    Mathk.Sign( Input.GetAxis("Vertical") )
                )
            );
        }
    }

    /**
     * TODO: Bulletを実装した後に実装予定
     */
    public virtual void Attack() {
    }

    public virtual void Death() {
        if (_hp.Value == 0) {
            Debug.Log("Death");
        }
    }

    private void MoveHandler(PlayerMoveSpeed speed) {
        MoveHelper(
            Input.GetAxis("Horizontal") * speed.Value * Time.deltaTime,
            Input.GetAxis("Vertical") * speed.Value * Time.deltaTime
        );
    }

    private IEnumerator EvasiveHandler(float horizontal, float vertical) {
        while (isEvasive) {
            MoveHelper(
                horizontal * _evasiveSpeed.Value * Time.deltaTime,
                vertical * _evasiveSpeed.Value * Time.deltaTime
            );

            yield return null;
        }
    }

    private void ResetEvasive() {
        canMove = true;
        isEvasive = false;
    }

    /**
     * プレイヤーが移動（通常移動や回避）する際のヘルプメソッド
     */
    private void MoveHelper(float addPositionX, float addPositionY) {
        Vector2 currentPosition = transform.position;

        float calculatedPositionX = currentPosition.x + addPositionX;
        float calculatedPositionY = currentPosition.y + addPositionY;

        currentPosition.x = PlayerMoveRange.KeepPositionWithinRange(
            calculatedPositionX,
            _moveHorizontalRange
        );

        currentPosition.y = PlayerMoveRange.KeepPositionWithinRange(
            calculatedPositionY,
            _moveVerticalRange
        );

        transform.position = currentPosition;
    }

}

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
        MoveHandler(_moveFastSpeed);
    }

    public virtual void Move() {
        MoveHandler(_moveSpeed);
    }

    public virtual void MoveFast() {
        MoveHandler(_moveFastSpeed);
    }

    /**
     * todo: a
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

    private IEnumerator EvasiveHandler(float horizontal, float vertical) {
        while (isEvasive) {
            Vector2 currentPosition = transform.position;

            float calculatedPositionX =
                currentPosition.x + horizontal * _evasiveSpeed.Value * Time.deltaTime;
            float calculatedPositionY =
                currentPosition.y + vertical * _evasiveSpeed.Value * Time.deltaTime;

            currentPosition.x = PlayerMoveRange.KeepPositionWithinRange(
                calculatedPositionX,
                _moveHorizontalRange
            );

            currentPosition.y = PlayerMoveRange.KeepPositionWithinRange(
                calculatedPositionY,
                _moveVerticalRange
            );

            transform.position = currentPosition;

            yield return null;
        }
    }

    private void ResetEvasive() {
        canMove = true;
        isEvasive = false;
    }

    public virtual void Attack() {
    }

    public virtual void Death() {
        if (_hp.Value == 0) {
            Debug.Log("Death");
        }
    }

    private void MoveHandler(PlayerMoveSpeed speed) {
        if (!canMove) return;

        Vector2 currentPosition = transform.position;

        float calculatedPositionX =
            currentPosition.x + Input.GetAxis("Horizontal") * speed.Value * Time.deltaTime;
        float calculatedPositionY =
            currentPosition.y + Input.GetAxis("Vertical") * speed.Value * Time.deltaTime;

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

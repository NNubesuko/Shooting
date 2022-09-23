using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerImpl : MonoBehaviour, Player {

    private PlayerHP _hp;
    private PlayerMoveSpeed _moveSlowSpeed;
    private PlayerMoveSpeed _moveSpeed;
    private PlayerMoveSpeed _moveFastSpeed;
    private Vector2 _moveHorizontalRange;
    private Vector2 _moveVerticalRange;

    public void Init(
        PlayerHP hp,
        PlayerMoveSpeed moveSlowSpeed,
        PlayerMoveSpeed moveSpeed,
        PlayerMoveSpeed moveFastSpeed,
        Vector2 moveHorizontalRange,
        Vector2 moveVerticalRange
    ) {
        this._hp = hp;
        this._moveSlowSpeed = moveSlowSpeed;
        this._moveSpeed = moveSpeed;
        this._moveFastSpeed = moveFastSpeed;
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

    public virtual void Evasive() {
    }

    public virtual void Attack() {
    }

    public virtual void Death() {
    }

    private void MoveHandler(PlayerMoveSpeed speed) {
        Vector2 currentPosition = transform.position;

        float calculatedPositionX =
            currentPosition.x + Input.GetAxis("Horizontal") * speed.Value * Time.deltaTime;
        float calculatedPositionY =
            currentPosition.y + Input.GetAxis("Vertical") * speed.Value * Time.deltaTime;

        currentPosition.x = CanMoveRangeHandler(calculatedPositionX, _moveHorizontalRange);
        currentPosition.y = CanMoveRangeHandler(calculatedPositionY, _moveVerticalRange);

        transform.position = currentPosition;
    }

    private float CanMoveRangeHandler(float calculatedPosition, Vector2 canMoveRange) {
        if (calculatedPosition < canMoveRange.x) {
            return canMoveRange.x;
        } else if (calculatedPosition > canMoveRange.y) {
            return canMoveRange.y;
        }
        return calculatedPosition;
    }

}

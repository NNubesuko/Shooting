using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KataokaLib.System;

public class PlayerImpl : MonoBehaviour, Player {

    public PlayerHP HP { get; private set; }
    public PlayerStamina Stamina { get; private set; }
    public PlayerMoveSpeed MoveSpeed { get; private set; }
    public PlayerEvasionSpeed EvasionSpeed { get; private set; }
    public PlayerEvasionDistance EvasionDistance { get; private set; }
    public PlayerHorizontalMoveRange HorizontalMoveRange { get; private set; }
    public PlayerVerticalMoveRange VerticalMoveRange { get; private set; }
    public PlayerScore Score { get; private set; } = PlayerScore.Of(0);

    private Vector2 evasionPosition;
    public bool CanMove { get; private set; } = true;
    public bool IsEvading { get; private set; } = false;
    public bool IsDeath { get; private set; } = false;

    /*
     * ステータスを初期化するメソッド
     */
    public void Init(
        PlayerHP hp,
        PlayerStamina stamina,
        PlayerMoveSpeed moveSpeed,
        PlayerEvasionSpeed evasionSpeed,
        PlayerEvasionDistance evasionDistance,
        PlayerHorizontalMoveRange horizontalMoveRange,
        PlayerVerticalMoveRange verticalMoveRange
    ) {
        HP = hp;
        Stamina = stamina;
        MoveSpeed = moveSpeed;
        EvasionSpeed = evasionSpeed;
        EvasionDistance = evasionDistance;
        HorizontalMoveRange = horizontalMoveRange;
        VerticalMoveRange = verticalMoveRange;
    }

    /*
     * 通常移動のメソッド, IMovableより実装
     */
    public void Move() {
        if (!CanMove) return;

        Vector2 velocity = transform.position;
        velocity += MoveSpeed * Inputk.GetAxis() * Time.deltaTime;

        // 演算された位置が移動範囲外であれば、それぞれの最小値または最大値を格納し、位置を移動範囲に制限する
        velocity.x = HorizontalMoveRange.WithinRange(velocity.x);
        velocity.y = VerticalMoveRange.WithinRange(velocity.y);

        transform.position = velocity;
    }

    /*
     * ダメージのメソッド, IDamagableより実装
     */
    public void Damage(AP ap) {
        HP -= ap;
    }

    /*
     * 死亡時のメソッド, IDamagableより実装
     */
    public void Death() {
        if (HP == PlayerHP.Of(0)) {
            IsDeath = true;
            gameObject.SetActive(false);
        }
    }

    /*
     * 通常回避のメソッド
     */
    public void Evasion(float staminaConsumption) {
        if (IsEvading) {
            evasionPosition.x = HorizontalMoveRange.WithinRange(evasionPosition.x);
            evasionPosition.y = VerticalMoveRange.WithinRange(evasionPosition.y);

            transform.position = Vector2.MoveTowards(
                transform.position,
                evasionPosition,
                EvasionSpeed * Time.deltaTime
            );
        }

        if ((Vector2)transform.position == evasionPosition) {
            CanMove = true;
            IsEvading = false;
        }

        PlayerStamina staminaSubConsumption = Stamina - PlayerStamina.Of(staminaConsumption);
        if (staminaSubConsumption == PlayerStamina.Of(0f)) return;

        if (Inputk.IsMoving() && Inputk.GetKeyDown(KeyCode.Space) && !IsEvading) {
            evasionPosition = (Vector2)transform.position + EvasionDistance * Inputk.GetAxis();
            CanMove = false;
            IsEvading = true;

            Stamina = staminaSubConsumption;
        }
    }

    /*
     * スコアを加算するメソッド
     */
    public void AddScore(Point point) {
        Score += point;
    }

    /*
     * スタミナを回復させるヘルプメソッド
     */
    protected void RestoreStamina(float recoveryAmount) {
        Stamina += PlayerStamina.Of(recoveryAmount);
    }

    /*
     * プレイヤーオブジェクトが非アクティブになった場合のメソッド
     ! GameAdmin専用
     */
    public void OnGameOver() {
        HP = null;
        Stamina = null;
        MoveSpeed = null;
        EvasionSpeed = null;
        EvasionDistance = null;

        GC.Collect();
    }

}

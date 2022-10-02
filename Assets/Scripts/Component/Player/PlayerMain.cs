using Systemk;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMain : PlayerImpl {

    [Header("体力"), SerializeField] private int hp;
    [Header("移動速度（遅い）"), SerializeField] private int moveSlowSpeed;
    [Header("移動速度（普通）"), SerializeField] private int moveSpeed;
    [Header("移動速度（速い）"), SerializeField] private int moveFastSpeed;
    [Header("回避速度"), SerializeField] private int evasiveSpeed;

    [Header("水平方向の移動可能範囲")]
    [SerializeField] private float horizontalLowValue;
    [SerializeField] private float horizontalHighValue;

    [Header("垂直方向の移動可能範囲")]
    [SerializeField] private float verticalLowValue;
    [SerializeField] private float verticalHighValue;

    private void Awake() {
        Init(
            PlayerHP.Of(hp),
            PlayerMoveSpeed.Of(moveSlowSpeed),
            PlayerMoveSpeed.Of(moveSpeed),
            PlayerMoveSpeed.Of(moveFastSpeed),
            PlayerEvasiveSpeed.Of(evasiveSpeed),
            PlayerMoveRange.Of(horizontalLowValue, horizontalHighValue),
            PlayerMoveRange.Of(verticalLowValue, verticalHighValue)
        );
    }

    private void Update() {
        Move();
        Evasive();
        Death();
    }

}

using System;
using System.Collections;
using System.Collections.Generic;
using Systemk;
using UnityEngine;

public class PlayerMain : PlayerImpl {

    [Header("体力"), SerializeField] private int hp;
    [Header("スタミナ"), SerializeField] private int stamina;
    [Header("移動速度"), SerializeField] private int moveSpeed;
    [Header("回避時のスタミナ消費量"), SerializeField] private float evasiveStaminaConsumption;
    [Header("回避速度"), SerializeField] private int evasiveSpeed;
    [Header("回避時間"), SerializeField] private float evasiveTime;
    
    [Header("水平方向の移動可能範囲")]
    [SerializeField] private float lowHorizontalValue;
    [SerializeField] private float highHorizontalValue;

    [Header("垂直方向の移動可能範囲")]
    [SerializeField] private float lowVerticalValue;
    [SerializeField] private float highVerticalValue;

    private void Awake() {
        Init(
            PlayerHP.Of(hp),
            PlayerStamina.Of(stamina),
            PlayerMoveSpeed.Of(moveSpeed),
            PlayerEvasiveSpeed.Of(evasiveSpeed),
            PlayerMoveRange.Of(lowHorizontalValue, highHorizontalValue),
            PlayerMoveRange.Of(lowVerticalValue, highVerticalValue)
        );
    }

    private void Update() {
        Move();
        Evasive(evasiveStaminaConsumption, evasiveTime);
        Death();
    }

}

using Systemk;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMain : MonoBehaviour {

    [Header("体力"), SerializeField] private int hp;
    [Header("移動速度"), SerializeField] private int moveSpeed;
    [Header("回避速度"), SerializeField] private int evasiveSpeed;
    [Header("回避時間"), SerializeField] private float evasiveTime;
    
    [Header("水平方向の移動可能範囲")]
    [SerializeField] private float lowHorizontalValue;
    [SerializeField] private float highHorizontalValue;

    [Header("垂直方向の移動可能範囲")]
    [SerializeField] private float lowVerticalValue;
    [SerializeField] private float highVerticalValue;

    private Player player;

    private void Awake() {
        player = Player.Generate(
            PlayerHP.Of(hp),
            PlayerMoveSpeed.Of(moveSpeed),
            PlayerEvasiveSpeed.Of(evasiveSpeed),
            PlayerMoveRange.Of(lowHorizontalValue, highHorizontalValue),
            PlayerMoveRange.Of(lowVerticalValue, highVerticalValue)
        );
    }

    private void Update() {
        player.Move(transform);
        player.Evasive(transform, evasiveTime);

        if (player.HP.Value == 0) {
            Debug.Log("Hello Death");
        }
    }

}

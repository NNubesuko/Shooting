using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using KataokaLib.ValueObject;

namespace Tests {

    [Description("プレイヤーのスタミナのテスト")]
    public class PlayerStaminaTest{

        [Test]
        [TestCase(0f)]
        [TestCase(50f)]
        [TestCase(100f)]
        [Description("[正常] 渡された値が最小値以上かつ最大値以下である場合に、正常に格納されること")]
        public void ValidPlayerStamina(float value) {
            PlayerStamina playerStamina = PlayerStamina.Of(value);
            Assert.That(playerStamina, Is.EqualTo(PlayerStamina.Of(value)));
        }

        [Test]
        [TestCase(float.MinValue)]
        [TestCase(-1f)]
        [TestCase(101f)]
        [TestCase(float.MaxValue)]
        [Description("[異常] 渡された値が最小値未満または最大値より大きい場合に、スローが投げられること")]
        public void InvalidPlayerStamina(float value) {
            var exception = Assert.Throws<ArgumentException>(() => {
                PlayerStamina playerStamina = PlayerStamina.Of(value);
            });

            Assert.That(
                exception.Message,
                Is.EqualTo(
                    ValueObjectExceptionHandler.ArgumentException(nameof(value)).Message
                )
            );
        }

        [Test]
        [TestCase(0f)]
        [TestCase(10f)]
        [TestCase(50f)]
        [TestCase(80f)]
        [Description("[正常] フレーム秒と加算した場合に、範囲内の数値が格納されること")]
        public void ValidPlyaerStaminaAddDelatTime(float value) {
            PlayerStamina playerStamina = PlayerStamina.Of(value);
            PlayerStamina deltaTime = PlayerStamina.Of(Time.deltaTime);
            PlayerStamina playerStaminaAddDeltaTime = playerStamina + deltaTime;

            Assert.That(
                playerStaminaAddDeltaTime,
                Is.EqualTo(
                    PlayerStamina.Of(value + Time.deltaTime)
                )
            );
        }

        [Test]
        [TestCase(100f)]
        [Description("[正常] フレーム秒と加算した値が最大値を超えた場合に、最大値が格納されること")]
        public void ValidPlyaerStaminaAddDeltaTimeOverMax(float value) {
            PlayerStamina playerStamina = PlayerStamina.Of(value);
            PlayerStamina deltaTime = PlayerStamina.Of(Time.deltaTime);
            PlayerStamina playerStaminaAddDeltaTime = playerStamina + deltaTime;

            Assert.That(
                playerStaminaAddDeltaTime,
                Is.EqualTo(
                    PlayerStamina.Of(playerStamina.MAX)
                )
            );
        }

        [Test]
        [TestCase(10f)]
        [TestCase(50f)]
        [TestCase(80f)]
        [TestCase(100f)]
        [Description("[正常] フレーム秒と減算した場合に、範囲内の数値が格納されること")]
        public void ValidPlyaerStaminaSubDelatTime(float value) {
            PlayerStamina playerStamina = PlayerStamina.Of(value);
            PlayerStamina deltaTime = PlayerStamina.Of(Time.deltaTime);
            PlayerStamina playerStaminaAddDeltaTime = playerStamina - deltaTime;

            Assert.That(
                playerStaminaAddDeltaTime,
                Is.EqualTo(
                    PlayerStamina.Of(value - Time.deltaTime)
                )
            );
        }

        [Test]
        [TestCase(0f)]
        [Description("[正常] フレーム秒と加算した値が最大値を超えた場合に、最大値が格納されること")]
        public void ValidPlyaerStaminaSubDeltaTimeOverMax(float value) {
            PlayerStamina playerStamina = PlayerStamina.Of(value);
            PlayerStamina deltaTime = PlayerStamina.Of(Time.deltaTime);
            PlayerStamina playerStaminaAddDeltaTime = playerStamina - deltaTime;

            Assert.That(
                playerStaminaAddDeltaTime,
                Is.EqualTo(
                    PlayerStamina.Of(playerStamina.MIN)
                )
            );
        }

    }

}
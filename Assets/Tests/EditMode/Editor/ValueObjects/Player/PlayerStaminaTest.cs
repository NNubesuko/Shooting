using System;
using System.Runtime.InteropServices;
using System.Collections;
using System.Collections.Generic;
using Systemk;
using Systemk.Exceptions;
using Systemk.Util;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests {

    [Description("プレイヤーのスタミナのテスト")]
    public class PlayerStaminaTest {

        [Test]
        [TestCase(0f)]
        [TestCase(50f)]
        [TestCase(100f)]
        [Description("[正常] 渡された値が最小値以上最大値以下である場合に、値が正常に格納されること")]
        public void ValidPlayerStamina(float value) {
            PlayerStamina playerStamina = PlayerStamina.Of(value);
            Assert.That(playerStamina.Value, Is.EqualTo(value));
        }

        [Test]
        [TestCase(10f, 2f)]
        [Description("[正常] PlayerStamina同士の加算が行われた場合に、値が正常に格納されること")]
        public void ValidPlayerStaminaOperatorAdd(float value, float addValue) {
            float responsePlayerStamina = 12f;

            PlayerStamina playerStamina = PlayerStamina.Of(value) + PlayerStamina.Of(addValue);
            Assert.That(playerStamina.Value, Is.EqualTo(responsePlayerStamina));
        }

        [Test]
        [TestCase(10f, 2f)]
        [Description("[正常] PlayerStamina同士の減算が行われた場合に、値が正常に格納されること")]
        public void ValidPlayerStaminaOperatorSub(float value, float subValue) {
            float responsePlayerStamina = 8f;

            PlayerStamina playerStamina = PlayerStamina.Of(value) - PlayerStamina.Of(subValue);
            Assert.That(playerStamina.Value, Is.EqualTo(responsePlayerStamina));
        }

        [Test]
        [TestCase(10f, 2f)]
        [Description("[正常] PlayerStamina同士の乗算が行われた場合に、値が正常に格納されること")]
        public void ValidPlayerStaminaOperatorMul(float value, float mulValue) {
            float responsePlayerStamina = 20f;

            PlayerStamina playerStamina = PlayerStamina.Of(value) * PlayerStamina.Of(mulValue);
            Assert.That(playerStamina.Value, Is.EqualTo(responsePlayerStamina));
        }

        [Test]
        [TestCase(10f, 2f)]
        [Description("[正常] PlayerStamina同士の除算が行われた場合に、値が正常に格納されること")]
        public void ValidPlayerStaminaOperatorDiv(float value, float divValue) {
            float responsePlayerStamina = 5f;

            PlayerStamina playerStamina = PlayerStamina.Of(value) / PlayerStamina.Of(divValue);
            Assert.That(playerStamina.Value, Is.EqualTo(responsePlayerStamina));
        }

        [Test]
        [TestCase(100f, 10f)]
        [Description("[正常] 加算した値が最大値より大きい場合に、最大値が格納されていること")]
        public void LimitAddPlayerStamina(float value, float addValue) {
            float responsePlayerStamina = 100f;

            PlayerStamina playerStamina = PlayerStamina.Of(value) + PlayerStamina.Of(addValue);
            Assert.That(playerStamina.Value, Is.EqualTo(responsePlayerStamina));
        }

        [Test]
        [TestCase(0f, 1f)]
        [Description("[正常] 減算した値が最小値より小さい場合に、最小値が格納されていること")]
        public void LimitSubPlayerStamina(float value, float subValue) {
            float responsePlayerStamina = 0f;

            PlayerStamina playerStamina = PlayerStamina.Of(value) - PlayerStamina.Of(subValue);
            Assert.That(playerStamina.Value, Is.EqualTo(responsePlayerStamina));
        }

        [Test]
        [TestCase(100f, 2f)]
        [Description("[正常] 乗算した値が最大値より大きい場合に、最大値が格納されていること")]
        public void LimitMulPlayerStamina(float value, float mulValue) {
            float responsePlayerStamina = 100f;

            PlayerStamina playerStamina = PlayerStamina.Of(value) * PlayerStamina.Of(mulValue);
            Assert.That(playerStamina.Value, Is.EqualTo(responsePlayerStamina));
        }

        [Test]
        [TestCase(100f, TestCodeIni.ScriptBytes)]
        [Description(
            "[正常] スクリプト自体のサイズとインスタンスのサイズが、スクリプトバイト以下であること"
        )]
        public void ValidScriptCapacity(float value, float scriptBytes) {
            PlayerStamina playerStamina = PlayerStamina.Of(value);

            Assert.That(Marshal.SizeOf(typeof(PlayerStamina)), Is.LessThanOrEqualTo(scriptBytes));
            Assert.That(Marshal.SizeOf(playerStamina), Is.LessThanOrEqualTo(scriptBytes));
        }

        [Test]
        [TestCase(float.MinValue)]
        [TestCase(-1f)]
        [TestCase(101f)]
        [TestCase(float.MaxValue)]
        [Description("[異常] 渡された値が最小値未満か最大値より大きい場合に、スローが投げられること")]
        public void ThrowWhenValueIsOverRange(float value) {
            var exception = Assert.Throws<ArgumentException>(() => {
                PlayerStamina playerStamina = PlayerStamina.Of(value);
            });

            Assert.That(
                exception.Message,
                Is.EqualTo(ExceptionMessage.argumentExceptionMessage)
            );
        }

        [Test]
        [TestCase(1f, 0f)]
        [Description("[異常] 除算において0で割っている場合に、スローが投げられること")]
        public void ThrowWhenDivPlayerStamina(float value, float divValue) {
            var exception = Assert.Throws<DivideByZeroException>(() => {
                PlayerStamina playerStamina = PlayerStamina.Of(value) / PlayerStamina.Of(divValue);
            });

            Assert.That(
                exception.Message,
                Is.EqualTo(ExceptionMessage.divideByZeroExceptionMessage)
            );
        }

    }

}

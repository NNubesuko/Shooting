using System;
using System.Runtime.InteropServices;
using System.Collections;
using System.Collections.Generic;
using Systemk;
using Systemk.Exceptions;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests {

    [Description("プレイヤーのスタミナのテスト")]
    public class PlayerStaminaTest {

        [Test]
        [TestCase(0)]
        [TestCase(50)]
        [TestCase(100)]
        [Description("[正常] 渡された値が最小値以上最大値以下である場合に、値が正常に格納されること")]
        public void ValidPlayerStamina(int value) {
            PlayerStamina playerStamina = PlayerStamina.Of(value);
            Assert.That(playerStamina.Value, Is.EqualTo(value));
        }

        [Test]
        [TestCase(10, 2)]
        [Description("[正常] PlayerStamina同士の加算が行われた場合に、値が正常に格納されること")]
        public void ValidPlayerStaminaOperatorAdd(int value, int addValue) {
            int responsePlayerStamina = 12;

            PlayerStamina playerStamina = PlayerStamina.Of(value) + PlayerStamina.Of(addValue);
            Assert.That(playerStamina.Value, Is.EqualTo(responsePlayerStamina));
        }

        [Test]
        [TestCase(10, 2)]
        [Description("[正常] PlayerStamina同士の減算が行われた場合に、値が正常に格納されること")]
        public void ValidPlayerStaminaOperatorSub(int value, int subValue) {
            int responsePlayerStamina = 8;

            PlayerStamina playerStamina = PlayerStamina.Of(value) - PlayerStamina.Of(subValue);
            Assert.That(playerStamina.Value, Is.EqualTo(responsePlayerStamina));
        }

        [Test]
        [TestCase(10, 2)]
        [Description("[正常] PlayerStamina同士の乗算が行われた場合に、値が正常に格納されること")]
        public void ValidPlayerStaminaOperatorMul(int value, int mulValue) {
            int responsePlayerStamina = 20;

            PlayerStamina playerStamina = PlayerStamina.Of(value) * PlayerStamina.Of(mulValue);
            Assert.That(playerStamina.Value, Is.EqualTo(responsePlayerStamina));
        }

        [Test]
        [TestCase(10, 2)]
        [Description("[正常] PlayerStamina同士の除算が行われた場合に、値が正常に格納されること")]
        public void ValidPlayerStaminaOperatorDiv(int value, int divValue) {
            int responsePlayerStamina = 5;

            PlayerStamina playerStamina = PlayerStamina.Of(value) / PlayerStamina.Of(divValue);
            Assert.That(playerStamina.Value, Is.EqualTo(responsePlayerStamina));
        }

        [Test]
        [TestCase(100, 10)]
        [Description("[正常] 加算した値が最大値より大きい場合に、最大値が格納されていること")]
        public void LimitAddPlayerStamina(int value, int addValue) {
            int responsePlayerStamina = 100;

            PlayerStamina playerStamina = PlayerStamina.Of(value) + PlayerStamina.Of(addValue);
            Assert.That(playerStamina.Value, Is.EqualTo(responsePlayerStamina));
        }

        [Test]
        [TestCase(0, 1)]
        [Description("[正常] 減算した値が最小値より小さい場合に、最小値が格納されていること")]
        public void LimitSubPlayerStamina(int value, int subValue) {
            int responsePlayerStamina = 0;

            PlayerStamina playerStamina = PlayerStamina.Of(value) - PlayerStamina.Of(subValue);
            Assert.That(playerStamina.Value, Is.EqualTo(responsePlayerStamina));
        }

        [Test]
        [TestCase(100, 2)]
        [Description("[正常] 乗算した値が最大値より大きい場合に、最大値が格納されていること")]
        public void LimitMulPlayerStamina(int value, int mulValue) {
            int responsePlayerStamina = 100;

            PlayerStamina playerStamina = PlayerStamina.Of(value) * PlayerStamina.Of(mulValue);
            Assert.That(playerStamina.Value, Is.EqualTo(responsePlayerStamina));
        }

        [Test]
        [TestCase(100, TestCodeIni.ScriptBytes)]
        [Description(
            "[正常] スクリプト自体のサイズとインスタンスのサイズが、スクリプトバイト以下であること"
        )]
        public void ValidScriptCapacity(int value, int scriptBytes) {
            PlayerStamina playerStamina = PlayerStamina.Of(value);

            Assert.That(Marshal.SizeOf(typeof(PlayerStamina)), Is.LessThanOrEqualTo(scriptBytes));
            Assert.That(Marshal.SizeOf(playerStamina), Is.LessThanOrEqualTo(scriptBytes));
        }

        [Test]
        [TestCase(int.MinValue)]
        [TestCase(-1)]
        [TestCase(101)]
        [TestCase(int.MaxValue)]
        [Description("[異常] 渡された値が最小値未満か最大値より大きい場合に、スローが投げられること")]
        public void ThrowWhenValueIsOverRange(int value) {
            var exception = Assert.Throws<ArgumentException>(() => {
                PlayerStamina playerStamina = PlayerStamina.Of(value);
            });

            Assert.That(
                exception.Message,
                Is.EqualTo(ExceptionMessage.argumentExceptionMessage)
            );
        }

        [Test]
        [TestCase(1, 0)]
        [Description("[異常] 除算において0で割っている場合に、スローが投げられること")]
        public void ThrowWhenDivPlayerStamina(int value, int divValue) {
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

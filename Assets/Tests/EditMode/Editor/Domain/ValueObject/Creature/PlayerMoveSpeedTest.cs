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
    
    [Description("プレイヤーの移動速度のテスト")]
    public class PlayerMoveSpeedTest {

        [Test]
        [TestCase(0)]
        [TestCase(5)]
        [TestCase(10)]
        [Description("[正常] 渡された値が最小値以上最大値以下である場合に、値が正常に格納されること")]
        public void ValidPlayerMoveSpeed(int value) {
            PlayerMoveSpeed playerMoveSpeed = PlayerMoveSpeed.Of(value);
            Assert.That(playerMoveSpeed.Value, Is.EqualTo(value));
        }

        [Test]
        [TestCase(4, 2)]
        [Description("[正常] 加算が行われた場合に、値が正常に格納されること")]
        public void ValidPlayerMoveSpeedOperatorAdd(int value, int addValue) {
            int responsePlayerMoveSpeed = 6;

            PlayerMoveSpeed playerMoveSpeed =
                PlayerMoveSpeed.Of(value) + PlayerMoveSpeed.Of(addValue);
            Assert.That(playerMoveSpeed.Value, Is.EqualTo(responsePlayerMoveSpeed));
        }

        [Test]
        [TestCase(4, 2)]
        [Description("[正常] 減算が行われた場合に、値が正常に格納されること")]
        public void ValidPlayerMoveSpeedOperatorSub(int value, int subValue) {
            int responsePlayerMoveSpeed = 2;

            PlayerMoveSpeed playerMoveSpeed =
                PlayerMoveSpeed.Of(value) - PlayerMoveSpeed.Of(subValue);
            Assert.That(playerMoveSpeed.Value, Is.EqualTo(responsePlayerMoveSpeed));
        }

        [Test]
        [TestCase(4, 2)]
        [Description("[正常] 乗算が行われた場合に、値が正常に格納されること")]
        public void ValidPlayerMoveSpeedOperatorMul(int value, int mulValue) {
            int responsePlayerMoveSpeed = 8;

            PlayerMoveSpeed playerMoveSpeed =
                PlayerMoveSpeed.Of(value) * PlayerMoveSpeed.Of(mulValue);
            Assert.That(playerMoveSpeed.Value, Is.EqualTo(responsePlayerMoveSpeed));
        }

        [Test]
        [TestCase(4, 2)]
        [Description("[正常] 除算が行われた場合に、値が正常に格納されること")]
        public void ValidPlayerMoveSpeedOperatorDiv(int value, int divValue) {
            int responsePlayerMoveSpeed = 2;

            PlayerMoveSpeed playerMoveSpeed =
                PlayerMoveSpeed.Of(value) / PlayerMoveSpeed.Of(divValue);
            Assert.That(playerMoveSpeed.Value, Is.EqualTo(responsePlayerMoveSpeed));
        }

        [Test]
        [TestCase(10, 1)]
        [Description("[正常] 加算した値が最大値より大きい場合に、最大値が格納されていること")]
        public void LimitAddPlayerMoveSpeed(int value, int addValue) {
            int responsePlayerMoveSpeed = 10;

            PlayerMoveSpeed playerMoveSpeed =
                PlayerMoveSpeed.Of(value) + PlayerMoveSpeed.Of(addValue);
            Assert.That(playerMoveSpeed.Value, Is.EqualTo(responsePlayerMoveSpeed));
        }

        [Test]
        [TestCase(0, 1)]
        [Description("[正常] 減算した値が最小値より小さい場合に、最小値が格納されていること")]
        public void LimitSubPlayerMoveSpeed(int value, int subValue) {
            int responsePlayerMoveSpeed = 0;

            PlayerMoveSpeed playerMoveSpeed =
                PlayerMoveSpeed.Of(value) - PlayerMoveSpeed.Of(subValue);
            Assert.That(playerMoveSpeed.Value, Is.EqualTo(responsePlayerMoveSpeed));
        }

        [Test]
        [TestCase(10, 2)]
        [Description("[正常] 乗算した値が最大値より大きい場合に、最大値が格納されていること")]
        public void LimitMulPlayerMoveSpeed(int value, int mulValue) {
            int responsePlayerMoveSpeed = 10;

            PlayerMoveSpeed playerMoveSpeed =
                PlayerMoveSpeed.Of(value) * PlayerMoveSpeed.Of(mulValue);
            Assert.That(playerMoveSpeed.Value, Is.EqualTo(responsePlayerMoveSpeed));
        }

        [Test]
        [TestCase(10, TestCodeIni.ScriptBytes)]
        [Description(
            "[正常] スクリプト自体のサイズとインスタンスのサイズが、スクリプトバイト以下であること"
        )]
        public void ValidScriptCapacity(int value, int scriptBytes) {
            PlayerMoveSpeed playerMoveSpeed = PlayerMoveSpeed.Of(value);

            Assert.That(Marshal.SizeOf(typeof(PlayerMoveSpeed)), Is.LessThanOrEqualTo(scriptBytes));
            Assert.That(Marshal.SizeOf(playerMoveSpeed), Is.LessThanOrEqualTo(scriptBytes));
        }

        [Test]
        [TestCase(int.MinValue)]
        [TestCase(-1)]
        [TestCase(11)]
        [TestCase(int.MaxValue)]
        [Description("[異常] 渡された値が最小値未満か最大値より大きい場合に、スローが投げられること")]
        public void ThrowWhenValueIsOverRange(int value) {
            var exception = Assert.Throws<ArgumentException>(() => {
                PlayerMoveSpeed playerMoveSpeed = PlayerMoveSpeed.Of(value);
            });

            Assert.That(
                exception.Message,
                Is.EqualTo(ExceptionMessage.argumentExceptionMessage)
            );
        }

        [Test]
        [TestCase(1, 0)]
        [Description("[異常] 除算において0で割っている場合に、スローが投げられること")]
        public void ThrowWhenDivPlayerMoveSpeed(int value, int divValue) {
            var exception = Assert.Throws<DivideByZeroException>(() => {
                PlayerMoveSpeed playerMoveSpeed =
                    PlayerMoveSpeed.Of(value) / PlayerMoveSpeed.Of(divValue);
            });

            Assert.That(
                exception.Message,
                Is.EqualTo(ExceptionMessage.divideByZeroExceptionMessage)
            );
        }

    }

}
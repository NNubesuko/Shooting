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

    [Description("プレイヤーの回避速度のテスト")]
    public class PlayerEvasiveSpeedTest {

        [Test]
        [TestCase(0)]
        [TestCase(50)]
        [TestCase(100)]
        [Description("[正常] 渡された値が最小値以上最大値以下である場合に、値が正常に格納されること")]
        public void ValidPlayerEvasiveSpeed(int value) {
            PlayerEvasiveSpeed playerEvasiveSpeed = PlayerEvasiveSpeed.Of(value);
            Assert.That(playerEvasiveSpeed.Value, Is.EqualTo(value));
        }

        [Test]
        [TestCase(10, 2)]
        [Description("[正常] PlayerEvasiveSpeed同士の加算が行われた場合に、値が正常に格納されること")]
        public void ValidPlayerEvasiveSpeedOperatorAdd(int value, int addValue) {
            int responsePlayerEvasiveSpeed = 12;
            PlayerEvasiveSpeed playerEvasiveSpeed =
                PlayerEvasiveSpeed.Of(value) + PlayerEvasiveSpeed.Of(addValue);
            
            Assert.That(playerEvasiveSpeed.Value, Is.EqualTo(responsePlayerEvasiveSpeed));
        }

        [Test]
        [TestCase(10, 2)]
        [Description("[正常] PlayerEvasiveSpeed同士の減算が行われた場合に、値が正常に格納されること")]
        public void ValidPlayerEvasiveSpeedOperatorSub(int value, int subValue) {
            int responsePlayerEvasiveSpeed = 8;
            PlayerEvasiveSpeed playerEvasiveSpeed =
                PlayerEvasiveSpeed.Of(value) - PlayerEvasiveSpeed.Of(subValue);

            Assert.That(playerEvasiveSpeed.Value, Is.EqualTo(responsePlayerEvasiveSpeed));
        }

        [Test]
        [TestCase(10, 2)]
        [Description("[正常] PlayerEvasiveSpeed同士の乗算が行われた場合に、値が正常に格納されること")]
        public void ValidPlayerEvasiveSpeedOperatorMul(int value, int mulValue) {
            int responsePlayerEvasiveSpeed = 20;
            PlayerEvasiveSpeed playerEvasiveSpeed =
                PlayerEvasiveSpeed.Of(value) * PlayerEvasiveSpeed.Of(mulValue);
            
            Assert.That(playerEvasiveSpeed.Value, Is.EqualTo(responsePlayerEvasiveSpeed));
        }

        [Test]
        [TestCase(10, 2)]
        [Description("[正常] PlayerEvasiveSpeed同士の除算が行われた場合に、値が正常に格納されること")]
        public void ValidPlayerEvasiveSpeedOperatorDiv(int value, int divValue) {
            int responsePlayerEvasiveSpeed = 5;
            PlayerEvasiveSpeed playerEvasiveSpeed =
                PlayerEvasiveSpeed.Of(value) / PlayerEvasiveSpeed.Of(divValue);

            Assert.That(playerEvasiveSpeed.Value, Is.EqualTo(responsePlayerEvasiveSpeed));
        }

        [Test]
        [TestCase(100, 1)]
        [Description("[正常] 加算した値が最大値より大きい場合に、最大値が格納されていること")]
        public void LimitAddPlayerEvasiveSpeed(int value, int addValue) {
            int responsePlayerEvasiveSpeed = 100;
            PlayerEvasiveSpeed playerEvasiveSpeed =
                PlayerEvasiveSpeed.Of(value) + PlayerEvasiveSpeed.Of(addValue);
            
            Assert.That(playerEvasiveSpeed.Value, Is.EqualTo(responsePlayerEvasiveSpeed));
        }

        [Test]
        [TestCase(0, 1)]
        [Description("[正常] 減算した値が最小値より小さい場合に、最小値が格納されていること")]
        public void LimitSubPlayerEvasiveSpeed(int value, int subValue) {
            int responsePlayerEvasiveSpeed = 0;
            PlayerEvasiveSpeed playerEvasiveSpeed =
                PlayerEvasiveSpeed.Of(value) - PlayerEvasiveSpeed.Of(subValue);

            Assert.That(playerEvasiveSpeed.Value, Is.EqualTo(responsePlayerEvasiveSpeed));
        }

        [Test]
        [TestCase(100, 2)]
        [Description("[正常] 乗算した値が最大値より大きい場合に、最大値が格納されていること")]
        public void LimitMulPlayerEvasiveSpeed(int value, int mulValue) {
            int responsePlayerEvasiveSpeed = 100;
            PlayerEvasiveSpeed playerEvasiveSpeed =
                PlayerEvasiveSpeed.Of(value) * PlayerEvasiveSpeed.Of(mulValue);
            
            Assert.That(playerEvasiveSpeed.Value, Is.EqualTo(responsePlayerEvasiveSpeed));
        }

        [Test]
        [TestCase(10, TestCodeIni.ScriptBytes)]
        [Description(
            "[正常] スクリプト自体のサイズとインスタンスのサイズが、スクリプトバイト以下であること"
        )]
        public void ValidScriptCapacity(int value, int scriptBytes) {
            PlayerEvasiveSpeed playerEvasiveSpeed = PlayerEvasiveSpeed.Of(value);

            Assert.That(
                Marshal.SizeOf(typeof(PlayerEvasiveSpeed)),
                Is.LessThanOrEqualTo(scriptBytes)
            );
            Assert.That(
                Marshal.SizeOf(playerEvasiveSpeed),
                Is.LessThanOrEqualTo(scriptBytes)
            );
        }

        [Test]
        [TestCase(int.MinValue)]
        [TestCase(-1)]
        [TestCase(101)]
        [TestCase(int.MaxValue)]
        [Description("[異常] 渡された値が最小値未満か最大値より大きい場合に、スローが投げられること")]
        public void ThrowWhenValueIsOverRange(int value) {
            var exception = Assert.Throws<ArgumentException>(() => {
                PlayerEvasiveSpeed playerEvasiveSpeed = PlayerEvasiveSpeed.Of(value);
            });

            Assert.That(
                exception.Message,
                Is.EqualTo(ExceptionMessage.argumentExceptionMessage)
            );
        }

        [Test]
        [TestCase(1, 0)]
        [Description("[異常] 除算において0で割っている場合に、スローが投げられること")]
        public void ThrowWhenDivPlayerEvasiveSpeed(int value, int divValue) {
            var exception = Assert.Throws<DivideByZeroException>(() => {
                PlayerEvasiveSpeed playerEvasiveSpeed =
                    PlayerEvasiveSpeed.Of(value) / PlayerEvasiveSpeed.Of(divValue);
            });
            
            Assert.That(
                exception.Message,
                Is.EqualTo(ExceptionMessage.divideByZeroExceptionMessage)
            );
        }
    }

}

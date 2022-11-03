using System;
using System.Runtime.InteropServices;
using Systemk;
using Systemk.Exceptions;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests {

    [Description("プレイヤーの獲得スコアのテスト")]
    public class PlayerScoreTest {

        [Test]
        [TestCase(0)]
        [TestCase(50)]
        [TestCase(int.MaxValue)]
        [Description("[正常] 渡された値が最小値以上最大値以下である場合に、値が正常に格納されること")]
        public void ValidPlayerScore(int value) {
            PlayerScore playerScore = PlayerScore.Of(value);
            Assert.That(playerScore.Value, Is.EqualTo(value));
        }

        [Test]
        [TestCase(10, 2)]
        [Description("[正常] PlayerScore同士の加算が行われた場合に、値が正常に格納されること")]
        public void ValidPlayerScoreOperatorAdd(int value, int addValue) {
            int responsePlayerScore = 12;

            PlayerScore playerScore = PlayerScore.Of(value) + PlayerScore.Of(addValue);
            Assert.That(playerScore.Value, Is.EqualTo(responsePlayerScore));
        }

        [Test]
        [TestCase(10, 2)]
        [Description("[正常] PlayerScore同士の減算が行われた場合に、値が正常に格納されること")]
        public void ValidPlayerScoreOperatorSub(int value, int subValue) {
            int responsePlayerScore = 8;

            PlayerScore playerScore = PlayerScore.Of(value) - PlayerScore.Of(subValue);
            Assert.That(playerScore.Value, Is.EqualTo(responsePlayerScore));
        }

        [Test]
        [TestCase(10, 2)]
        [Description("[正常] PlayerScore同士の乗算が行われた場合に、値が正常に格納されること")]
        public void ValidPlayerScoreOperatorMul(int value, int mulValue) {
            int responsePlayerScore = 20;

            PlayerScore playerScore = PlayerScore.Of(value) * PlayerScore.Of(mulValue);
            Assert.That(playerScore.Value, Is.EqualTo(responsePlayerScore));
        }

        [Test]
        [TestCase(10, 2)]
        [Description("[正常] PlayerScore同士の除算が行われた場合に、値が正常に格納されること")]
        public void ValidPlayerScoreOperatorDiv(int value, int divValue) {
            int responsePlayerScore = 5;

            PlayerScore playerScore = PlayerScore.Of(value) / PlayerScore.Of(divValue);
            Assert.That(playerScore.Value, Is.EqualTo(responsePlayerScore));
        }

        [Test]
        [TestCase(int.MaxValue, 10)]
        [Description("[正常] 加算した値が最大値より大きい場合に、最大値が格納されていること")]
        public void LimitAddPlayerScore(int value, int addValue) {
            int responsePlayerScore = int.MaxValue;

            PlayerScore playerScore = PlayerScore.Of(value) + PlayerScore.Of(addValue);
            Assert.That(playerScore.Value, Is.EqualTo(responsePlayerScore));
        }

        [Test]
        [TestCase(0, 1)]
        [Description("[正常] 減算した値が最小値より小さい場合に、最小値が格納されていること")]
        public void LimitSubPlayerScore(int value, int subValue) {
            int responsePlayerScore = 0;

            PlayerScore playerScore = PlayerScore.Of(value) - PlayerScore.Of(subValue);
            Assert.That(playerScore.Value, Is.EqualTo(responsePlayerScore));
        }

        [Test]
        [TestCase(int.MaxValue, 2)]
        [Description("[正常] 乗算した値が最大値より大きい場合に、最大値が格納されていること")]
        public void LimitMulPlayerScore(int value, int mulValue) {
            int responsePlayerScore = int.MaxValue;

            PlayerScore playerScore = PlayerScore.Of(value) * PlayerScore.Of(mulValue);
            Assert.That(playerScore.Value, Is.EqualTo(responsePlayerScore));
        }

        [Test]
        [TestCase(100, TestCodeIni.ScriptBytes)]
        [Description(
            "[正常] スクリプト自体のサイズとインスタンスのサイズが、スクリプトバイト以下であること"
        )]
        public void ValidScriptCapacity(int value, int scriptBytes) {
            PlayerScore playerScore = PlayerScore.Of(value);

            Assert.That(Marshal.SizeOf(typeof(PlayerScore)), Is.LessThanOrEqualTo(scriptBytes));
            Assert.That(Marshal.SizeOf(playerScore), Is.LessThanOrEqualTo(scriptBytes));
        }

        [Test]
        [TestCase(int.MinValue)]
        [TestCase(-1)]
        [Description("[異常] 渡された値が最小値未満か最大値より大きい場合に、スローが投げられること")]
        public void ThrowWhenValueIsOverRange(int value) {
            var exception = Assert.Throws<ArgumentException>(() => {
                PlayerScore playerScore = PlayerScore.Of(value);
            });

            Assert.That(
                exception.Message,
                Is.EqualTo(ExceptionMessage.argumentExceptionMessage)
            );
        }

        [Test]
        [TestCase(1, 0)]
        [Description("[異常] 除算において0で割っている場合に、スローが投げられること")]
        public void ThrowWhenDivPlayerScore(int value, int divValue) {
            var exception = Assert.Throws<DivideByZeroException>(() => {
                PlayerScore playerScore = PlayerScore.Of(value) / PlayerScore.Of(divValue);
            });

            Assert.That(
                exception.Message,
                Is.EqualTo(ExceptionMessage.divideByZeroExceptionMessage)
            );
        }

    }

}

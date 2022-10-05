using System;
using Systemk.Exceptions;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests {

    [Description("プレイヤーの回避速度のテスト")]
    public class PlayerEvasiveSpeedTest {

        [Test]
        [Description("[正常] 渡された値が最小値以上最大値以下である場合に、値が正常に格納されること")]
        public void ValidPlayerEvasiveSpeed() {
            List<int> validNumberList = new List<int>() {
                0,
                50,
                100
            };

            foreach (int value in validNumberList) {
                PlayerEvasiveSpeed PlayerEvasiveSpeed = PlayerEvasiveSpeed.Of(value);

                Assert.That(PlayerEvasiveSpeed.Value, Is.EqualTo(value));
            }
        }

        [Test]
        [Description("[正常] PlayerEvasiveSpeed同士の加算が行われた場合に、値が正常に格納されること")]
        public void ValidPlayerEvasiveSpeedOperatorAdd() {
            PlayerEvasiveSpeed PlayerEvasiveSpeed = PlayerEvasiveSpeed.Of(50);
            PlayerEvasiveSpeed addPlayerEvasiveSpeed = PlayerEvasiveSpeed.Of(10);
            int responsePlayerEvasiveSpeed = 60;

            Assert.That(
                (PlayerEvasiveSpeed + addPlayerEvasiveSpeed).Value,
                Is.EqualTo(responsePlayerEvasiveSpeed)
            );
        }

        [Test]
        [Description("[正常] PlayerEvasiveSpeed同士の減算が行われた場合に、値が正常に格納されること")]
        public void ValidPlayerEvasiveSpeedOperatorSub() {
            PlayerEvasiveSpeed PlayerEvasiveSpeed = PlayerEvasiveSpeed.Of(50);
            PlayerEvasiveSpeed subPlayerEvasiveSpeed = PlayerEvasiveSpeed.Of(10);
            int responsePlayerEvasiveSpeed = 40;

            Assert.That(
                (PlayerEvasiveSpeed - subPlayerEvasiveSpeed).Value,
                Is.EqualTo(responsePlayerEvasiveSpeed)
            );
        }

        [Test]
        [Description("[正常] PlayerEvasiveSpeed同士の乗算が行われた場合に、値が正常に格納されること")]
        public void ValidPlayerEvasiveSpeedOperatorMul() {
            PlayerEvasiveSpeed PlayerEvasiveSpeed = PlayerEvasiveSpeed.Of(20);
            PlayerEvasiveSpeed mulPlayerEvasiveSpeed = PlayerEvasiveSpeed.Of(2);
            int responsePlayerEvasiveSpeed = 40;

            Assert.That(
                (PlayerEvasiveSpeed * mulPlayerEvasiveSpeed).Value,
                Is.EqualTo(responsePlayerEvasiveSpeed)
            );
        }

        [Test]
        [Description("[正常] PlayerEvasiveSpeed同士の除算が行われた場合に、値が正常に格納されること")]
        public void ValidPlayerEvasiveSpeedOperatorDiv() {
            PlayerEvasiveSpeed PlayerEvasiveSpeed = PlayerEvasiveSpeed.Of(20);
            PlayerEvasiveSpeed div = PlayerEvasiveSpeed.Of(2);
            int responsePlayerEvasiveSpeed = 10;

            Assert.That(
                (PlayerEvasiveSpeed / div).Value,
                Is.EqualTo(responsePlayerEvasiveSpeed)
            );
        }

        [Test]
        [Description("[異常] 渡された値が最小値未満か最大値より大きい場合に、スローが投げられること")]
        public void ThrowWhenValueIsOverRange() {
            List<int> invalidNumberList = new List<int>() {
                int.MinValue,
                -1,
                101,
                int.MaxValue
            };

            foreach (int value in invalidNumberList) {
                var exception = Assert.Throws<ArgumentException>(() => {
                    PlayerEvasiveSpeed playerEvasiveSpeed = PlayerEvasiveSpeed.Of(value);
                });

                Assert.That(
                    exception.Message,
                    Is.EqualTo(ExceptionMessage.argumentExceptionMessage)
                );
            }
        }

        [Test]
        [Description("[正常] 加算した値が最大値より大きい場合に、最大値が格納されていること")]
        public void LimitAddPlayerEvasiveSpeed() {
            PlayerEvasiveSpeed playerEvasiveSpeed = PlayerEvasiveSpeed.Of(100);
            PlayerEvasiveSpeed addPlayerEvasiveSpeed = PlayerEvasiveSpeed.Of(10);
            int responsePlayerEvasiveSpeed = 100;

            PlayerEvasiveSpeed newPlayerEvasiveSpeed = playerEvasiveSpeed + addPlayerEvasiveSpeed;
            Assert.That(newPlayerEvasiveSpeed.Value, Is.EqualTo(responsePlayerEvasiveSpeed));
        }

        [Test]
        [Description("[正常] 減算した値が最小値より小さい場合に、最小値が格納されていること")]
        public void LimitSubPlayerEvasiveSpeed() {
            PlayerEvasiveSpeed PlayerEvasiveSpeed = PlayerEvasiveSpeed.Of(0);
            PlayerEvasiveSpeed subPlayerEvasiveSpeed = PlayerEvasiveSpeed.Of(10);
            int responsePlayerEvasiveSpeed = 0;

            PlayerEvasiveSpeed newPlayerEvasiveSpeed = PlayerEvasiveSpeed - subPlayerEvasiveSpeed;
            Assert.That(newPlayerEvasiveSpeed.Value, Is.EqualTo(responsePlayerEvasiveSpeed));
        }

        [Test]
        [Description("[正常] 乗算した値が最大値より大きい場合に、最大値が格納されていること")]
        public void LimitMulPlayerEvasiveSpeed() {
            PlayerEvasiveSpeed PlayerEvasiveSpeed = PlayerEvasiveSpeed.Of(100);
            PlayerEvasiveSpeed mulPlayerEvasiveSpeed = PlayerEvasiveSpeed.Of(2);
            int responsePlayerEvasiveSpeed = 100;

            PlayerEvasiveSpeed newPlayerEvasiveSpeed = PlayerEvasiveSpeed * mulPlayerEvasiveSpeed;
            Assert.That(newPlayerEvasiveSpeed.Value, Is.EqualTo(responsePlayerEvasiveSpeed));
        }

        [Test]
        [Description("[異常] 除算において0で割っている場合に、スローが投げられること")]
        public void ThrowWhenDivPlayerEvasiveSpeed() {
            var exception = Assert.Throws<DivideByZeroException>(() => {
                PlayerEvasiveSpeed playerEvasiveSpeed = PlayerEvasiveSpeed.Of(1);
                PlayerEvasiveSpeed divPlayerEvasiveSpeed = PlayerEvasiveSpeed.Of(0);

                PlayerEvasiveSpeed newPlayerEvasiveSpeed =
                    playerEvasiveSpeed / divPlayerEvasiveSpeed;
            });

            Assert.That(
                exception.Message,
                Is.EqualTo(ExceptionMessage.divideByZeroExceptionMessage)
            );
        }
    }

}

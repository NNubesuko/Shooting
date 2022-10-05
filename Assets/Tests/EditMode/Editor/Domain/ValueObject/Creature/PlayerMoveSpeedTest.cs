using System;
using Systemk.Exceptions;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests {
    
    [Description("プレイヤーの移動速度のテスト")]
    public class PlayerMoveSpeedTest {

        [Test]
        [Description("[正常] 渡された値が最小値以上最大値以下である場合に、値が正常に格納されること")]
        public void ValidPlayerMoveSpeed() {
            List<int> validNumberList = new List<int>() {
                0,
                5,
                10
            };

            foreach (int value in validNumberList) {
                PlayerMoveSpeed PlayerMoveSpeed = PlayerMoveSpeed.Of(value);

                Assert.That(PlayerMoveSpeed.Value, Is.EqualTo(value));
            }
        }

        [Test]
        [Description("[正常] PlayerMoveSpeed同士の加算が行われた場合に、値が正常に格納されること")]
        public void ValidPlayerMoveSpeedOperatorAdd() {
            PlayerMoveSpeed playerMoveSpeed = PlayerMoveSpeed.Of(5);
            PlayerMoveSpeed addPlayerMoveSpeed = PlayerMoveSpeed.Of(1);
            int responsePlayerMoveSpeed = 6;

            Assert.That(
                (playerMoveSpeed + addPlayerMoveSpeed).Value,
                Is.EqualTo(responsePlayerMoveSpeed)
            );
        }

        [Test]
        [Description("[正常] PlayerMoveSpeed同士の減算が行われた場合に、値が正常に格納されること")]
        public void ValidPlayerMoveSpeedOperatorSub() {
            PlayerMoveSpeed playerMoveSpeed = PlayerMoveSpeed.Of(5);
            PlayerMoveSpeed subPlayerMoveSpeed = PlayerMoveSpeed.Of(1);
            int responsePlayerMoveSpeed = 4;

            Assert.That(
                (playerMoveSpeed - subPlayerMoveSpeed).Value,
                Is.EqualTo(responsePlayerMoveSpeed)
            );
        }

        [Test]
        [Description("[正常] PlayerMoveSpeed同士の乗算が行われた場合に、値が正常に格納されること")]
        public void ValidPlayerMoveSpeedOperatorMul() {
            PlayerMoveSpeed playerMoveSpeed = PlayerMoveSpeed.Of(2);
            PlayerMoveSpeed mulPlayerMoveSpeed = PlayerMoveSpeed.Of(2);
            int responsePlayerMoveSpeed = 4;

            Assert.That(
                (playerMoveSpeed * mulPlayerMoveSpeed).Value,
                Is.EqualTo(responsePlayerMoveSpeed)
            );
        }

        [Test]
        [Description("[正常] PlayerMoveSpeed同士の除算が行われた場合に、値が正常に格納されること")]
        public void ValidPlayerMoveSpeedOperatorDiv() {
            PlayerMoveSpeed playerMoveSpeed = PlayerMoveSpeed.Of(2);
            PlayerMoveSpeed div = PlayerMoveSpeed.Of(2);
            int responsePlayerMoveSpeed = 1;

            Assert.That(
                (playerMoveSpeed / div).Value,
                Is.EqualTo(responsePlayerMoveSpeed)
            );
        }

        [Test]
        [Description("[異常] 渡された値が最小値未満か最大値より大きい場合に、スローが投げられること")]
        public void ThrowWhenValueIsOverRange() {
            List<int> invalidNumberList = new List<int>() {
                int.MinValue,
                -1,
                11,
                int.MaxValue
            };

            foreach (int value in invalidNumberList) {
                var exception = Assert.Throws<ArgumentException>(() => {
                    PlayerMoveSpeed playerMoveSpeed = PlayerMoveSpeed.Of(value);
                });

                Assert.That(
                    exception.Message,
                    Is.EqualTo(ExceptionMessage.argumentExceptionMessage)
                );
            }
        }

        [Test]
        [Description("[正常] 加算した値が最大値より大きい場合に、最大値が格納されていること")]
        public void LimitAddPlayerMoveSpeed() {
            PlayerMoveSpeed playerMoveSpeed = PlayerMoveSpeed.Of(10);
            PlayerMoveSpeed addPlayerMoveSpeed = PlayerMoveSpeed.Of(1);
            int responsePlayerMoveSpeed = 10;

            PlayerMoveSpeed newPlayerMoveSpeed = playerMoveSpeed + addPlayerMoveSpeed;
            Assert.That(newPlayerMoveSpeed.Value, Is.EqualTo(responsePlayerMoveSpeed));
        }

        [Test]
        [Description("[正常] 減算した値が最小値より小さい場合に、最小値が格納されていること")]
        public void LimitSubPlayerMoveSpeed() {
            PlayerMoveSpeed playerMoveSpeed = PlayerMoveSpeed.Of(0);
            PlayerMoveSpeed subPlayerMoveSpeed = PlayerMoveSpeed.Of(1);
            int responsePlayerMoveSpeed = 0;

            PlayerMoveSpeed newPlayerMoveSpeed = playerMoveSpeed - subPlayerMoveSpeed;
            Assert.That(newPlayerMoveSpeed.Value, Is.EqualTo(responsePlayerMoveSpeed));
        }

        [Test]
        [Description("[正常] 乗算した値が最大値より大きい場合に、最大値が格納されていること")]
        public void LimitMulPlayerMoveSpeed() {
            PlayerMoveSpeed playerMoveSpeed = PlayerMoveSpeed.Of(10);
            PlayerMoveSpeed mulPlayerMoveSpeed = PlayerMoveSpeed.Of(2);
            int responsePlayerMoveSpeed = 10;

            PlayerMoveSpeed newPlayerMoveSpeed = playerMoveSpeed * mulPlayerMoveSpeed;
            Assert.That(newPlayerMoveSpeed.Value, Is.EqualTo(responsePlayerMoveSpeed));
        }

        [Test]
        [Description("[異常] 除算において0で割っている場合に、スローが投げられること")]
        public void ThrowWhenDivPlayerMoveSpeed() {
            var exception = Assert.Throws<DivideByZeroException>(() => {
                PlayerMoveSpeed playerMoveSpeed = PlayerMoveSpeed.Of(1);
                PlayerMoveSpeed addPlayerMoveSpeed = PlayerMoveSpeed.Of(0);
                PlayerMoveSpeed newPlayerMoveSpeed = playerMoveSpeed / addPlayerMoveSpeed;
            });

            Assert.That(
                exception.Message,
                Is.EqualTo(ExceptionMessage.divideByZeroExceptionMessage)
            );
        }

    }

}
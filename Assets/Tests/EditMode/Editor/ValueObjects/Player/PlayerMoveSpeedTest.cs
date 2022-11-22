using System.Collections;
using System.Collections.Generic;
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
        [Description("[正常] 渡された値が最小値以上かつ最大値以下である場合に、正常に格納されること")]
        public void ValidPlayerMoveSpeed(int value) {
            PlayerMoveSpeed playerMoveSpeed = PlayerMoveSpeed.Of(value);
            Assert.That(playerMoveSpeed, Is.EqualTo(PlayerMoveSpeed.Of(value)));
        }

    }

}

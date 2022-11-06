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

    [Description("プレイヤーのテスト")]
    public class PlayerTest {

        // [Test]
        // [TestCase(0, 0, 0, -100, -99, -100, -99, 0)]
        // [TestCase(50, 5, 50, -50, 50, -50, 50, 0)]
        // [TestCase(100, 10, 100, -100, 100, -100, 100, 0)]
        // [Description("[正常] 生成したプレイヤーのパラメータが正常の場合に、格納されること")]
        // public void ValidPlayer(
        //     int hp,
        //     int moveSpeed,
        //     int evasiveSpeed,
        //     float lowHorizontalRange,
        //     float highHorizontalRange,
        //     float lowVerticalRange,
        //     float highVerticalRange,
        //     int score
        // ) {
        //     PlayerHP playerHP = PlayerHP.Of(hp);
        //     PlayerMoveSpeed playerMoveSpeed = PlayerMoveSpeed.Of(moveSpeed);
        //     PlayerEvasiveSpeed playerEvasiveSpeed = PlayerEvasiveSpeed.Of(evasiveSpeed);
        //     PlayerMoveRange moveHorizontalRange = PlayerMoveRange.Of(
        //         lowHorizontalRange,
        //         highHorizontalRange
        //     );
        //     PlayerMoveRange moveVerticalRange = PlayerMoveRange.Of(
        //         lowVerticalRange,
        //         highVerticalRange
        //     );
        //     PlayerScore playerScore = PlayerScore.Of(score);

        //     Player player = Player.Generate(
        //         playerHP,
        //         playerMoveSpeed,
        //         playerEvasiveSpeed,
        //         moveHorizontalRange,
        //         moveVerticalRange,
        //         playerScore
        //     );

        //     Assert.That(player.HP, Is.EqualTo(playerHP));
        //     Assert.That(player.MoveSpeed, Is.EqualTo(playerMoveSpeed));
        //     Assert.That(player.EvasiveSpeed, Is.EqualTo(playerEvasiveSpeed));
        //     Assert.That(player.MoveHorizontalRange, Is.EqualTo(moveHorizontalRange));
        //     Assert.That(player.MoveVerticalRange, Is.EqualTo(moveVerticalRange));
        // }

        // [Test]
        // [TestCase(-100, 10, 100, -100, 100, -100, 100, 0)]
        // [TestCase(100, -10, 100, -100, 100, -100, 100, 0)]
        // [TestCase(100, 10, -100, -100, 100, -100, 100, 0)]
        // [TestCase(100, 10, 100, 100, -100, -100, 100, 0)]
        // [TestCase(100, 10, 100, -100, 100, 100, -100, 0)]
        // [TestCase(100, 10, 100, -100, 100, 100, -100, -1)]
        // [Description("[異常] 生成したプレイヤーのパラメータが異常の場合に、スローが投げられること")]
        // public void InvalidPlayer(
        //     int hp,
        //     int moveSpeed,
        //     int evasiveSpeed,
        //     float lowHorizontalRange,
        //     float highHorizontalRange,
        //     float lowVerticalRange,
        //     float highVerticalRange,
        //     int score
        // ) {
        //     var exception = Assert.Throws<ArgumentException>(() => {
        //         PlayerHP playerHP = PlayerHP.Of(hp);
        //         PlayerMoveSpeed playerMoveSpeed = PlayerMoveSpeed.Of(moveSpeed);
        //         PlayerEvasiveSpeed playerEvasiveSpeed = PlayerEvasiveSpeed.Of(evasiveSpeed);
        //         PlayerMoveRange moveHorizontalRange = PlayerMoveRange.Of(
        //             lowHorizontalRange,
        //             highHorizontalRange
        //         );
        //         PlayerMoveRange moveVerticalRange = PlayerMoveRange.Of(
        //             lowVerticalRange,
        //             highVerticalRange
        //         );
        //         PlayerScore playerScore = PlayerScore.Of(score);

        //         Player player = Player.Generate(
        //             playerHP,
        //             playerMoveSpeed,
        //             playerEvasiveSpeed,
        //             moveHorizontalRange,
        //             moveVerticalRange,
        //             playerScore
        //         );
        //     });

        //     Assert.That(
        //         exception.Message,
        //         Is.EqualTo(ExceptionMessage.argumentExceptionMessage)
        //     );
        // }
    
    }

}

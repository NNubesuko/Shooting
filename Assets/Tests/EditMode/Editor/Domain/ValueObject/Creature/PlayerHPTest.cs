using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests {

    public class PlayerHPTest {

        [Test]
        public void ValidPlayerHP() {
            Debug.Log(
                "[正常] 渡された値がnullではなく最小値以上最大値以下である場合に、値が正常に格納されること"
            );

            List<int> validNumberList = new List<int>();
            validNumberList.Add(0);
            validNumberList.Add(50);
            validNumberList.Add(100);

            foreach (int value in validNumberList) {
                PlayerHP playerHP = PlayerHP.Of(value);

                Assert.That(playerHP.Value, Is.EqualTo(value));
            }
        }

        [Test]
        public void IncludeZeroWhenValueIsNull() {
            Debug.Log("[正常] 渡された値がnullである場合に、最小値に変換し格納すること");

            PlayerHP playerHP = PlayerHP.Of(null);
            int comparedValue = PlayerHP.MIN;

            Assert.That(playerHP.Value, Is.EqualTo(comparedValue));
        }

        [Test]
        public void ThrowWhenValueIsOverRange() {
            Debug.Log("[異常] 渡された値が最小値未満か最大値より大きい場合に、スローが投げられること");

            List<int> invalidNumberList = new List<int>();
            invalidNumberList.Add(int.MinValue);
            invalidNumberList.Add(-1);
            invalidNumberList.Add(101);
            invalidNumberList.Add(int.MaxValue);

            foreach (int value in invalidNumberList) {
                void PlayerHPMethod() {
                    PlayerHP.Of(value);
                }

                Assert.Throws<ArgumentException>(
                    PlayerHPMethod
                );
            }
        }

    }

}

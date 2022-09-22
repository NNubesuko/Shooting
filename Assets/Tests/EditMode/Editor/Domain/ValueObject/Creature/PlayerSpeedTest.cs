using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests {
    
    public class PlayerSpeedTest {

        [Test]
        public void ValidPlayerSpeed() {
            Debug.Log("[正常] 渡された値が最小値以上最大値以下である場合に、値が正常に格納されること");

            List<int> validNumberList = new List<int>();
            validNumberList.Add(0);
            validNumberList.Add(5);
            validNumberList.Add(10);

            foreach (int value in validNumberList) {
                PlayerSpeed playerSpeed = PlayerSpeed.Of(value);

                Assert.That(playerSpeed.Value, Is.EqualTo(value));
            }
        }

        [Test]
        public void ThrowWhenValueIsOverRange() {
            Debug.Log("[異常] 渡された値が最小値未満か最大値より大きい場合に、スローが投げられること");

            List<int> invalidNumberList = new List<int>();
            invalidNumberList.Add(int.MinValue);
            invalidNumberList.Add(-1);
            invalidNumberList.Add(11);
            invalidNumberList.Add(int.MaxValue);

            foreach(int value in invalidNumberList) {
                void PlayerSpeedMethod() {
                    PlayerSpeed.Of(value);
                }

                Assert.Throws<ArgumentException>(
                    PlayerSpeedMethod
                );
            }
        }

    }

}

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
            Debug.Log("[正常] 渡された値が最小値以上最大値以下である場合に、値が正常に格納されること");

            List<int> validNumberList = new List<int>() {
                0,
                50,
                100
            };

            foreach (int value in validNumberList) {
                PlayerHP playerHP = PlayerHP.Of(value);

                Assert.That(playerHP.Value, Is.EqualTo(value));
            }
        }

        [Test]
        public void ValidPlayerHPOperatorAdd() {
            Debug.Log("[正常] PlayerHP同士の加算が行われた場合に、値が正常に格納されること");

            PlayerHP playerHP = PlayerHP.Of(50);
            PlayerHP addPlayerHP = PlayerHP.Of(10);
            int responsePlayerHP = 60;

            Assert.That((playerHP + addPlayerHP).Value, Is.EqualTo(responsePlayerHP));
        }

        [Test]
        public void ValidPlayerHPOperatorSub() {
            Debug.Log("[正常] PlayerHP同士の減算が行われた場合に、値が正常に格納されること");

            PlayerHP playerHP = PlayerHP.Of(50);
            PlayerHP subPlayerHP = PlayerHP.Of(10);
            int responsePlayerHP = 40;

            Assert.That((playerHP - subPlayerHP).Value, Is.EqualTo(responsePlayerHP));
        }

        [Test]
        public void ValidPlayerHPOperatorMul() {
            Debug.Log("[正常] PlayerHP同士の乗算が行われた場合に、値が正常に格納されること");

            PlayerHP playerHP = PlayerHP.Of(20);
            PlayerHP mulPlayerHP = PlayerHP.Of(2);
            int responsePlayerHP = 40;

            Assert.That((playerHP * mulPlayerHP).Value, Is.EqualTo(responsePlayerHP));
        }

        [Test]
        public void ValidPlayerHPOperatorDiv() {
            Debug.Log("[正常] PlayerHP同士の除算が行われた場合に、値が正常に格納されること");

            PlayerHP playerHP = PlayerHP.Of(20);
            PlayerHP div = PlayerHP.Of(2);
            int responsePlayerHP = 10;

            Assert.That((playerHP / div).Value, Is.EqualTo(responsePlayerHP));
        }

        [Test]
        public void ThrowWhenValueIsOverRange() {
            Debug.Log("[異常] 渡された値が最小値未満か最大値より大きい場合に、スローが投げられること");

            List<int> invalidNumberList = new List<int>() {
                int.MinValue,
                -1,
                101,
                int.MaxValue
            };

            foreach (int value in invalidNumberList) {
                void PlayerHPMethod() {
                    PlayerHP.Of(value);
                }

                Assert.Throws<ArgumentException>(
                    PlayerHPMethod
                );
            }
        }

        [Test]
        public void ThrowWhenAddPlayerHP() {
            Debug.Log("[異常] PlayerHP同士の加算が行われ結果が異常である場合に、スローが投げられること");

            PlayerHP playerHP = PlayerHP.Of(100);
            PlayerHP addPlayerHP = PlayerHP.Of(10);

            void PlayerHPMethod() {
                PlayerHP newPlayerHP = playerHP + addPlayerHP;
            }

            Assert.Throws<ArithmeticException>(
                PlayerHPMethod
            );
        }

        [Test]
        public void ThrowWhenSubPlayerHP() {
            Debug.Log("[異常] PlayerHP同士の減算が行われ結果が異常である場合に、スローが投げられること");

            PlayerHP playerHP = PlayerHP.Of(0);
            PlayerHP addPlayerHP = PlayerHP.Of(10);

            void PlayerHPMethod() {
                PlayerHP newPlayerHP = playerHP - addPlayerHP;
            }

            Assert.Throws<ArithmeticException>(
                PlayerHPMethod
            );
        }

        [Test]
        public void ThrowWhenMulPlayerHP() {
            Debug.Log("[異常] PlayerHP同士の乗算が行われ結果が異常である場合に、スローが投げられること");

            PlayerHP playerHP = PlayerHP.Of(100);
            PlayerHP addPlayerHP = PlayerHP.Of(2);

            void PlayerHPMethod() {
                PlayerHP newPlayerHP = playerHP * addPlayerHP;
            }

            Assert.Throws<ArithmeticException>(
                PlayerHPMethod
            );
        }

        [Test]
        public void ThrowWhenDivPlayerHP() {
            Debug.Log("[異常] PlayerHP同士の除算において0で割っている場合に、スローが投げられること");

            PlayerHP playerHP = PlayerHP.Of(1);
            PlayerHP addPlayerHP = PlayerHP.Of(0);

            void PlayerHPMethod() {
                PlayerHP newPlayerHP = playerHP / addPlayerHP;
            }

            Assert.Throws<DivideByZeroException>(
                PlayerHPMethod
            );
        }

    }

}

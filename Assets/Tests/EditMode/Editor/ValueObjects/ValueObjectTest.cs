using System;
using KataokaLib.AutoTest;
using NUnit.Framework;

namespace Tests.Editor.ValueObjects
{
    // テストする大元は、PlayerHp.cs
    [Description("値オブジェクトのテストを自動生成させる")]
    public class ValueObjectTest
    {
        [Test]
        [TestCase(0)]
        [TestCase(50)]
        [TestCase(100)]
        [Description("[正常] 渡された値が最小値以上かつ最大値以下である場合に、正常に格納されること")]
        public void OnValidArgument(int value)
        {
            PlayerHp playerHp = PlayerHp.Of(value);
            Assert.That(
                playerHp,
                Is.EqualTo(PlayerHp.Of(value)));
        }
        
        [Test]
        [TestCase(int.MinValue)]
        [TestCase(-1)]
        [TestCase(101)]
        [TestCase(int.MinValue)]
        [Description("[異常] 渡された値が最小値未満または最大値より大きい場合に、スローが投げられること")]
        public void OnInvalidArgument(int value)
        {
            Assert.That(
                () =>
                {
                    PlayerHp playerHp = PlayerHp.Of(value);
                },
                Throws.TypeOf<ArgumentException>());
        }
    }
}
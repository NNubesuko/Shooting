using System.Text;

/*

ClassName = PlayerHp
 - value: string

TestCases = { [TestCase(0)], [TestCase(50)], [TestCase(100)] }
 - cases: List

DescriptionText = [正常] 渡された値が最小値以上かつ最大値以下である場合に、値が格納されること
- value: string

Argument = int value
 - type: string
 - value: string

FieldName = playerHp
 - value: string

public class <ClassName>
{
    * GetOnValidArgument
    [Test]
    <TestCases>
    [Description("<DescriptionText>")]
    public void OnValidArgument(<Argument>)
    {
        <ClassName> <FieldName> = <ClassName>.Of(<Argument.value>);
        Assert.That(<FieldName>, Is.Equals(<ClassName>.Of(<Argument.value>)));
    }
    
    * GetOnInvalidArgument
    [Test]
    <TestCases>
    [Description("<DescriptionText>")]
    public void OnInvalidArgument(<Argument.type> <Argument.value>)
    {
        Assert.That(() =>
            {
                <ClassName> <FieldName> = <ClassName>.Of(<Argument.value>);
            },
            Throws.Type<ArgumentException>());
    }
}

*/

namespace KataokaLib.AutoTest
{
    public class ValueObjectTestFormat
    {
        public string GetOnValidArgument()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("");

            return sb.ToString();
        }
    }
}
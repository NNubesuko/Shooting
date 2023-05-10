using System.Text;
using System.Text.RegularExpressions;
using UnityEngine;

/*

[Description("<Description>")]
public class <ClassName>Test
{
    [Test]
    <TestCases>
    [Description("<Description>")]
    public void <MethodName>(<ArgumentType>)
    {
        <ClassName> fieldName = <ClassName>.Of(value);
        Assert.That(fieldName, Is.Equals(<ClassName>.Of(value)));
    }
}

*/

namespace KataokaLib.AutoTest
{
    public class ValueObjectTestFormat
    {
        private string _className;
        
        public ValueObjectTestFormat(string className)
        {
            _className = className;
        }
        
        public string GetClass()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("[Description(\"<ClassName>のテスト\")]").Append("\n");
            sb.Append("public class <ClassName>Test").Append("\n");
            sb.Append("{").Append("\n");
            sb.Append("<Tests>").Append("\n");
            sb.Append("}").Append("\n");

            string res = Regex.Match(sb.ToString(), "<.*>", RegexOptions.Multiline).Value;
            Debug.Log(res);

            return sb.ToString();
        }
        
        public string GetOnValidArgument()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("\t[Test]").Append("\n");
            sb.Append("\t<TestCases>").Append("\n");
            sb.Append("\t[Description(\"<Description>\")]").Append("\n");
            sb.Append("\tpublic void OnValidArgument(<Argument>)").Append("\n");
            sb.Append("\t{").Append("\n");
            sb.Append("\t\t<ClassName> <FieldName> = <ClassName>.Of(<Argument.value>);").Append("\n");
            sb.Append("\t\tAssert.That(<FieldName>, Is.Equals(<ClassName>.Of(<Argument.value>)));").Append("\n");
            sb.Append("\t}").Append("\n");

            return sb.ToString();
        }

        public string GetOnInvalidArgument()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("\t[Test]").Append("\n");
            sb.Append("\t<TestCases>").Append("\n");
            sb.Append("\t[Description(\"<Description>\")]").Append("\n");
            sb.Append("\tpublic void OnInvalidArgument(<Argument>)").Append("\n");
            sb.Append("\t{").Append("\n");
            sb.Append("\t\tAssert.That(() =>").Append("\n");
            sb.Append("\t\t\t{").Append("\n");
            sb.Append("\t\t\t\t<ClassName> <FieldName> = <ClassName>.Of(<Argument.value>);").Append("\n");
            sb.Append("\t\t\t},").Append("\n");
            sb.Append("\t\t\tThrows.Type<ArgumentException>());").Append("\n");
            sb.Append("\t}").Append("\n");

            return sb.ToString();
        }
    }
}
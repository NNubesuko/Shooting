using System;
using System.Text;

namespace KataokaLib.AutoTest
{
    public class ValueObjectTestTemplate
    {
        public static string CreateTestClass(string className)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("using System;").Append("\n")
                .Append("using NUnit.Framework;").Append("\n")
                .Append("using KataokaLib.ValueObject;").Append("\n")
                .Append("\n")
                .Append("namespace Tests {").Append("\n")
                .Append("\n")
                .Append("\t[Description(\"").Append(className).Append("のテスト\")]\n")
                .Append("\tpublic class ").Append(className).Append("Test {\n")
                .Append("\t}").Append("\n")
                .Append("\n")
                .Append("}");

            return sb.ToString();
        }

        public static string CreateOnValidArgumentTest(Object min, Object max, Type valueType, string className)
        {
            string fieldName = className.Substring(0, 1).ToLower() + className.Substring(1);
            Object ave = ((dynamic)min + (dynamic)max) / 2;
            
            StringBuilder sb = new StringBuilder();
            sb.Append("\t\t[Test]").Append("\n")
                .Append($"\t\t[TestCase({min})]").Append("\n")
                .Append($"\t\t[TestCase({ave})]").Append("\n")
                .Append($"\t\t[TestCase({max})]").Append("\n")
                .Append("\t\t[Description(\"[正常] 渡された値が最小値以上かつ最大値以下である場合に、正常に格納されること\")]").Append("\n")
                .Append($"\t\tpublic void OnValidArgument({valueType.Name} value)").Append("\n")
                .Append("\t\t{").Append("\n")
                .Append($"\t\t\t{className} {fieldName} = {className}.Of(value);").Append("\n")
                .Append($"\t\t\tAssert.That({fieldName}, Is.EqualTo({className}.Of(value)));").Append("\n")
                .Append("\t\t}").Append("\n");

            return sb.ToString();
        }

        public static string CreateOnInvalidArgumentTest(Object min, Object max, Type valueType, string className)
        {
            string fieldName = className.Substring(0, 1).ToLower() + className.Substring(1);
            Object minSub = (dynamic)min - 1;
            Object maxAdd = (dynamic)max + 1;
            
            StringBuilder sb = new StringBuilder();
            sb.Append("\t\t[Test]").Append("\n")
                .Append($"\t\t[TestCase({valueType.Name}.MinValue)]").Append("\n")
                .Append($"\t\t[TestCase({minSub})]").Append("\n")
                .Append($"\t\t[TestCase({maxAdd})]").Append("\n")
                .Append($"\t\t[TestCase({valueType.Name}.MaxValue)]").Append("\n")
                .Append("\t\t[Description(\"[異常] 渡された値が最小値未満または最大値より大きい場合に、スローが投げられること\")]").Append("\n")
                .Append($"\t\tpublic void OnInvalidArgument({valueType.Name} value)").Append("\n")
                .Append("\t\t{").Append("\n")
                .Append("\t\t\tAssert.That(").Append("\n")
                .Append("\t\t\t() =>").Append("\n")
                .Append("\t\t\t{").Append("\n")
                .Append($"\t\t\t\t{className} {fieldName} = {className}.Of(value);").Append("\n")
                .Append("\t\t\t},").Append("\n")
                .Append("\t\t\tThrows.TypeOf<ArgumentException>());").Append("\n")
                .Append("\t\t}").Append("\n");

            return sb.ToString();
        }
    }
}
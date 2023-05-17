using System;
using System.DirectoryServices.Protocols;
using System.IO;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using KataokaLib.Extension.Directory;
using KataokaLib.Extension.File;
using log4net.Appender;
using UnityEditor;
using UnityEngine;
using Object = System.Object;

namespace KataokaLib.AutoTest
{
    [InitializeOnLoad]
    public class GenerateValueObjectTest
    {
        private static readonly string valueObjectsDirectory = "/Scripts/ValueObjects/";
        private static readonly string valueObjectsTestDirectory = "/Tests/EditMode/Editor/ValueObjects/";
        
        static GenerateValueObjectTest()
        {
            // 値オブジェクト用のアトリビュートがついている型（クラス）を取得する
            TypeCache.TypeCollection typeCollection = TypeCache.GetTypesWithAttribute<ValueObjectAttribute>();
            foreach (Type type in typeCollection)
            {
                ValueObjectAttribute valueObjectAttribute = type.GetCustomAttribute<ValueObjectAttribute>();
                string className = type.Name;
                string testClassName = type.Name + "Test";
                
                // Assets/Scripts/ValueObjects/{DirectoryName}/{ClassName}.cs
                // 値オブジェクトのアトリビュートがついているクラスまでのパスを作成する
                StringBuilder sbFilePath = new StringBuilder();
                sbFilePath.Append(Application.dataPath)
                    .Append(valueObjectsDirectory)
                    .Append(valueObjectAttribute.directoryName).Append("/")
                    .Append(className).Append(".cs");
                string filePath = sbFilePath.ToString();

                StringBuilder sbTestDirectoryPath = new StringBuilder();
                sbTestDirectoryPath.Append(Application.dataPath)
                    .Append(valueObjectsTestDirectory)
                    .Append(valueObjectAttribute.directoryName);
                string testDirectoryPath = sbTestDirectoryPath.ToString();

                StringBuilder sbTestFilePath = new StringBuilder(testDirectoryPath);
                sbTestFilePath.Append("/")
                    .Append(testClassName).Append(".cs");
                string testFilePath = sbFilePath.ToString();

                // クラスのcsファイルを読み込む
                using (StreamReader sr = new StreamReader(filePath, Encoding.UTF8))
                {
                    string program = sr.ReadToEnd();

                    DirectoryExtension.Create(testDirectoryPath);
                    FileExtension.Create(testFilePath);

                    string classProgram = CreateTestClass(className);
                    Debug.Log(classProgram);
                    string me = CreateOnValidArgumentTest(
                        valueObjectAttribute.min,
                        valueObjectAttribute.max,
                        valueObjectAttribute.valueType,
                        className);
                    Debug.Log(me);
                }
            }
        }

        private static string CreateTestClass(string className)
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

        private static string CreateOnValidArgumentTest(Object min, Object max, Type valueType, string className)
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

        private static bool ExistConstructor(string program, Type type)
        {
            bool existConstructor = Regex.IsMatch(
                program,
                $".* {type.Name} *\\(",
                RegexOptions.Multiline);
            bool existOfMethod = Regex.IsMatch(
                program,
                $"static {type.Name} Of *\\(",
                RegexOptions.Multiline);

            return existConstructor & existOfMethod;
        }

        private static bool ExistOperator(string program, string operatorType)
        {
            return Regex.IsMatch(
                program,
                $"operator *\\{operatorType} *\\(",
                RegexOptions.Multiline);
        }
        
        private static bool ExistAddOperator(string program) => ExistOperator(program, "+");
        private static bool ExistSubOperator(string program) => ExistOperator(program, "-");
        private static bool ExistMulOperator(string program) => ExistOperator(program, "*");
        private static bool ExistDivOperator(string program) => ExistOperator(program, "/");
    }
}
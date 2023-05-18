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

                    string classProgram = ValueObjectTestTemplate.CreateTestClass(className);
                    Debug.Log(classProgram);
                    
                    string validMethod = ValueObjectTestTemplate.CreateOnValidArgumentTest(
                        valueObjectAttribute.min,
                        valueObjectAttribute.max,
                        valueObjectAttribute.valueType,
                        className);
                    Debug.Log(validMethod);

                    string invalidMethod = ValueObjectTestTemplate.CreateOnInvalidArgumentTest(
                        valueObjectAttribute.min,
                        valueObjectAttribute.max,
                        valueObjectAttribute.valueType,
                        className);
                    Debug.Log(invalidMethod);
                }
            }
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
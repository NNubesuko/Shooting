using System;
using System.IO;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using KataokaLib.Extension.Directory;
using KataokaLib.Extension.File;
using UnityEditor;
using UnityEngine;

namespace KataokaLib.AutoTest
{
    [Flags]
    public enum ValueObjectsTestType : byte
    {
        Constructor     = 1 << 0,
        Add             = 1 << 1,
        Sub             = 1 << 2,
        Mul             = 1 << 3,
        Div             = 1 << 4,
    }
    
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

                    byte insertPrograms = 0b0000_0000;
                    insertPrograms |= ExistConstructor(program, type);
                    insertPrograms |= ExistAddOperator(program);
                    insertPrograms |= ExistSubOperator(program);
                    insertPrograms |= ExistMulOperator(program);
                    insertPrograms |= ExistDivOperator(program);

                    Array valueObjectsTestType = typeof(ValueObjectsTestType).GetEnumValues();
                    for (int i = 0; i < valueObjectsTestType.Length; i++)
                    {
                        if ( (insertPrograms & (byte)valueObjectsTestType.GetValue(i)) != 0 )
                        {
                            
                        }
                    }

                    // string classProgram = ValueObjectTestTemplate.CreateTestClass(className);
                    // Debug.Log(classProgram);

                    // string validMethod = ValueObjectTestTemplate.CreateOnValidArgumentTest(
                    //     valueObjectAttribute.min,
                    //     valueObjectAttribute.max,
                    //     valueObjectAttribute.valueType,
                    //     className);
                    // // Debug.Log(validMethod);
                    //
                    // string invalidMethod = ValueObjectTestTemplate.CreateOnInvalidArgumentTest(
                    //     valueObjectAttribute.min,
                    //     valueObjectAttribute.max,
                    //     valueObjectAttribute.valueType,
                    //     className);
                    // // Debug.Log(invalidMethod);
                    //
                    // // テストメソッドを挿入する位置を取得する
                    // int insertIndex = classProgram.LastIndexOf("\t}\n");
                    // Debug.Log(classProgram.Substring(0, insertIndex - 1));
                    // Debug.Log(classProgram.Substring(insertIndex));


                }
            }
        }

        private static byte ExistConstructor(string program, Type type)
        {
            bool existConstructor = Regex.IsMatch(
                program,
                $".* {type.Name} *\\(",
                RegexOptions.Multiline);
            bool existOfMethod = Regex.IsMatch(
                program,
                $"static {type.Name} Of *\\(",
                RegexOptions.Multiline);

            if (existConstructor & existOfMethod)
            {
                return (byte)ValueObjectsTestType.Constructor;
            }

            return 1 >> 1;
        }

        private static byte ExistOperator(
            string program,
            string operatorType,
            ValueObjectsTestType valueObjectsTestType)
        {
            bool existOperator = Regex.IsMatch(
                program,
                $"operator *\\{operatorType} *\\(",
                RegexOptions.Multiline);

            if (existOperator)
            {
                return (byte)valueObjectsTestType;
            }

            return 1 >> 1;
        }
        
        private static byte ExistAddOperator(string program) => ExistOperator(program, "+", ValueObjectsTestType.Add);
        private static byte ExistSubOperator(string program) => ExistOperator(program, "-", ValueObjectsTestType.Sub);
        private static byte ExistMulOperator(string program) => ExistOperator(program, "*", ValueObjectsTestType.Mul);
        private static byte ExistDivOperator(string program) => ExistOperator(program, "/", ValueObjectsTestType.Div);
    }
}
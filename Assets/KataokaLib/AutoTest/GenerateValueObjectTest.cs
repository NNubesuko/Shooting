using System;
using System.IO;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;

namespace KataokaLib.AutoTest
{
    [InitializeOnLoad]
    public class GenerateValueObjectTest
    {
        static GenerateValueObjectTest()
        {
            // 値オブジェクト用のアトリビュートがついている型（クラス）を取得する
            TypeCache.TypeCollection typeCollection = TypeCache.GetTypesWithAttribute<ValueObjectAttribute>();
            foreach (Type type in typeCollection)
            {
                ValueObjectAttribute valueObjectAttribute = type.GetCustomAttribute<ValueObjectAttribute>();
                
                // Assets/Scripts/ValueObjects/{DirectoryName}/{ClassName}.cs
                // 値オブジェクトのアトリビュートがついているクラスまでのパスを作成する
                StringBuilder filePath = new StringBuilder();
                filePath.Append(Application.dataPath)
                    .Append("/Scripts/ValueObjects/")
                    .Append(valueObjectAttribute.directoryName).Append("/")
                    .Append(type.Name).Append(".cs");

                // クラスのcsファイルを読み込む
                using (StreamReader sr = new StreamReader(filePath.ToString(), Encoding.UTF8))
                {
                    string program = sr.ReadToEnd();
                    // クラス名
                    Debug.Log(type.Name);
                    // クラスのプログラム
                    Debug.Log(program);//

                    Debug.Log("Exist Constructor: " + ExistConstructor(program, type));
                    Debug.Log("Exist Add Operator: " + ExistAddOperator(program));
                    Debug.Log("Exist Sub Operator: " + ExistSubOperator(program));
                    Debug.Log("Exist Mul Operator: " + ExistMulOperator(program));
                    Debug.Log("Exist Div Operator: " + ExistDivOperator(program));
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

        private static bool ExistAddOperator(string program) => ExistOperator(program, "+");
        private static bool ExistSubOperator(string program) => ExistOperator(program, "-");
        private static bool ExistMulOperator(string program) => ExistOperator(program, "*");
        private static bool ExistDivOperator(string program) => ExistOperator(program, "/");

        private static bool ExistOperator(string program, string operatorType)
        {
            return Regex.IsMatch(
                program,
                $"operator *\\{operatorType} *\\(",
                RegexOptions.Multiline);
        }
    }
}
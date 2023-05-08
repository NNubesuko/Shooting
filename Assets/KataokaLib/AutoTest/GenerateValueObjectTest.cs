using System;
using System.IO;
using System.Reflection;
using System.Text;
using KataokaLib.Extension;
using UnityEditor;
using UnityEngine;

/*
 * TypeCacheより、ValueObjectAttributeがついているオブジェクトを取得できた
 * テストを作成する場所のパスを持ってくる（Player●●やEnemy●●と統一すれば、フォルダも自動作成）
 *
 * 
 * オブジェクトのテストがあるか確認
 * 無ければ生成する
 */

namespace KataokaLib.AutoTest
{
    [InitializeOnLoad]
    public class GenerateValueObjectTest
    {
        private static string path = Application.dataPath + "/KataokaLib/AutoTest/";

        static GenerateValueObjectTest()
        {
            // var typeCollection = TypeCache.GetTypesWithAttribute<ValueObjectAttribute>();
            // foreach (var type in typeCollection)
            // {
            //     string directoryPath = CreateDirectory(type);
            //     string filePath = CreateTestFile(type, directoryPath);
            // }

            string className = "PlayerHp";
            string fieldName = className.Replace(className[0..1], className[0..1].ToLower());

            StringBuilder sb = new StringBuilder();
            sb.Append("public class <ClassName>\n");
            sb.Append("{\n");
            sb.Append("\t[Test]\n");
            sb.Append("\t[Description(\"[正常] 渡された値が最小値以上かつ最大値以下である場合に、正常に格納されること\")]\n");
            sb.Append("\tpublic void OnValidArgument(int value)\n");
            sb.Append("\t{\n");
            sb.Append("\t\t<ClassName> <FieldName> = <ClassName>.Of(value);\n");
            sb.Append("\t\tAssert.That(<FieldName>, Is.Equals(<ClassName>.Of(value)));\n");
            sb.Append("\t}\n");
            sb.Append("}");

            string program = sb.ToString()
                .Replace("<ClassName>", className)
                .Replace("<FieldName>", fieldName);
            Debug.Log(program);

            // AssetPostprocessBase.imported += OnImported;
        }

        private static string CreateDirectory(Type type)
        {
            ValueObjectAttribute valueObjectAttribute = type.GetCustomAttribute<ValueObjectAttribute>();
            string directoryPath = path + valueObjectAttribute.directoryName;
            
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            return directoryPath;
        }

        private static string CreateTestFile(Type type, string directoryPath)
        {
            string filePath = directoryPath + "/" + type.Name + "Test.cs";
            if (!File.Exists(filePath))
            {
                File.Create(filePath);
            }

            return filePath;
        }

        private static void OnImported(string importedAsset)
        {
            Debug.Log(importedAsset);
        }
    }
}
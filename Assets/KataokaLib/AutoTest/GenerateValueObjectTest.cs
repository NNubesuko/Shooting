using KataokaLib.Extension;
using UnityEditor;
using UnityEngine;

namespace KataokaLib.AutoTest
{
    [InitializeOnLoad]
    public class GenerateValueObjectTest
    {
        static GenerateValueObjectTest()
        {
            Debug.Log("Generate Value Object Test");
            AssetPostprocessBase.imported += OnImported;
        }

        private static void OnImported(string importedAsset)
        {
            Debug.Log(importedAsset);
        }
    }
}
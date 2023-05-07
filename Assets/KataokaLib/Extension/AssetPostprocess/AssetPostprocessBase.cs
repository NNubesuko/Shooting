using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

namespace KataokaLib.Extension
{
    public class AssetPostprocessBase : AssetPostprocessor
    {
        public static OnImported imported;
        public static OnUpdated updated;
        public static OnDeleted deleted;
        public static OnMoved moved;

        private static bool _isUnityEditorFocused;
        private static bool _needReloading;
        private static LinkedList<string> _importedAssets;

        [InitializeOnLoadMethod]
        private static void InitializeOnLoad()
        {
            EditorApplication.update += Update;
            _importedAssets = new LinkedList<string>();
        }
        
        private static void Update()
        {
            if (!_isUnityEditorFocused && InternalEditorUtility.isApplicationActive)
            {
                _isUnityEditorFocused = InternalEditorUtility.isApplicationActive;
                OnApplicationFocused();
            }
            else if (_isUnityEditorFocused && !InternalEditorUtility.isApplicationActive)
            {
                _isUnityEditorFocused = InternalEditorUtility.isApplicationActive;
            }
        }

        public static void OnPostprocessAllAssets(
            string[] importedAssets,
            string[] deletedAssets,
            string[] movedAssets,
            string[] movedFromAssetPaths)
        {
            foreach (var importedAsset in importedAssets)
            {
                _importedAssets.AddLast(importedAsset);

                // Unity外から戻ってきた場合には、delayCallまでの間に_needReloadingにtrueが代入される
                _needReloading = false;
                EditorApplication.delayCall += OnAssetImported;
            }

            foreach (var updatedAsset in importedAssets)
            {
                updated?.Invoke(updatedAsset);
            }

            foreach (var deletedAsset in deletedAssets)
            {
                deleted?.Invoke(deletedAsset);
            }

            foreach (var movedAsset in movedAssets)
            {
                moved?.Invoke(movedAsset);
            }
            
            imported = null;
            updated = null;
            deleted = null;
            moved = null;
        }
        
        private static void OnApplicationFocused()
        {
            _needReloading = true;
        }

        private static void OnAssetImported()
        {
            // この時点で_needReloadingがtrueなら、アセットに変更が加わった、かつUnity外からフォーカスが戻ってきたと判断できる
            if (_needReloading)
            {
                string importedAsset = _importedAssets.First.Value;
                imported?.Invoke(importedAsset);
            }
            
            _importedAssets.RemoveFirst();
        }

        public delegate void OnImported(string importedAsset);

        public delegate void OnUpdated(string updatedAsset);

        public delegate void OnDeleted(string deletedAsset);

        public delegate void OnMoved(string movedAsset);
    }
}
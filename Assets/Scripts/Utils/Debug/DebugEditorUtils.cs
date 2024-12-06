#if UNITY_EDITOR
using System.Linq;
using UnityEditor;

namespace MemoryGame.Utils
{
    public class DebugEditorUtils
    {
        private static DebugEditorSettings _debugSettingsAssetCache;

        public static DebugEditorSettings GetDebugSettings()
        {
            if (_debugSettingsAssetCache == null)
            {
                var debugAssetGUID = AssetDatabase.FindAssets($"{nameof(DebugEditorSettings)}").FirstOrDefault();
                var debugAssetRelativePath = AssetDatabase.GUIDToAssetPath(debugAssetGUID);
                _debugSettingsAssetCache = AssetDatabase.LoadAssetAtPath<DebugEditorSettings>(debugAssetRelativePath);
            }

            return _debugSettingsAssetCache;
        }
    }
}
#endif

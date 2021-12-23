using UnityEditor;
using UnityEngine;

namespace Editor
{
    public static class EnterPlayMode
    {
        [RuntimeInitializeOnLoadMethod]
        private static void Init()
        {
            EditorApplication.playModeStateChanged += OnEnterPlayMode;
        }

        private static void OnEnterPlayMode(PlayModeStateChange obj)
        {
            if (obj == PlayModeStateChange.ExitingEditMode) AssetDatabase.Refresh(ImportAssetOptions.Default);
        }
    }
}
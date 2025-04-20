#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEngine;

[InitializeOnLoad]
public static class AutoExportOnExitPlayMode {
    static AutoExportOnExitPlayMode() {
        EditorApplication.playModeStateChanged += OnPlayModeStateChanged;
    }

    static void OnPlayModeStateChanged(PlayModeStateChange state) {
        if (state == PlayModeStateChange.EnteredEditMode) {
            if (PlayerPrefs.GetInt("AutoExportRequest", 0) == 1) {
                PlayerPrefs.SetInt("AutoExportRequest", 0);
                PlayerPrefs.Save();

                AutoPrefabExporter.Export();
            }
        }
    }
}
#endif
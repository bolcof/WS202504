#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(FbxExportSettings))]
public class FbxExportSettingsEditor : Editor {
    public override void OnInspectorGUI() {
        serializedObject.Update();

        SerializedProperty dirProp = serializedObject.FindProperty("fbxOutputDirectory");
        SerializedProperty nameProp = serializedObject.FindProperty("fbxFileName");

        // フォルダ選択UI
        EditorGUILayout.LabelField("Fbx Output Directory", EditorStyles.boldLabel);
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.PropertyField(dirProp, GUIContent.none);
        if (GUILayout.Button("...", GUILayout.Width(30))) {
            string selectedPath = EditorUtility.OpenFolderPanel("出力先フォルダを選択", dirProp.stringValue, "");
            if (!string.IsNullOrEmpty(selectedPath)) {
                dirProp.stringValue = selectedPath;
            }
        }
        EditorGUILayout.EndHorizontal();

        // ファイル名入力欄
        EditorGUILayout.PropertyField(nameProp);

        serializedObject.ApplyModifiedProperties();
    }
}
#endif
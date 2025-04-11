using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PoseManager : MonoBehaviour {

    public List<Transform> joints;
    public PoseLibrary poseLibrary; // 保存先（ScriptableObject）

    public void PushSavePose(string newPoseName) {
        if (poseLibrary == null) {
            Debug.LogError("PoseLibraryがアサインされていません！");
            return;
        }

        Pose pose = new Pose(newPoseName);
        foreach (var joint in joints) {
            pose.AddJointRotation(joint.localRotation);
        }

        poseLibrary.AddPose(pose);
        Debug.Log($"Pose '{newPoseName}' を保存しました。");

#if UNITY_EDITOR
        UnityEditor.EditorUtility.SetDirty(poseLibrary); // ScriptableObjectの変更をEditorに認識させる
        UnityEditor.AssetDatabase.SaveAssets();          // 保存
#endif
    }
}
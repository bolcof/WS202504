using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PoseManager : MonoBehaviour {

    public static PoseManager instance;

    public List<Transform> joints;
    public PoseLibrary poseLibrary; // 保存先（ScriptableObject）

    private void Awake() {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    public void SavePose(string newPoseName) {
        if (poseLibrary == null) {
            Debug.LogError("PoseLibraryがアサインされていません！");
            return;
        }

        if(newPoseName == "") {
            Debug.LogError("PoseNameが設定されていません！");
            return;
        }

        bool exists = poseLibrary.poses.Exists(p => p.name == newPoseName);
        if (exists) {
            Debug.LogError($"Pose名 '{newPoseName}' はすでに存在します！");
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
    public void LoadPose(string poseName) {
        if (poseLibrary == null) {
            Debug.LogError("PoseLibraryがアサインされていません！");
            return;
        }

        Pose pose = poseLibrary.poses.Find(p => p.name == poseName);
        if (pose == null) {
            Debug.LogError($"Pose名 '{poseName}' が見つかりません！");
            return;
        }

        if (pose.jointDatas.Count != joints.Count) {
            Debug.LogWarning($"PoseデータのJoint数（{pose.jointDatas.Count}）と現在のJoint数（{joints.Count}）が一致していません！");
        }

        int count = Mathf.Min(joints.Count, pose.jointDatas.Count);
        for (int i = 0; i < count; i++) {
            joints[i].localRotation = pose.jointDatas[i];
        }

        Debug.Log($"Pose '{poseName}' を読み込み適用しました。");
    }
}
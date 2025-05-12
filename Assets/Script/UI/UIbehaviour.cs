using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIbehaviour : MonoBehaviour {
    [SerializeField] private TMP_Text boxVisibleButtonLabel;
    [SerializeField] private TMP_InputField poseNameInput;
    [SerializeField] private GameObject modelExportedPanel;
    [SerializeField] private GameObject fbxExportedPanel;

    [SerializeField] private TMP_Text stopButtonLabel;
    private bool isPausing;

    private void Start() {
        modelExportedPanel.SetActive(false);
        fbxExportedPanel.SetActive(false);
        isPausing = false;
        boxVisibleButtonLabel.text = "ベースを非表示";
        stopButtonLabel.text = "一時停止";
    }

    public void PushExportModel() {
        PlayerPrefs.SetInt("ExportModelRequest", 1);
        PlayerPrefs.Save();
        Debug.Log("Modelエクスポートリクエストを記録（再生終了時に実行）");
        modelExportedPanel.SetActive(true);
    }

    public void PushExportFbx() {
        PlayerPrefs.SetInt("ExportFBXRequest", 1);
        PlayerPrefs.Save();
        Debug.Log("FBXエクスポートリクエストを記録（再生終了時に実行）");
        fbxExportedPanel.SetActive(true);
    }

    public void PushBoxVisible() {
        if (ModelManager.instance.ChangeBaseModelVisble()) {
            boxVisibleButtonLabel.text = "ベースを非表示";
        } else {
            boxVisibleButtonLabel.text = "ベースを表示";
        }
    }

    public void PushNextAnimation() {
        AnimationStateController.instance.AdvanceAnimation();
    }

    public void PushPauseAnimation() {
        if (isPausing) {
            AnimationStateController.instance.ResumeAnimation();
            stopButtonLabel.text = "一時停止";
        } else {
            AnimationStateController.instance.PauseAnimation();
            stopButtonLabel.text = "再生";
        }
        isPausing = !isPausing;
    }

    public void PushSavePose() {
        PoseManager.instance.SavePose(poseNameInput.text);
    }

    public void PushLoadPose(string poseName) {
        PoseManager.instance.LoadPose(poseName);
    }
}
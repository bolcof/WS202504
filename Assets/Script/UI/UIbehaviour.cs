using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIbehaviour : MonoBehaviour {
    [SerializeField] private TMP_Text boxVisibleButtonLabel;
    [SerializeField] private TMP_InputField poseNameInput;
    [SerializeField] private GameObject exportedPanel;

    [SerializeField] private TMP_Text stopButtonLabel;
    private bool isPausing;

    private void Start() {
        exportedPanel.SetActive(false);
        isPausing = false;
        boxVisibleButtonLabel.text = "Base:OFF";
        stopButtonLabel.text = "Pause";
    }

    public void PushExportModel() {
        //PlayerPrefs.SetInt("AutoExportRequest", 1);
        PlayerPrefs.SetInt("ExportFBXRequest", 1);
        PlayerPrefs.Save();
        Debug.Log("エクスポートリクエストを記録（再生終了時に実行）");
        exportedPanel.SetActive(true);
    }

    public void PushBoxVisible() {
        if (ModelManager.instance.ChangeBaseModelVisble()) {
            boxVisibleButtonLabel.text = "Base:ON";
        } else {
            boxVisibleButtonLabel.text = "Base:OFF";
        }
    }

    public void PushNextAnimation() {
        AnimationStateController.instance.AdvanceAnimation();
    }

    public void PushPauseAnimation() {
        if (isPausing) {
            AnimationStateController.instance.ResumeAnimation();
            stopButtonLabel.text = "Pause";
        } else {
            AnimationStateController.instance.PauseAnimation();
            stopButtonLabel.text = "Resume";
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
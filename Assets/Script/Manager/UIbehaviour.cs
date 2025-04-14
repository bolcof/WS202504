using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIbehaviour : MonoBehaviour {
    [SerializeField] private TMP_Text boxVisibleButtonLabel;
    [SerializeField] private TMP_InputField poseNameInput;
    public void PushBoxVisible() {
        if (ModelManager.instance.ChangeBoxesVisble()) {
            boxVisibleButtonLabel.text = "BOX:ON";
        } else {
            boxVisibleButtonLabel.text = "BOX:OFF";
        }
    }

    public void PushSavePose() {
        PoseManager.instance.SavePose(poseNameInput.text);
    }
}
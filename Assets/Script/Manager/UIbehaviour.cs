using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIbehaviour : MonoBehaviour {
    [SerializeField] private TMP_Text boxVisibleButtonLabel;
    public void PushBoxVisible() {
        if (ModelManager.instance.ChangeBoxesVisble()) {
            boxVisibleButtonLabel.text = "BOX:ON";
        } else {
            boxVisibleButtonLabel.text = "BOX:OFF";
        }
    }
}
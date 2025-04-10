using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PoseManager : MonoBehaviour {

    [SerializeField] private List<GameObject> jointSphereList = new List<GameObject>();

    public struct PoseData {
        string poseName;

    }
    private List<Quaternion> jointDataList = new List<Quaternion>();

    public void PushSavePose() {

        for(int i=0;i<jointSphereList.Count; i++) {

        }
    }
}
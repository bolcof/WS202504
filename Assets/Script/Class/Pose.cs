using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Pose {
    public string name;
    public List<Quaternion> jointDatas = new List<Quaternion>();

    public Pose(string name) {
        this.name = name;
    }

    public void AddJointRotation(Quaternion rotation) {
        jointDatas.Add(rotation);
    }
}
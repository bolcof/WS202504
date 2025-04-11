using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "PoseLibrary", menuName = "Pose/PoseLibrary")]
public class PoseLibrary : ScriptableObject {
    public List<Pose> poses = new List<Pose>();

    public void AddPose(Pose pose) {
        poses.Add(pose);
    }
}
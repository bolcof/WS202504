using UnityEngine;

[CreateAssetMenu(fileName = "FbxExportSettings", menuName = "Settings/FBX Export Settings")]
public class FbxExportSettings : ScriptableObject {
    public string fbxOutputDirectory = "";
    public string fbxFileName = "ExportedPackage3";
}
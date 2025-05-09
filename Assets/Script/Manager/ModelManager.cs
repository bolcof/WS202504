using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelManager : MonoBehaviour {
    public static ModelManager instance;

    private bool baseVisible = true;
    [SerializeField] private SkinnedMeshRenderer jointMesh, modelMesh;

    private void Awake() {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    public bool ChangeBaseModelVisble() {
        baseVisible = !baseVisible;
        jointMesh.enabled = baseVisible;
        modelMesh.enabled = baseVisible;
        return baseVisible;
    }
}
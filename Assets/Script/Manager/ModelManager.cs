using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelManager : MonoBehaviour {
    public static ModelManager instance;

    private bool sampleBoxesVisibled = true;
    [SerializeField] private List<GameObject> sampleBoxes = new List<GameObject>();

    private void Awake() {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    public bool ChangeBoxesVisble() {
        sampleBoxesVisibled = !sampleBoxesVisibled;
        foreach (GameObject go in sampleBoxes) {
            go.SetActive(sampleBoxesVisibled);
        }
        return sampleBoxesVisibled;
    }
}
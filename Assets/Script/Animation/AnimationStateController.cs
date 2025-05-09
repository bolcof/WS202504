using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimationStateController : MonoBehaviour {
    public static AnimationStateController instance;

    public Animator animator;
    private int currentIndex = 0;

    private const int maxStateIndex = 3;

    private void Awake() {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    public void AdvanceAnimation() {
        currentIndex = (currentIndex + 1) % (maxStateIndex + 1);
        animator.SetInteger("stateIndex", currentIndex);
        Debug.Log($"アニメーション遷移: {currentIndex}");
    }
}
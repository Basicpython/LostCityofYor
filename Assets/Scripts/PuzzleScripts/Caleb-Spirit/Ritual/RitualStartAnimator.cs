using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RitualStartAnimator : MonoBehaviour
{
    public GameObject Ritual;
    public bool isActive;

    void Start() {
        isActive = false;
    }

    public void StartRitual() {
        if (Ritual != null) {
            Animator[] animators = Ritual.GetComponentsInChildren<Animator>();
            foreach (Animator animator in animators) {
                animator.SetBool("isActive", true);
                isActive = true;
                Debug.Log("Started Ritual Animation");
            }
        }
    }

    public void StopRitual() {
        if (Ritual != null) {
            Animator[] animators = Ritual.GetComponentsInChildren<Animator>();
            foreach (Animator animator in animators) {
                animator.SetBool("isActive", false);
                isActive = false;
                Debug.Log("Stopped Ritual Animation");
            }
        }
    }
}

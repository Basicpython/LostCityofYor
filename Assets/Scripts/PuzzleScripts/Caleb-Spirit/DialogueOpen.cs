using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueOpen : MonoBehaviour
{

    public GameObject Panel;

    public bool isOpen;

    public void OpenPanel() {
        if (Panel != null) {
            Animator animator = Panel.GetComponent<Animator>();
            if (animator != null) {
                animator.SetBool("open", true);
                isOpen = true;
            }
        }
    }

    public void ClosePanel() {
        if (Panel != null) {
            Animator animator = Panel.GetComponent<Animator>();
            if (animator != null) {
                animator.SetBool("open", false);
                isOpen = false;
            }
        }
    }
}

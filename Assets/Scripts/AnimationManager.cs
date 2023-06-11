using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimationManager : MonoBehaviour
{
    public Animator animator;

    void OnMouseEnter()
    {
        animator.SetTrigger("Hover");

    }

    void OnMouseExit()
    {
        animator.SetTrigger("Idle");
    }
}

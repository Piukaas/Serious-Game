using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    public Animator animator;
    private static readonly int Hover = Animator.StringToHash("Hover");
    private static readonly int Idle = Animator.StringToHash("Idle");

    void OnMouseEnter()
    {
        animator.SetTrigger(Hover);

    }

    void OnMouseExit()
    {
        animator.SetTrigger(Idle);
    }
}

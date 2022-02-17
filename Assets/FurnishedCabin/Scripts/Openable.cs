using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Openable : MonoBehaviour
{
    private Animator animator;
    private bool isOpen;

    protected virtual void Awake()
    {
        animator = GetComponent<Animator>();
    }
    public virtual void OpenClose()
    {
        if (isOpen)
        {
            animator.SetBool("is_open", isOpen);
            isOpen = false;
        }
        else
        {
            animator.SetBool("is_open", isOpen);
            isOpen = true;
        }
    }
}

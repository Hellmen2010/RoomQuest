using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Openable : MonoBehaviour
{
    private Animator animator;
    private bool isOpen = false;

    protected virtual void Awake()
    {
        animator = GetComponent<Animator>();
    }
    public virtual void OpenClose()
    {
        animator.SetBool("is_open", !isOpen);
        isOpen = !isOpen;
    }
}

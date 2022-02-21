using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Openable : MonoBehaviour
{
    [SerializeField] private Animator animatorOverride;
    private Animator _animator;

    protected Animator animator => animatorOverride != null ? animatorOverride : _animator is null ? _animator = GetComponent<Animator>() ?? throw new MissingComponentException() : _animator;
    private bool isOpen = false;

    public virtual void OpenClose()
    {
        animator.SetBool("is_open", !isOpen);
        isOpen = !isOpen;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Openable : MonoBehaviour
{
    [SerializeField] private Animator animatorOverride;
    private Animator _animator;

    protected Animator animator => animatorOverride != null ? animatorOverride : _animator is null ? _animator = GetComponent<Animator>() ?? throw new MissingComponentException() : _animator;
    protected bool isOpened = false;

    public bool IsOpened
    {
        get => isOpened;
        private set
        {
            isOpened = value;
            animator.SetBool("is_open", isOpened);
        }
    }

    public virtual void SetObjectFromSave(RoomObjectSave roomObjectSave)
    {
        IsOpened = roomObjectSave.isOpened;
    }

    public virtual void OpenClose()
    {
        animator.SetBool("is_open", !isOpened);
        isOpened = !isOpened;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacterAnimation : MonoBehaviour
{
    [SerializeField] private FirstPersonController player;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        Move();
    }
    public virtual void Move()
    {
        animator.SetBool("isWalking", player.IsWalking);
    }
}

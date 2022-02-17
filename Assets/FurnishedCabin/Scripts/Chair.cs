using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chair : MonoBehaviour
{
    private Animator animator;
    private bool nearTheTable;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        nearTheTable = true;
    }
    public void Move()
    {
        if (nearTheTable)
        {
            animator.SetBool("near_the_table", nearTheTable);
            nearTheTable = false;
        }
        else
        {
            animator.SetBool("near_the_table", nearTheTable);
            nearTheTable = true;
        }
    }
}
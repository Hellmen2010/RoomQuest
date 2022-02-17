using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locker : Openable
{
    private bool lockerUnlocked;

    private void Awake()
    {
        lockerUnlocked = false;
    }

    public override void OpenClose()
    {
        if (lockerUnlocked)
        {
            base.OpenClose();
        }
        else
        {
            Debug.Log("Door is locked");
        }
    }
}

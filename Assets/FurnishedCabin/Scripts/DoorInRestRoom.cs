using Lean.Gui;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInRestRoom : Openable
{
    private bool restRoomDoorIsUnlocked;
    private LeanToggle openingscript;

    private void Awake()
    {
        restRoomDoorIsUnlocked = true;
        openingscript = GetComponent<LeanToggle>();
    }
    private void Start()
    {
        //GlobalEventManager.OnRedKeyPickup += UnlockingDoor;
        openingscript.enabled = false;
    }

    private void Update()
    {
        
    }
    //public override void OpenClose()
    //{
    //    if (restRoomDoorIsUnlocked)
    //    {
    //        base.OpenClose();
    //    }
    //    else
    //    {
    //        Debug.Log("Door is locked");
    //    }
    //}
    private void UnlockingDoor()
    {
        restRoomDoorIsUnlocked = true;
        openingscript.enabled = true;
    }
}

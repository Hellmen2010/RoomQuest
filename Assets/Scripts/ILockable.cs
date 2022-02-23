using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILockable
{
    public bool IsLocked { get; }
    public void SetObjectFromSave(RoomObjectSave roomObjectSave);
}

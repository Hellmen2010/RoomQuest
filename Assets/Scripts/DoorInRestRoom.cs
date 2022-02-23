using Lean.Gui;
using UnityEngine;

public class DoorInRestRoom : Openable, ILockable
{
    [SerializeField] private PlayerRaycast player;
    [SerializeField] private AudioStore audioStore;
    private bool restRoomDoorIsUnlocked;
    private AudioSource audioSource;

    public bool IsLocked => restRoomDoorIsUnlocked;

    public override void OpenClose()
    {
        if (restRoomDoorIsUnlocked)
        {
            base.OpenClose();
        }
        else
        {
            if (player.PlayerInventory.HasItemInInventory(PickableObjectType.Redkey))
            {
                UnlockDoor();  
            }
            else
                audioSource.PlayOneShot(audioStore.GetAudioClipByType(AudioType.DoorLocked));
        }
    }


    private void UnlockDoor()
    {
        restRoomDoorIsUnlocked = true;
        audioSource.PlayOneShot(audioStore.GetAudioClipByType(AudioType.DoorUnlocked));
    }

    public override void SetObjectFromSave(RoomObjectSave roomObjectSave)
    {
        base.SetObjectFromSave(roomObjectSave);
        restRoomDoorIsUnlocked = roomObjectSave.isLocked;
    }
}

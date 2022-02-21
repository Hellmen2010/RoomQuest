using Lean.Gui;
using UnityEngine;

public class DoorInRestRoom : Openable
{
    [SerializeField] private Inventory inventory;
    [SerializeField] private AudioStore audioStore;
    private bool restRoomDoorIsUnlocked;
    private AudioSource audioSource;
    protected void Awake()
    {
        inventory = inventory.GetComponent<Inventory>();
        audioSource = GetComponent<AudioSource>();
    }

    public override void OpenClose()
    {
        if (restRoomDoorIsUnlocked)
        {
            base.OpenClose();
        }
        else
            audioSource.PlayOneShot(audioStore.GetAudioClipByType(AudioType.DoorLocked));
    }

    private void Update()
    {
        if (inventory.inventoryContent.Contains(PickableObjectType.Redkey) && restRoomDoorIsUnlocked == false)
        {
            UnlockingDoor();
            audioSource.PlayOneShot(audioStore.GetAudioClipByType(AudioType.DoorUnlocked));
        }
    }

    private void UnlockingDoor()
    {
        restRoomDoorIsUnlocked = true;
    }
}

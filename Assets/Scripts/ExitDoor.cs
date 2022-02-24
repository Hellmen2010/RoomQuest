using System.Linq;
using UnityEngine;

public class ExitDoor : Openable, ILockable
{
    [SerializeField] private PlayerRaycast player;
    [SerializeField] private AudioStore audioStore;
    public bool IsLocked => exitDoorIsLocked;
    private bool exitDoorIsLocked;
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private PickableObjectType[] requestedItems = new PickableObjectType[] 
    {
        PickableObjectType.Boots,
        PickableObjectType.Trousers,
        PickableObjectType.TShirt,
        PickableObjectType.Jacket 
    };


    public override void OpenClose()
    {
        if (exitDoorIsLocked)
        {
            base.OpenClose();
        }
        else
        {
            if (requestedItems.SequenceEqual(player.PlayerInventory.InventoryContent))
            {
                UnlockDoor();
                Debug.Log("You collected all clothes");
            }
            else
                audioSource.PlayOneShot(audioStore.GetAudioClipByType(AudioType.DoorLocked));
        }
    }

    private void UnlockDoor()
    {
        exitDoorIsLocked = true;
        audioSource.PlayOneShot(audioStore.GetAudioClipByType(AudioType.DoorUnlocked));
    }
    public override void SetObjectFromSave(RoomObjectSave roomObjectSave)
    {
        base.SetObjectFromSave(roomObjectSave);
        exitDoorIsLocked = roomObjectSave.isLocked;
    }
}

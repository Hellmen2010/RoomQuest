using Lean.Gui;
using UnityEngine;

public class DoorInRestRoom : Openable
{
    [SerializeField] private Inventory inventory;
    private bool restRoomDoorIsUnlocked;

    protected override void Awake()
    {
        base.Awake();
        inventory = inventory.GetComponent<Inventory>();
    }

    public override void OpenClose()
    {
        if (restRoomDoorIsUnlocked)
        {
            base.OpenClose();
        }
        
    }

    private void Update()
    {
        if (inventory.inventoryContent.ContainsKey("Redkey") && restRoomDoorIsUnlocked == false)
        {
            UnlockingDoor();
        }
    }

    private void UnlockingDoor()
    {
        restRoomDoorIsUnlocked = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField] private enum spritesForInventory { }

    [SerializeField] GameObject inventorySlotPrefab;
    [SerializeField] GameObject parentForInventorySlot;
    [SerializeField] InventoryImage inventoryImage;
    public Dictionary<string,GameObject> inventoryContent = new Dictionary<string, GameObject>();
    private void Awake()
    {
        GlobalEventManager.OnItemPickup += AddItem;
    }
    public void AddItem(Pickups pickup)
    {
        GameObject inventorySlot = Instantiate(inventorySlotPrefab, parentForInventorySlot.transform);
        inventorySlot.GetComponentInChildren<Image>().sprite = inventoryImage.GetItemByType(pickup);
        inventoryContent.Add(pickup.ToString(), inventorySlot);
    }
    private void OnDestroy()
    {
        GlobalEventManager.OnItemPickup -= AddItem;
    }
}

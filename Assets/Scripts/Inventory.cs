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
    public List<PickableObjectType> inventoryContent;
    private void Awake()
    {
        GlobalEventManager.OnItemPickup += AddItem;
    }
    public void AddItem(PickableObjectType pickup)
    {
        GameObject inventorySlot = Instantiate(inventorySlotPrefab, parentForInventorySlot.transform);
        inventorySlot.GetComponentInChildren<Image>().sprite = inventoryImage.GetItemByType(pickup);
        inventoryContent.Add(pickup);
    }
    private void OnDestroy()
    {
        GlobalEventManager.OnItemPickup -= AddItem;
    }
}

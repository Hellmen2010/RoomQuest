using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField] private enum spritesForInventory { }

    [SerializeField] GameObject inventorySlotPrefab;
    [SerializeField] GameObject parentForInventorySlot;
    public Dictionary<string,GameObject> inventoryContent;
    [SerializeField] InventoryImage inventoryImage;
    private void Awake()
    {
        GlobalEventManager.OnItemPickup.AddListener(AddItem);
    }
    public void AddItem(Pickups pickup)
    {
        Instantiate(inventorySlotPrefab, parentForInventorySlot.transform);
        inventorySlotPrefab.GetComponent<Image>().sprite = inventoryImage.GetItemByType(pickup);
    }
}

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
    private List<PickableObjectType> inventoryContent = new List<PickableObjectType>();

    private void Start()
    {
        GameManager.Instance.OnItemPickup += AddItem;
    }
    public void AddItem(PickableObjectType pickup)
    {
        GameObject inventorySlot = Instantiate(inventorySlotPrefab, parentForInventorySlot.transform);
        inventorySlot.GetComponentInChildren<Image>().sprite = inventoryImage.GetItemByType(pickup);
        inventoryContent.Add(pickup);
    }

    public bool HasItemInInventory(PickableObjectType pickableObjectType) => inventoryContent.Contains(pickableObjectType);

    private void OnDestroy()
    {
        GameManager.Instance.OnItemPickup -= AddItem;
    }

    public PickableObjectType[] GetInventoryArray() => inventoryContent.ToArray();
}

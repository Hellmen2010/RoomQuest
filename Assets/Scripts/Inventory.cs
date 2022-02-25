using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField] private enum spritesForInventory { }

    [SerializeField] InventorySlotConstructor inventorySlotPrefab;
    [SerializeField] GameObject parentForInventorySlot;
    [SerializeField] InventoryImage inventoryImage;
    private List<PickableObjectType> inventoryContent = new List<PickableObjectType>();
    public List<PickableObjectType> InventoryContent { get { return inventoryContent; } }

    private void Start()
    {
        GameManager.Instance.OnItemPickup += AddItem;
        gameObject.SetActive(false);
    }
    public void AddItem(PickableObjectType pickup)
    {
        InventorySlotConstructor inventorySlot = Instantiate(inventorySlotPrefab, parentForInventorySlot.transform);
        inventorySlot.ConstructInventoryItem(pickup);
        inventoryContent.Add(pickup);
    }

    public bool HasItemInInventory(PickableObjectType pickableObjectType) => inventoryContent.Contains(pickableObjectType);
    

    private void OnDestroy()
    {
        GameManager.Instance.OnItemPickup -= AddItem;
    }

    public PickableObjectType[] GetInventoryArray() => inventoryContent.ToArray();
}

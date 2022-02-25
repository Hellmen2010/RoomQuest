using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlotConstructor : MonoBehaviour
{
    [SerializeField] InventoryImage inventoryImageSource;
    [SerializeField] Image image;

    public void ConstructInventoryItem(PickableObjectType pickup)
    {
        image.sprite = inventoryImageSource.GetItemByType(pickup);
    }
    
}

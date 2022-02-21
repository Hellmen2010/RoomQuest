using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System;

[CreateAssetMenu(menuName = "ScriptableObjects/InventoryItems")]

public class InventoryImage : ScriptableObject
{
    [SerializeField] private ItemsField[] itemImages;

    public Sprite GetItemByType(PickableObjectType pickups)
    {
        return itemImages.First(x => x.pickups == pickups).image;
    }

}

[Serializable]
public class ItemsField
{
    public PickableObjectType pickups;
    public Sprite image;
}

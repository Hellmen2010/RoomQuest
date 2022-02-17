using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System;

[CreateAssetMenu(menuName = "ScriptableObjects/InventoryItems")]

public class InventoryImage : ScriptableObject
{
    [SerializeField] private ItemsField[] itemImages;

    public Sprite GetItemByType(Pickups pickups)
    {
        return itemImages.First(x => x.pickups == pickups).image;
    }

}

[Serializable]
public class ItemsField
{
    public Pickups pickups;
    public Sprite image;
}

using UnityEngine;

public enum PickableObjectType
{
    Redkey, Boots, Trousers, TShirt, Jacket
}

public class PickupItem : MonoBehaviour
{
    [SerializeField] private PickableObjectType objectType;

    public PickableObjectType ObjectType => objectType;

    public void Pickup()
    {
        GameManager.Instance.TriggerOnItemPickup(objectType);
        Destroy(gameObject);
    }
}

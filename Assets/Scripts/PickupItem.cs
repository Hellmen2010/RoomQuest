using UnityEngine;

public enum PickableObjectType
{
    Redkey, Boots, Trousers, TShirt
}

public class PickupItem : MonoBehaviour
{
    [SerializeField] private PickableObjectType pickup;
    public void Pickup()
    {
        
        GlobalEventManager.TriggerOnItemPickup(pickup);
        Destroy(gameObject);
    }

}

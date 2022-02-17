using UnityEngine;

public enum Pickups
{
    Redkey, Boots, Trousers, TShirt
}

public class PickupItem : MonoBehaviour
{
    [SerializeField] private Pickups pickup;
    public void Pickup()
    {
        Destroy(gameObject);
        GlobalEventManager.TriggerOnItemPickup(pickup);
        
    }

}

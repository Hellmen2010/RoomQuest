using UnityEngine;

public enum PickableObjectType
{
    Redkey, Boots, Trousers, TShirt
}

public class PickupItem : MonoBehaviour
{
    [SerializeField] private PickableObjectType pickup;
    private Outline outline;

    private void Awake()
    {
        outline = GetComponent<Outline>();
    }
    public void Pickup()
    {
        
        GlobalEventManager.TriggerOnItemPickup(pickup);
        Destroy(gameObject);
    }
    private void OnMouseOver()
    {
        outline.enabled = true;
    }
    private void OnMouseExit()
    {
        outline.enabled = false;
    }
}

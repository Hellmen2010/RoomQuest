using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] PickObjectPosition[] objectPositionsParent;


    public void SpawnObjects(IEnumerable<PickableObjectType> pickableObjectTypes)
    {
        foreach (var pickableObject in pickableObjectTypes)
        {
            PickObjectPosition pickupItemPositionParent = objectPositionsParent.First(t => t.ObjectType == pickableObject);
            PickupItem pickupItem = Instantiate(pickupItemPositionParent.PickupItemPref, pickupItemPositionParent.transform);
        }
    }
}

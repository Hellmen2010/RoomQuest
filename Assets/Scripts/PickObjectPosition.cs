using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PickObjectPosition : MonoBehaviour
{
    [SerializeField] private PickupItem pickupItemPref;

    public PickupItem PickupItemPref => pickupItemPref;
    public PickableObjectType ObjectType => pickupItemPref.ObjectType;
}

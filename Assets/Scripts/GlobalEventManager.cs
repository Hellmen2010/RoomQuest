using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class GlobalEventManager
{
    public static Action<PickableObjectType> OnItemPickup;

    public static void TriggerOnItemPickup(PickableObjectType pickup)
    {
        OnItemPickup?.Invoke(pickup);
    }
}

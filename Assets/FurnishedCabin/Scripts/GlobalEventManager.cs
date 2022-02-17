using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class GlobalEventManager
{
    public static UnityEvent<Pickups> OnItemPickup = new UnityEvent<Pickups>();

    public static void TriggerOnItemPickup(Pickups pickup)
    {
        OnItemPickup?.Invoke(pickup);
    }
}

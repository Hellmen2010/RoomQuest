using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : Singleton<EventManager>
{
    [SerializeField] private GameObject playerRay;
    [SerializeField] private UnityEvent<GameObject> onPickup;

    public UnityEvent<GameObject> OnPickup => onPickup is null ? onPickup = new UnityEvent<GameObject>() : onPickup;

    public void OnPicking(GameObject invoker)
    {
        Debug.Log(invoker.name);
        Destroy(invoker);
    }

}

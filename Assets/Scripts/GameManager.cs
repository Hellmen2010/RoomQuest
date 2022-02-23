using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager: MonoBehaviour
{
    [SerializeField] private SaveSystem saveSystem;
    public static GameManager Instance;

    public Action<PickableObjectType> OnItemPickup;

    private void Awake()
    {
        Instance = this;
        //saveSystem.Load();
        Invoke("Save", 5);
    }

    public void TriggerOnItemPickup(PickableObjectType pickup)
    {
        OnItemPickup?.Invoke(pickup);
    }

    public void Save()
    {
        saveSystem.Save();
    }
}

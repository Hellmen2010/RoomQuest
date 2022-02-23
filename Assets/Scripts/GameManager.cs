using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager: MonoBehaviour
{
    [SerializeField] private SaveSystem saveSystem;
    public static GameManager Instance;

    public Action<PickableObjectType> OnItemPickup;

    private void Awake()
    {
        Instance = this;
        saveSystem.Load();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F5))
            saveSystem.Save();
        if (Input.GetKeyDown(KeyCode.F4) && saveSystem.HasSave)
        {
            LoadFromFileInfo.loadFromFileState = loadingType.FromFile;
            SceneManager.LoadScene("Game");
        }
    }

    public void TriggerOnItemPickup(PickableObjectType pickup)
    {
        OnItemPickup?.Invoke(pickup);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Linq;

//inventory
//doors
//player transform

[Serializable]
public class PlayerSave
{
    public float[] position;
    public float[] rotation;
    public PickableObjectType[] inventory;

    public PlayerSave(PlayerRaycast player)
    {
        position = player.transform.position.ConvertToFloat();
        rotation = player.transform.rotation.eulerAngles.ConvertToFloat();
        inventory = player.PlayerInventory.GetInventoryArray();
    }
}

[Serializable]
public class RoomObjectSave
{
    public bool isOpened;
    public bool isLocked;

    public RoomObjectSave(Openable openable)
    {
        ILockable lockable = openable as ILockable;
        if (lockable != null)
            isLocked = lockable.IsLocked;
        else
            isLocked = false;
        isOpened = openable.IsOpened;
    }
}

[Serializable]
public class DayTimeSave
{
    public float skyboxExposure;

    public DayTimeSave(DayTimeController dayTimeController)
    {
        skyboxExposure = dayTimeController.SkyboxExposure;
    }
}

public class SaveSystem : MonoBehaviour
{
    [SerializeField] private string saveFilename = "save.txt";
    [SerializeField] private ObjectSpawner objectSpawner;
    [SerializeField] private DayTimeController dayTimeController;
    [SerializeField] private PlayerRaycast player;
    [SerializeField] private Openable[] openableObjects;

    public bool HasSave
    {
        get
        {
            string filepath = Path.Combine(Application.persistentDataPath, saveFilename);
            return File.Exists(filepath);
        }
    }

    public void Save()
    {
        PlayerSave playerSave = new PlayerSave(player);
        string playerInfoJSON = JsonUtility.ToJson(playerSave);
        RoomObjectSave[] roomObjectSaves = new RoomObjectSave[openableObjects.Length];
        for (int i = 0; i < openableObjects.Length; i++)
            roomObjectSaves[i] = new RoomObjectSave(openableObjects[i]);
        string objectsInfoJSON = roomObjectSaves.ConvertArrayToString();
        DayTimeSave dayTimeSave = new DayTimeSave(dayTimeController);
        string dayTimeSaveJSON = JsonUtility.ToJson(dayTimeSave);
        string filepath = Path.Combine(Application.persistentDataPath, saveFilename);
        using (StreamWriter sw = new StreamWriter(filepath))
        {
            sw.WriteLine(playerInfoJSON);
            sw.WriteLine(objectsInfoJSON);
            sw.WriteLine(dayTimeSaveJSON);
        }
        print("Game saved");
    }

    public void Load()
    {
        IEnumerable<PickableObjectType> objectsToSpawn = new PickableObjectType[]
        {
            PickableObjectType.Trousers,
            PickableObjectType.Boots,
            PickableObjectType.TShirt,
            PickableObjectType.Redkey,
            PickableObjectType.Jacket
        };
        switch (LoadFromFileInfo.loadFromFileState)
        {
            case loadingType.NewGame:
                dayTimeController.SetDefaultTime();
                objectSpawner.SpawnObjects(objectsToSpawn);
                break;
            case loadingType.FromFile:
                string playerInfoJSON;
                string objectsInfoJSON;
                string dayTimeSaveJSON;
                string filepath = Path.Combine(Application.persistentDataPath, saveFilename);
                using (StreamReader sr = new StreamReader(filepath))
                {
                    playerInfoJSON = sr.ReadLine();
                    objectsInfoJSON = sr.ReadLine();
                    dayTimeSaveJSON = sr.ReadLine();
                }
                PlayerSave playerSave = JsonUtility.FromJson<PlayerSave>(playerInfoJSON);
                RoomObjectSave[] roomObjectSaves = objectsInfoJSON.ConvertStringToArray<RoomObjectSave>();
                player.SetPlayerFromSave(playerSave);
                for (int i = 0; i < openableObjects.Length; i++)
                    openableObjects[i].SetObjectFromSave(roomObjectSaves[i]);
                DayTimeSave dayTimeSave = JsonUtility.FromJson<DayTimeSave>(dayTimeSaveJSON);
                dayTimeController.SetTimeFromSave(dayTimeSave);
                objectsToSpawn = objectsToSpawn.Except(playerSave.inventory);
                objectSpawner.SpawnObjects(objectsToSpawn);
                break;
        }
        print("Game loaded");
    }
}

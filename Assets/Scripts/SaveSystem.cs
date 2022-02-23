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

public class SaveSystem : MonoBehaviour
{
    [SerializeField] private string saveFilename = "save.txt";
    [SerializeField] private ObjectSpawner objectSpawner;
    [SerializeField] private PlayerRaycast player;
    [SerializeField] private Openable[] openableObjects;

    public void Save()
    {
        PlayerSave playerSave = new PlayerSave(player);
        string playerInfoJSON = JsonUtility.ToJson(playerSave);
        RoomObjectSave[] roomObjectSaves = new RoomObjectSave[openableObjects.Length];
        for (int i = 0; i < openableObjects.Length; i++)
            roomObjectSaves[i] = new RoomObjectSave(openableObjects[i]);
        string objectsInfoJSON = JsonUtility.ToJson(roomObjectSaves);
        string filepath = Path.Combine(Application.persistentDataPath, saveFilename);
        using (StreamWriter sw = new StreamWriter(filepath))
        {
            sw.WriteLine(playerInfoJSON);
            sw.WriteLine(objectsInfoJSON);
        }
    }

    public void Load()
    {
        string playerInfoJSON;
        string objectsInfoJSON;
        string filepath = Path.Combine(Application.persistentDataPath, saveFilename);
        using (StreamReader sr = new StreamReader(filepath))
        {
            playerInfoJSON = sr.ReadLine();
            objectsInfoJSON = sr.ReadLine();
        }
        PlayerSave playerSave = JsonUtility.FromJson<PlayerSave>(playerInfoJSON);
        RoomObjectSave[] roomObjectSaves = JsonUtility.FromJson<RoomObjectSave[]>(objectsInfoJSON);
        player.SetPlayerFromSave(playerSave);
        for (int i = 0; i < openableObjects.Length; i++)
            openableObjects[i].SetObjectFromSave(roomObjectSaves[i]);
        IEnumerable<PickableObjectType> objectsToSpawn = new PickableObjectType[]
        {
            PickableObjectType.Trousers,
            PickableObjectType.Boots,
            PickableObjectType.TShirt,
            PickableObjectType.Redkey,
            PickableObjectType.Jacket
        }.Except(playerSave.inventory);
        objectSpawner.SpawnObjects(objectsToSpawn);
    }
}

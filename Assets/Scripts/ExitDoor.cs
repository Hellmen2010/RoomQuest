using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitDoor : Openable, ILockable
{
    [SerializeField] private PlayerRaycast player;
    [SerializeField] private AudioStore audioStore;
    [SerializeField] private GameObject endGameCanvas;
    [SerializeField] private GameObject surprize;
    public bool IsLocked => exitDoorIsLocked;
    private bool exitDoorIsLocked;
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private List<PickableObjectType> requiredItems = new List<PickableObjectType> 
    {
        PickableObjectType.Boots,
        PickableObjectType.Trousers,
        PickableObjectType.TShirt,
        PickableObjectType.Jacket 
    };


    public override void OpenClose()
    {
        if (exitDoorIsLocked)
        {
            base.OpenClose();
            StartCoroutine(FinaleMoment());
        }
        else
        {
            if (HaveRequiredItems())
            {
                UnlockDoor();
                
                Debug.Log("You collected all clothes");
            }
            else
            {
                audioSource.PlayOneShot(audioStore.GetAudioClipByType(AudioType.DoorLocked));
                Debug.Log("Something missing");
            }
                
        }
    }

    private void UnlockDoor()
    {
        surprize.SetActive(true);
        exitDoorIsLocked = true;
        audioSource.PlayOneShot(audioStore.GetAudioClipByType(AudioType.DoorUnlocked));
    }
    public override void SetObjectFromSave(RoomObjectSave roomObjectSave)
    {
        base.SetObjectFromSave(roomObjectSave);
        exitDoorIsLocked = roomObjectSave.isLocked;
    }

    private IEnumerator FinaleMoment()
    {
        yield return new WaitForSeconds(1f);
        audioSource.PlayOneShot(audioStore.GetAudioClipByType(AudioType.ah_fuck));
        yield return new WaitForSeconds(2f);
        endGameCanvas.SetActive(true);
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("MainMenu");
    }
    public bool HaveRequiredItems() => requiredItems.TrueForAll(s => player.PlayerInventory.InventoryContent.Contains(s));
    
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Locker : Openable
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject mainCamera;
    [SerializeField] private GameObject lockerCamera;
    //[SerializeField] private TMP_InputField password;
    //[SerializeField] private AudioStore audioStore;
    private AudioSource audioSource;
    private bool lockerUnlocked;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyUp(KeyCode.E))
            LockerTryPasswordCamera();
        if (Input.GetKeyUp(KeyCode.Escape))
            LockerTryPasswordCameraExit();
    }
    public void LockerTryPasswordCamera()
    {
        if (Input.GetKeyUp(KeyCode.E))
        {
            //audioSource.PlayOneShot(audioStore.GetAudioClipByType(AudioType.Pc_on));
            mainCamera.SetActive(false);
            lockerCamera.SetActive(true);
            Cursor.lockState = CursorLockMode.Confined;
            player.GetComponent<FirstPersonController>().enabled = false;
        }
    }
    public void LockerTryPasswordCameraExit()
    {
        //audioSource.PlayOneShot(audioStore.GetAudioClipByType(AudioType.Pc_off));
        mainCamera.SetActive(true);
        lockerCamera.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        player.GetComponent<FirstPersonController>().enabled = true;
    }

    public override void OpenClose()
    {
        if (lockerUnlocked)
        {
            base.OpenClose();
        }
        else
        {
            Debug.Log("Door is locked");
        }
    }
}

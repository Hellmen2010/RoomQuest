using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Locker : Openable
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject lockerCamera;
    //[SerializeField] private TMP_InputField password;
    //[SerializeField] private AudioStore audioStore;
    private AudioSource audioSource;
    private bool lockerUnlocked;
    private string password;
    public string inputPassword;

    protected override void Awake()
    {
        base.Awake();
        audioSource = GetComponent<AudioSource>();
        inputPassword = "";
        password = "6384";
    }
    private void Update()
    {
        if (inputPassword.Length > 4)
            clearPasswordField();
        if(inputPassword == password)
        {
            UnlockingLocker();
            clearPasswordField();
        }
        Debug.Log(inputPassword);
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
            lockerCamera.SetActive(true);
            Cursor.lockState = CursorLockMode.Confined;
            player.GetComponent<FirstPersonController>().enabled = false;
        }
    }
    public void LockerTryPasswordCameraExit()
    {
        //audioSource.PlayOneShot(audioStore.GetAudioClipByType(AudioType.Pc_off));
        clearPasswordField();
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
    private void UnlockingLocker()
    {
        lockerUnlocked = true;
    }
    private void clearPasswordField()
    {
        inputPassword = string.Empty;
    }
}

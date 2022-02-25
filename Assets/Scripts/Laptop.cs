using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Audio;
using System.Linq;

[RequireComponent(typeof(AudioSource))]
public class Laptop : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject mainCamera;
    [SerializeField] private GameObject laptopCamera;
    [SerializeField] private TMP_InputField password;
    [SerializeField] private GameObject desktopPanel;
    [SerializeField] private GameObject errorPanel;
    [SerializeField] private AudioStore audioStore;
    [SerializeField] private DoorInBathroom doorInBathroom;
    private AudioSource audioSource;
    private string[] passwordToUnlock = new string[] {"50 cent", "50_cent", "50 Cent", "50cent", "50CENT" , "50 CENT", "50_CENT"};

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Check()
    {
        if (passwordToUnlock.Contains(password.text))
        {
            desktopPanel.SetActive(true);
            errorPanel.SetActive(false);
        }
        else
        {
            password.text = string.Empty;
            audioSource.PlayOneShot(audioStore.GetAudioClipByType(AudioType.error));
        }
    }
    

    private void OnTriggerStay(Collider other)
    {
        if(Input.GetKeyUp(KeyCode.Return))
            Check();
        if (Input.GetKeyUp(KeyCode.E))
            LaptopActivating();
        if (Input.GetKeyUp(KeyCode.Escape))
            LaptopDeactivating();
    }

    public void LaptopActivating()
    {
        if (Input.GetKeyUp(KeyCode.E))
        {
            audioSource.PlayOneShot(audioStore.GetAudioClipByType(AudioType.Pc_on));
            mainCamera.SetActive(false);
            laptopCamera.SetActive(true);
            Cursor.lockState = CursorLockMode.Confined;
            player.GetComponent<FirstPersonController>().enabled = false;
        }
    }
    public void LaptopDeactivating()
    {
        audioSource.PlayOneShot(audioStore.GetAudioClipByType(AudioType.Pc_off));
        mainCamera.SetActive(true);
        laptopCamera.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        player.GetComponent<FirstPersonController>().enabled = true;
    }
    public void OpenDoorInBathroom()
    {
        doorInBathroom.Unlocking();
    }
}

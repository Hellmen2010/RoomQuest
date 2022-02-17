using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Laptop : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject mainCamera;
    [SerializeField] private GameObject laptopCamera;
    [SerializeField] private TMP_InputField password;
    [SerializeField] private GameObject desktopPanel;
    [SerializeField] private GameObject errorPanel;

    private void Update()
    {
        if (password.text == "password")
        {
            //GameData.Instance.DoorBathRoomIsOpenable = true;
            desktopPanel.SetActive(true);
            errorPanel.SetActive(false);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyUp(KeyCode.E))
            LaptopActivating();
        if (Input.GetKeyUp(KeyCode.Escape))
            LaptopDeactivating();
    }

    public void LaptopActivating()
    {
        if (Input.GetKeyUp(KeyCode.E))
        {
            mainCamera.SetActive(false);
            laptopCamera.SetActive(true);
            Cursor.lockState = CursorLockMode.Confined;
            player.GetComponent<FirstPersonController>().enabled = false;
        }
    }
    public void LaptopDeactivating()
    {
        mainCamera.SetActive(true);
        laptopCamera.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        player.GetComponent<FirstPersonController>().enabled = true;
    }
}

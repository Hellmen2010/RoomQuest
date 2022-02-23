using Lean.Gui;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRaycast : MonoBehaviour
{
    [SerializeField] private Inventory inventory;
    [SerializeField] private GameObject questPanel;

    public void SetPlayerFromSave(PlayerSave playerSave)
    {
        transform.position = playerSave.position.ConvertToVector3();
        transform.eulerAngles = playerSave.rotation.ConvertToVector3();
        foreach (var item in playerSave.inventory)
            inventory.AddItem(item);
    }

    public Inventory PlayerInventory => inventory;
    private bool isPressed => (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Mouse0));
    private RaycastHit hit;

    private void Update()
    { 
        ShowInventory();
        ShowQuests();
        if (isPressed)
        {
            Ray ray = Cursor.lockState == CursorLockMode.Locked ? new Ray(Camera.main.transform.position, Camera.main.transform.forward) : Camera.main.ScreenPointToRay(Input.mousePosition);

            Debug.DrawLine(ray.origin, hit.point, Color.magenta, 1);

            Physics.Raycast(ray, out hit, 20f, LayerMask.GetMask("InteractRaycast"));

            if (hit.collider == null)
                return;
            if (hit.collider.gameObject.TryGetComponent<Openable>(out var openable))
            {
                openable.OpenClose();
            }
            if (hit.collider.gameObject.GetComponent<Chair>() != null)
            {
                hit.collider.gameObject.GetComponent<Chair>().Move();
            }
            if (hit.collider.gameObject.TryGetComponent<LeanToggle>(out var leanToggle))
            {
                leanToggle.Toggle();
            }
            if(hit.collider.gameObject.TryGetComponent<PickupItem>(out var pickupItem))
            {
                pickupItem.Pickup();
            }
            switch (hit.collider.gameObject.tag)
            {
                case "TV":
                    hit.collider.gameObject.GetComponent<TVController>().TVOnOff();
                    break;
            }

        }
               
    }

    void ShowInventory()
    {
        if (Input.GetKeyDown(KeyCode.I))
            inventory.gameObject.SetActive(!inventory.gameObject.activeInHierarchy);
    }
    void ShowQuests()
    {
        if(Input.GetKeyDown(KeyCode.Q))
            questPanel.active = !questPanel.active;
    }
}

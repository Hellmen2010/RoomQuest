using Lean.Gui;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRaycast : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject inventory;
    [SerializeField] private GameObject questPanel;
    private bool isPressed => (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Mouse0));
    private RaycastHit hit;
    private float skyboxExposure = 1f;

    private Camera _mainCamera;
    private Camera mainCamera => _mainCamera is null ? _mainCamera = Camera.main ?? throw new MissingComponentException() : _mainCamera;

    private void Awake()
    {
        inventory.GetComponent<Inventory>();
        StartCoroutine(DayNight());
    }

    private IEnumerator DayNight()
    {
        while(skyboxExposure > 0.12f)
        {
            skyboxExposure -= 0.001f;
            RenderSettings.skybox.SetFloat("_Exposure", skyboxExposure);
            yield return new WaitForSeconds(1); 
        }
    }
    private void Update()
    { 
        ShowInventory();
        ShowQuests();
        if (isPressed)
        {
            Ray ray = Cursor.lockState == CursorLockMode.Locked ? new Ray(transform.position,  transform.forward) : mainCamera.ScreenPointToRay(Input.mousePosition);

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
        if(Input.GetKeyDown(KeyCode.I))
            inventory.active = !inventory.active;
    }
    void ShowQuests()
    {
        if(Input.GetKeyDown(KeyCode.Q))
            questPanel.active = !questPanel.active;
    }
}

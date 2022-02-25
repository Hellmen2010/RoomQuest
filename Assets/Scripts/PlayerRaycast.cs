using UnityEngine;
using System.Linq;
using System.Collections;

public class PlayerRaycast : MonoBehaviour
{
    [SerializeField] private Inventory inventory;
    [SerializeField] private GameObject questPanel;
    private float rayLength = 2f;
    private int layerMask;
    public bool MenuAvaible { get; set; } = true;

    private void Awake()
    {
        layerMask = LayerMask.GetMask("InteractRaycast");
    }

    public void SetPlayerFromSave(PlayerSave playerSave)
    {
        transform.position = playerSave.position.ConvertToVector3();
        transform.eulerAngles = playerSave.rotation.ConvertToVector3();
        foreach (var item in playerSave.inventory)
            inventory.AddItem(item);
    }

    public Inventory PlayerInventory => inventory;
    private bool isPressed => (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Mouse0));

    private void Update()
    {
        ShowInventory();
        ShowQuests();
        if (isPressed)
        {
            Ray ray = Cursor.lockState == CursorLockMode.Locked ? new Ray(Camera.main.transform.position, Camera.main.transform.forward) : Camera.main.ScreenPointToRay(Input.mousePosition);
            var hits = Physics.RaycastAll(ray, rayLength, layerMask).Where(t => t.collider != null && t.collider.isTrigger == false);
            if (hits.Count() > 0)
            {
                var hit = hits.OrderBy(t => t.distance).First();
                Debug.DrawLine(ray.origin, hit.point, Color.magenta, 1);
                if (hit.collider.gameObject.TryGetComponent<Openable>(out var openable))
                {
                    openable.OpenClose();
                }
                if (hit.collider.gameObject.GetComponent<Chair>() != null)
                {
                    hit.collider.gameObject.GetComponent<Chair>().Move();
                }
                if (hit.collider.gameObject.TryGetComponent<PickupItem>(out var pickupItem))
                {
                    pickupItem.Pickup();
                }
                if (hit.collider.gameObject.TryGetComponent<TVController>(out var tv))
                {
                    tv.TVOnOff();
                }
                if (hit.collider.gameObject.TryGetComponent<NoteItem>(out var note))
                {
                    Note.Instance.ShowHide(note.NoteKey);
                }
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
        if (Input.GetKeyDown(KeyCode.Q))
            questPanel.gameObject.SetActive(!questPanel.gameObject.activeInHierarchy);
    }
}

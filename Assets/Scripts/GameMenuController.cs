using UnityEngine;

public class GameMenuController : MonoBehaviour
{
    [SerializeField] GameObject panelMenu;
    [SerializeField] PlayerRaycast playControl;
    private bool _isPaused = false;
    public bool IsPaused
    {
        get => _isPaused;
        set
        {
            _isPaused = value;
            Cursor.lockState = value ? CursorLockMode.None : CursorLockMode.Locked;
            Cursor.visible = value;
            panelMenu.SetActive(value);
            Time.timeScale = value ? 0 : 1;
            controller.enabled = !value;
        }
    }
    FirstPersonController controller;

    private void Awake()
    {
        controller = playControl.GetComponent<FirstPersonController>();
    }
    private void Start()
    {
        Time.timeScale = 1;
    }
    private void Update()
    {
        MenuControl();
    }
    public void MenuControl()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            IsPaused = !IsPaused;
        }
    }
}

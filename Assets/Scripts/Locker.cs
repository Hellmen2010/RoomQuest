using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Locker : Openable, ILockable
{
    [SerializeField] private FirstPersonController player;
    [SerializeField] private GameObject lockerCamera;
    [SerializeField] private AudioSource Sound_Unlock, Sound_Reset, Sound_Input;
    [SerializeField] private string password = "6384", inputPassword = string.Empty;
    private bool lockerUnlocked = false;
    PlayerRaycast playerRaycast;
    public UnityEvent onUnlock;

    private bool _isFocused = false;
    public bool isFocused
    {
        get => _isFocused;
        set 
        {
            lockerCamera.SetActive(value);
            player.GetComponent<FirstPersonController>().enabled = !value;
            Cursor.lockState = value ? CursorLockMode.None : CursorLockMode.Locked;
            PasswordInput_Clear();
            _isFocused = value;
        }
    }

    private void Start()
    {
        playerRaycast = player.GetComponent<PlayerRaycast>();
    }

    public bool IsLocked => lockerUnlocked;

    private void Update()
    {
        if (isFocused && Input.GetKeyUp(KeyCode.Escape))
        {
            isFocused = false;
            playerRaycast.MenuAvaible = true;
        }
    }

    public override void OpenClose()
    {
        if (lockerUnlocked)
        {
            isFocused = false;
            base.OpenClose();
        }
        else
        {
            playerRaycast.MenuAvaible = isFocused;
            isFocused = !isFocused;
        }
    }

    public void PasswordInput_Clear(bool playSound, AudioSource source)
    {
        inputPassword = string.Empty;
        if (playSound) source.Play();
    }
    public void PasswordInput_Clear(bool playSound = false) => PasswordInput_Clear(playSound, Sound_Reset);

    public void PlayerInput(Button input)
    {
        var inputNumber = input.GetComponentInChildren<TMP_Text>();
        if (inputNumber is null) throw new NullReferenceException();
        if (inputNumber.text.Length == 1) TryInput(inputNumber.text[0]);
    }

    private void TryInput(char symbol)
    {

        if (inputPassword + symbol == password) { 
            onUnlock.Invoke(); // add anim to inspector
            PasswordInput_Clear(true, Sound_Unlock);
            lockerUnlocked = true;
        }
        else if (inputPassword.Length + 1 == password.Length) {
            PasswordInput_Clear(true, Sound_Reset);
        } 
        else
        {
            inputPassword += symbol;
            Sound_Input.Play(); //при простом вводе
        }
    }

    public override void SetObjectFromSave(RoomObjectSave roomObjectSave)
    {
        base.SetObjectFromSave(roomObjectSave);
        lockerUnlocked = roomObjectSave.isLocked;
    }
}

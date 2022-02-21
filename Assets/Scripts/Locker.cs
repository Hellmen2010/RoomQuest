using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Locker : Openable
{
    [SerializeField] private FirstPersonController player;
    [SerializeField] private GameObject lockerCamera;
    [SerializeField] private AudioSource Sound_Unlock, Sound_Reset, Sound_Input;
    [SerializeField] private string password = "6384", inputPassword = string.Empty;
    private bool lockerUnlocked = false;
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

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyUp(KeyCode.E) && !lockerUnlocked) isFocused = !isFocused;
        if (Input.GetKeyUp(KeyCode.Escape)) isFocused = false;
    }

    public override void OpenClose()
    {
        if (lockerUnlocked) {
            isFocused = false;
            base.OpenClose();
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
}

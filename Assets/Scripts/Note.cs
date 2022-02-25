using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Note : MonoBehaviour
{
    [SerializeField] TMP_Text noteText;
    [SerializeField] LocalizationManager localizationManager;
    [SerializeField] FirstPersonController player;
    private bool isActive;

    public static Note Instance;
    //player.enabled = !player.enabled;
    private void Awake()
    {
        Instance = this;
        gameObject.SetActive(false);
        isActive = true;
    }


    public void ShowNote(string noteString)
    {
        noteText.text = localizationManager.GetLocalizedValue(noteString);
        gameObject.SetActive(true);
    }

    public void HideNote()
    {
        gameObject.SetActive(false);
    }
    public void ShowHide(string noteString)
    {
        noteText.text = localizationManager.GetLocalizedValue(noteString);
        gameObject.SetActive(isActive);
        isActive = !isActive;
        player.enabled = !player.enabled;
    }
}

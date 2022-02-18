using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ButtonOnLocker : MonoBehaviour
{
    [SerializeField] private Locker locker;
    private TMP_Text text;

    private void Awake()
    {
        locker.GetComponent<Locker>();
    }
    public void OnButtonPressed()
    {
        locker.inputPassword += GetComponentInChildren<TMP_Text>().text;
        Debug.Log(GetComponentInChildren<TMP_Text>().text);
    }
}

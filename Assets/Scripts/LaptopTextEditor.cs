using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LaptopTextEditor : MonoBehaviour
{
    [SerializeField] private GameObject textEditor;
    [SerializeField] private GameObject button;
    [SerializeField] private TMP_InputField newText;
    private float clickTime = 0.3f;
    private string textToSave;

    public void ShowTextFile()
    {
        if(clickTime > 0)
        {
            if ((Time.realtimeSinceStartup - clickTime) < 0.3f)
            {
                textEditor.SetActive(true);
                button.SetActive(false);
            }
            else
                clickTime = Time.realtimeSinceStartup;
        }
    }
    public void CloseTextFile()
    {
        textEditor.SetActive(false);
        button.SetActive(true);
    }

    public void SaveTextFile()
    {
        textToSave = newText.text;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clipboard : MonoBehaviour
{
    [SerializeField] GameObject note1;
    [SerializeField] private FirstPersonController player;

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Escape))
        {
            note1.active = !note1.active;
            player.enabled = !player.enabled;
        }
    }

}

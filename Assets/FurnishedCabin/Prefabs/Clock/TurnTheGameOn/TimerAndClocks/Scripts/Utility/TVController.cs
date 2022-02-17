using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TVController : MonoBehaviour
{
    [SerializeField] private GameObject screen;

    public void TVOnOff()
    {
        screen.active = !screen.active;
    }
}

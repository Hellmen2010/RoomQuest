using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteItem : MonoBehaviour
{
    [SerializeField] private string noteKey;

    public string NoteKey => noteKey;
}

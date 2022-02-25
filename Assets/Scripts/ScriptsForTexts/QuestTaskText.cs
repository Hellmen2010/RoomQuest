using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TMP_Text))]
public class QuestTaskText : MonoBehaviour
{
    [SerializeField] private PickableObjectType objectType;
    private TMP_Text text;

    private void OnEnable()
    {
        if (text == null)
            text = GetComponent<TMP_Text>();
    }

    public void ChangeText(PickableObjectType pickup)
    {
        if (pickup == objectType)
        {
            text.fontStyle = FontStyles.Strikethrough;
            GameManager.Instance.OnItemPickup -= ChangeText;
        }
    }
}

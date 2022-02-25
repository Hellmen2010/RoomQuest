using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestCanvas : MonoBehaviour
{
    [SerializeField] QuestTaskText[] questTaskTexts;

    private void Start()
    {
        foreach (var task in questTaskTexts)
            GameManager.Instance.OnItemPickup += task.ChangeText;
        gameObject.SetActive(false);
    }
}

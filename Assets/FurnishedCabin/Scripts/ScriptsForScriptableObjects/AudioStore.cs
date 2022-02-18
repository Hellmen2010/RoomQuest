using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

[CreateAssetMenu(menuName = "ScriptableObjects/AudioStore")]
public class AudioStore : ScriptableObject
{
    [SerializeField] private AudioField[] audioField;
    
    public AudioClip GetAudioClipByType(AudioType audioType)
    {
        return audioField.First(x => x.audioType == audioType).audioClip;
    }
}

public enum AudioType
{
    DoorLocked, Pc_on, Pc_off, Cat_meow, DoorUnlocked
}

[Serializable]
public class AudioField
{
    public AudioType audioType;
    public AudioClip audioClip;
}

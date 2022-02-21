using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInBathroom : Openable
{
    [SerializeField] GameObject closeIndicator;
    [SerializeField] GameObject openIndicator;
    [SerializeField] private AudioStore audioStore;
    private AudioSource audioSource;
    private bool doorInBathroomIsOpen;
    public bool DoorInBathroomIsOpen { get { return doorInBathroomIsOpen; } }
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public override void OpenClose()
    {
        if (doorInBathroomIsOpen)
        {
            base.OpenClose();
        }
        else
        {
            audioSource.PlayOneShot(audioStore.GetAudioClipByType(AudioType.DoorLocked));
        }
        
    }
    public void Unlocking()
    {
        doorInBathroomIsOpen = true;
        audioSource.PlayOneShot(audioStore.GetAudioClipByType(AudioType.ElectroDoor));
        closeIndicator.active = !closeIndicator.active;
        openIndicator.active = !openIndicator.active;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(AudioSource))]
public class Cat : MonoBehaviour
{
    private NavMeshAgent agent;
    [SerializeField] private Transform[] destinations;
    [SerializeField] private float minimalDistance = 0.5f;
    [SerializeField] private AudioStore audioStore;
    private AudioSource audioSource;
    private Vector3 currentDestination;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        audioSource = GetComponent<AudioSource>();
        SetCatDestination();
    }
    private void Update()
    {
        Move();
    }
    private void Move()
    {
        if (Vector3.Distance(agent.transform.position, currentDestination) <= minimalDistance)
        {
            SetCatDestination();
            audioSource.PlayOneShot(audioStore.GetAudioClipByType(AudioType.Cat_meow));
        }
    }

    private void SetCatDestination()
    {
        currentDestination = destinations[Random.Range(0, destinations.Length)].position;
        agent.SetDestination(currentDestination);
    }
}

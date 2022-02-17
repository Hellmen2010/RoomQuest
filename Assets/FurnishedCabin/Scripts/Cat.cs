using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Cat : MonoBehaviour
{
    private NavMeshAgent agent;
    [SerializeField] private Transform[] destinations;
    [SerializeField] private float minimalDistance = 0.5f;
    private Vector3 currentDestination;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        SetCatDestination();
    }
    private void Update()
    {
        Move();
    }
    private void Move()
    {
        if (Vector3.Distance(agent.transform.position, currentDestination) <= minimalDistance)
            SetCatDestination();
    }

    private void SetCatDestination()
    {
        currentDestination = destinations[Random.Range(0, destinations.Length)].position;
        agent.SetDestination(currentDestination);
    }
}

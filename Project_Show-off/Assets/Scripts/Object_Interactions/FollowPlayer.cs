using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowPlayer : MonoBehaviour
{
    private NavMeshAgent agent;
    [SerializeField] private float followDistance = 4;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if ((GameObject.FindGameObjectWithTag("Player").transform.position - transform.position).magnitude < followDistance)
        {
            agent.destination = GameObject.FindGameObjectWithTag("Player").transform.position;
        }
        else agent.destination = transform.position;
    }
}

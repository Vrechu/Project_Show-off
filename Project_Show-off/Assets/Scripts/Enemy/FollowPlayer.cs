using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowPlayer : MonoBehaviour
{
    private NavMeshAgent agent;
    [SerializeField] private float followDistance = 4;

    private GameObject player;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if ((player.transform.position - transform.position).magnitude < followDistance)
        {
            agent.destination = player.transform.position;
        }
        else agent.destination = transform.position;
    }
}

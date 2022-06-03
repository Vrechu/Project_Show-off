using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBackFollow : MonoBehaviour
{
    private GameObject[] players;
    private Vector3 offset;

    void Start()
    {
        GetPlayers();
        PlacePlayers.OnPlayerSpawn += GetPlayers;
    }

    private void OnDestroy()
    {
        PlacePlayers.OnPlayerSpawn -= GetPlayers;
    }

    private void GetPlayers()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        offset = new Vector3(transform.position.x, transform.position.y, transform.position.z - ClosestPlayer());
    }

    void Update()
    {
        transform.position = new Vector3( offset.x, offset.y, ClosestPlayer() + offset.z);
    }

    private float ClosestPlayer()
    {
        float closest = 100;
        if (players.Length > 0)
        {
            for (int i = 0; i < players.Length; i++)
            {
                if (players[i].transform.position.z < closest)
                {
                    closest = players[i].transform.position.z;
                }
            }
            return closest;
        }
        else return transform.position.z;
    }
}

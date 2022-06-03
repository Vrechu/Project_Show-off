using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAverageFollow : MonoBehaviour
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
        offset = transform.position - PlayerAverage();
    }

    void Update()
    {
        transform.position = PlayerAverage() + offset;
    }

    private Vector3 PlayerAverage()
    {
        if (players.Length > 0)
        {
            Vector3 average = Vector3.zero;
            for (int i = 0; i < players.Length; i++)
            {
                average += players[i].transform.position;
            }
            return average / players.Length;
        }
        else return new Vector3(0, 0, 0);
    }
}

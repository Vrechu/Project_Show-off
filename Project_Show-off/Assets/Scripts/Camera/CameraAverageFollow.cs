using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAverageFollow : MonoBehaviour
{
    private GameObject[] players;
    private Vector3 offset;

    void Start()
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
        Vector3 average = new Vector3(0, 0, 0);
        for (int i = 0; i < players.Length; i++)
        {
            average += players[i].transform.position;
        }
        return average / players.Length;
    }
}

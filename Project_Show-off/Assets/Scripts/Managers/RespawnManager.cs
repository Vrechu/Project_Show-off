using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnManager : MonoBehaviour
{
    public static RespawnManager Instance { get; set; }

    [SerializeField] private Transform[] respawnPoints;
    private Queue<Transform> respawnPointQueue = new Queue<Transform>();

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else
        {
            Debug.LogError("Too many respawn managers!");
            Destroy(this);
        }        
    }


    void Start()
    {
        if (respawnPoints.Length > 0)
        {
            for (int i = 0; i < respawnPoints.Length; i++)
            {
                respawnPointQueue.Enqueue(respawnPoints[i]);
            }
        }
        else Debug.LogError("no respawn points!");
    }

    public Transform CurrentRespawnPoint()
    {
        return respawnPointQueue.Peek();
    }

    public void NextRespawnPoint()
    {
        if (respawnPointQueue.Count > 1)
        {
            respawnPointQueue.Dequeue();
        }
    }
}

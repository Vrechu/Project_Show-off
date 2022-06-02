using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueueRespawnManager : RespawnManager
{
    public static QueueRespawnManager Instance { get; set; }
    [SerializeField] private Transform[] respawnPoints;
    private Queue<Transform> respawnPointQueue = new Queue<Transform>();

    protected override void Start()
    {
        base.Start();

        if (Instance == null) Instance = this;
        else { Debug.LogError("Only one queue respawn per scene!"); }

        if (respawnPoints.Length > 0)
        {
            for (int i = 0; i < respawnPoints.Length; i++)
            {
                respawnPointQueue.Enqueue(respawnPoints[i]);
            }
        }
        else Debug.LogError("no respawn points!");
    }

    public override Transform MySpawnPoint(int playerNumber)
    {
        Transform spawn = transform; 
        switch (playerNumber)
        {
            case 0:
                spawn.position = respawnPointQueue.Peek().position + new Vector3(-1.5f, 0, 0);
                break;
            case 1:
                spawn.position = respawnPointQueue.Peek().position + new Vector3(-0.5f, 0, 0);
                break;
            case 2:
                spawn.position = respawnPointQueue.Peek().position + new Vector3(0.5f, 0, 0); 
                break;
            case 3:
                spawn.position = respawnPointQueue.Peek().position + new Vector3(1.5f, 0, 0);
                break;
        }
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

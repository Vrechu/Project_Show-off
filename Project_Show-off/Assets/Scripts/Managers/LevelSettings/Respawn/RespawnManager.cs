using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RespawnManager : MonoBehaviour
{
    public Transform[] spawns = new Transform[4];

    protected virtual void Start()
    {
        GetComponent<LevelSettings>().RespawnManager = this;
    }
    public abstract Transform MySpawnPoint(int playerNumber);
}

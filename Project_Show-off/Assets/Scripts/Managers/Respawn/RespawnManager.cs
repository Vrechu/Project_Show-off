using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RespawnManager : MonoBehaviour
{
    protected virtual void Start()
    {
        GetComponent<LevelSettings>().RespawnManager = this;
    }
    public abstract Transform MySpawnPoint(int playerNumber);
}

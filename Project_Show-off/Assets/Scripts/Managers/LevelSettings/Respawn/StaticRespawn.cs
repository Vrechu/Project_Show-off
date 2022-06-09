using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticRespawn : RespawnManager
{
    public override Transform MySpawnPoint(int playerNumber)
    {
        return spawns[playerNumber];
    }
}

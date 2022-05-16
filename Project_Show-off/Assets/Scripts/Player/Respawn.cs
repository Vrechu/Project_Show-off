using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] private Transform respawnPoint;

   public void MoveToRespawn()
    {
        transform.position = respawnPoint.position;
    }
}

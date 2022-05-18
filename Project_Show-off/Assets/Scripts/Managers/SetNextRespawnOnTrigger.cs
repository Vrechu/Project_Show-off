using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetNextRespawnOnTrigger : MonoBehaviour
{
    private RespawnManager respawnManager;

    private void Start()
    {
        respawnManager = RespawnManager.Instance;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Respawn" && !other.attachedRigidbody.isKinematic)
        {
            respawnManager.NextRespawnPoint();
        }
    }
}

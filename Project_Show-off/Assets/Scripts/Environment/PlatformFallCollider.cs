using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformFallCollider : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<FallingTile>() != null && other.attachedRigidbody.isKinematic)
        {
            other.GetComponent<FallingTile>().FallDown();
        }
    }
}

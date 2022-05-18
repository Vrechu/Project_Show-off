using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformFallCollider : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("2");
        if (other.GetComponent<FallingTile>() != null)
        {
            Debug.Log("1");
            other.GetComponent<FallingTile>().FallDown();
        }
    }
}

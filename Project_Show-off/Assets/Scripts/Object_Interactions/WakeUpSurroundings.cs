using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WakeUpSurroundings : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PhysicsHandler>() != null)
        {
            other.GetComponent<PhysicsHandler>().WakUpRB();
        }
    }
}

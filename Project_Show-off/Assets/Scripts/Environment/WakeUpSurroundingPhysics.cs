using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WakeUpSurroundingPhysics : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PhysicsSleepHandler>() != null)
        {
            other.GetComponent<PhysicsSleepHandler>().WakUpRB();
        }
    }
}

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
        if (other.tag == "Grabbable")
        {
            other.GetComponent<PhysicsHandler>().WakUpRB();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour
{
    [SerializeField] private float windStrength = 10;

    [SerializeField] private bool isTurnedOn = true;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player"
            && isTurnedOn)
        {
            other.attachedRigidbody.AddForce(transform.forward * windStrength * Time.deltaTime, ForceMode.Force);
        }
    }

    public void TurnOn()
    {
        isTurnedOn = true;
    }

    public void TurnOff()
    {
        isTurnedOn = false;
    }
}

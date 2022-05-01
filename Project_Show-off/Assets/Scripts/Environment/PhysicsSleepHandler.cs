using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsSleepHandler : MonoBehaviour
{
    [SerializeField] private float RBShutDownTime = 3;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (RBShutDownTime >= 0)
        {
            RBShutDownTime -= Time.deltaTime;
        }
        else rb.isKinematic = true;
    }

    public void WakUpRB()
    {
        rb.isKinematic = false;
        RBShutDownTime = 2;
    }
}

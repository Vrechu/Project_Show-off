using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingTile : MonoBehaviour
{
    private Rigidbody rigidbody;
    [SerializeField] private float fallDownTime = 10;
    [SerializeField] private float fallDownTimer = 0;
    private bool hasFallen = false;
    [SerializeField] private bool IsOnTimer = false;


    void Start()
    {
        if (GetComponent<Rigidbody>()!= null)
        {
        rigidbody = GetComponent<Rigidbody>();
        }
        else rigidbody = GetComponentInParent<Rigidbody>();

        fallDownTimer = fallDownTime;
    }

    void Update()
    {
        FallDownCountdown();
    }

    private void FallDownCountdown()
    {
        if (!hasFallen && IsOnTimer)
        {
            if (fallDownTimer >= 0)
            {
                fallDownTimer -= Time.deltaTime;
            }
            else
            {
                FallDown();
            }
        }
    }

    public void FallDown()
    {
        rigidbody.isKinematic = false;
        hasFallen = true;
    }
}

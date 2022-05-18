using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingTile : MonoBehaviour
{
    private Rigidbody tileRigidbody;
    [SerializeField] private float fallDownTime = 10;
    [SerializeField] private float fallDownTimer = 0;
    private bool hasFallen = false;
    [SerializeField] private bool IsOnTimer = false;


    void Start()
    {
        if (GetComponent<Rigidbody>()!= null)
        {
        tileRigidbody = GetComponent<Rigidbody>();
        }
        else tileRigidbody = GetComponentInParent<Rigidbody>();

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
        tileRigidbody.isKinematic = false;
        hasFallen = true;
    }
}

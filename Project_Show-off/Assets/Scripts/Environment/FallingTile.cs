using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingTile : MonoBehaviour
{
    private Rigidbody rigidbody;
    [SerializeField] private float fallDownTime = 10;
    [SerializeField] private float fallDownTimer = 0;
    private bool hasFallen = false;


    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        fallDownTimer = fallDownTime;
    }

    void Update()
    {
        FallDownCountdown();
    }

    private void FallDownCountdown()
    {
        if (!hasFallen)
        {
            if (fallDownTimer >= 0)
            {
                fallDownTimer -= Time.deltaTime;
            }
            else
            {
                rigidbody.isKinematic = false;
                hasFallen = true;
            }
        }
    }
}

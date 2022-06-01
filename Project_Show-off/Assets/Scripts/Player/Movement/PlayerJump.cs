using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    private Rigidbody objectRigidbody;

    [SerializeField] private float jumpTime = 1;
    [SerializeField] private float jumpTimer = 0;

    private PlayerInputs playerInputs;

    [SerializeField] private float jumpSpeed = 100;


    void Start()
    {
        objectRigidbody = GetComponent<Rigidbody>();
        playerInputs = GetComponent<PlayerProfileAccess>().PlayerProfile.PlayerInputs;
    }

    void Update()
    {
        Jump();
        JumpCounter();
    }


    private void Jump()
    {
        if (GetComponent<CheckIfGrounded>().IsGrounded()
            && jumpTimer < 0 
            && playerInputs.Jump() == 1)
        {
            objectRigidbody.AddForce(transform.up * jumpSpeed,ForceMode.Acceleration);
            jumpTimer = jumpTime;
        }
    }

    private void JumpCounter()
    {
        if (jumpTimer >= 0)
        {
            jumpTimer -= Time.deltaTime;
        }
    }
}
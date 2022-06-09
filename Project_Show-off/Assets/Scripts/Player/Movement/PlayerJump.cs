using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    private Rigidbody objectRigidbody;

    [SerializeField] private float jumpTime = 1;
    [SerializeField] private float jumpTimer = 0;

    private PlayerInputs playerInputs;
    private CheckIfGrounded checkIfGrounded;

    [SerializeField] private float jumpSpeed = 100;


    void Start()
    {
        objectRigidbody = GetComponent<Rigidbody>();
        checkIfGrounded = GetComponent<CheckIfGrounded>();
        playerInputs = GetComponent<PlayerProfileAccess>().PlayerProfile.PlayerInputs;
    }

    void Update()
    {
        Jump();
        JumpCounter();
    }


    private void Jump()
    {
        if (checkIfGrounded.IsGrounded()
            && jumpTimer < 0 
            && playerInputs.JumpPressed())
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
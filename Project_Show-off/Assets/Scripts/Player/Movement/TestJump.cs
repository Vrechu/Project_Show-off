using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestJump : MonoBehaviour
{
    private Rigidbody objectRigidbody;

    [SerializeField] private float jumpTime = 1;
    [SerializeField] private float jumpTimer = 0;

    private enum PlayerNumber
    {
        Player1, Player2
    }

    [SerializeField] private PlayerNumber playerNumber = PlayerNumber.Player1;

    [SerializeField] private float jumpSpeed = 100;

    private float jumpInput;

    void Start()
    {
        objectRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        SetImput();
        Jump();
        JumpCounter();
    }

    /// <summary>
    /// Assigns the input axis value to the jump value
    /// </summary>
    private void SetImput()
    {
        switch (playerNumber)
        {
            case PlayerNumber.Player1:
                jumpInput = Input.GetAxis("Fire1");
                break;

            case PlayerNumber.Player2:
                jumpInput = Input.GetAxis("Fire2");
                break;
        }
    }

    private void Jump()
    {
        if (GetComponent<CheckIfGrounded>().IsGrounded()
            && jumpTimer < 0 
            && jumpInput == 1)
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
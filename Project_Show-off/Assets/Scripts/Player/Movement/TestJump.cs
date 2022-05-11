using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestJump : MonoBehaviour
{
    private Rigidbody objectRigidbody;

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
        if (GetComponent<CheckIfGrounded>().IsGrounded())
        {
            objectRigidbody.AddForce(transform.up * jumpInput * jumpSpeed);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestJump : MonoBehaviour
{
    private Rigidbody objectRigidbody;

    [SerializeField] private float jumpSpeed = 10000;

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
        jumpInput = Input.GetAxis("Jump");
    }

    private void Jump()
    {
        if (GetComponent<CheckIfGrounded>().IsGrounded())
        {
            objectRigidbody.AddForce(transform.up * jumpInput * jumpSpeed);
        }
    }
}
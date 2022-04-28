using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpCharacter : MonoBehaviour
{
    private Rigidbody objectRigidbody;

    [SerializeField] private float jumpSpeed = 10000;

    private float jumpInput;
    [SerializeField] private float jumpCooldownTime = 0.05f;
    [SerializeField] private float jumpTimer = 0;
    private bool canJump = false;

    void Start()
    {
        objectRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        SetImput();
        CooldownJumpTimer();
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
        if (GetComponent<CheckIfGrounded>().IsGrounded()
            && canJump)
        {
            objectRigidbody.AddForce(transform.up * jumpInput * jumpSpeed * Time.deltaTime);
            canJump = false;
            jumpTimer = jumpCooldownTime;
        }
    }

    private void CooldownJumpTimer()
    {
        if (jumpTimer >= 0)
        {
            jumpTimer -= Time.deltaTime;
            canJump = true;
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class JumpCharacter : MonoBehaviour
{
    private Rigidbody objectRigidbody;

    [SerializeField] private float jumpSpeed = 10000;

    private float jumpInput;
    [SerializeField] private float jumpCooldownTime = 0.05f;
    [SerializeField] private float jumpTimer = 0;

    private void Start()
    {
        objectRigidbody = GetComponent<Rigidbody>();
    }

    private void OnDestroy()
    {
    }

    void Update()
    {
        SetImput();
        CooldownJumpTimer();
        //Jump();
    }

    /// <summary>
    /// Assigns the input axis value to the jump value
    /// </summary>
    private void SetImput()
    {
        jumpInput = Input.GetAxis("Jump");
    }

    public void Jump()
    {
        if (GetComponent<CheckIfGrounded>().IsGrounded()
            && jumpTimer < 0)
        {
            objectRigidbody.AddForce(transform.up * jumpInput * jumpSpeed);
            jumpTimer = jumpCooldownTime;
        }
    }

    private void CooldownJumpTimer()
    {
        if (jumpTimer >= 0)
        {
            jumpTimer -= Time.deltaTime;
        }
    }

    public void InputContextJump(InputAction.CallbackContext context)
    {
        if (context.started
            && GetComponent<CheckIfGrounded>().IsGrounded()
            && jumpTimer < 0)
        {
            Debug.Log("jump");
            objectRigidbody.AddForce(transform.up * jumpSpeed, ForceMode.Impulse);
            jumpTimer = jumpCooldownTime;
        }
    }
}
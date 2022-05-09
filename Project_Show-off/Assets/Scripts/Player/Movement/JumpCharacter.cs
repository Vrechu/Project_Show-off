using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class JumpCharacter : MonoBehaviour
{
    private Rigidbody objectRigidbody;
    private PlayerInput playerInput;

    [SerializeField] private float jumpSpeed = 10000;

    private float jumpInput;
    [SerializeField] private float jumpCooldownTime = 0.05f;
    [SerializeField] private float jumpTimer = 0;

    private void Start()
    {
        objectRigidbody = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();
        playerInput.onActionTriggered += InputContextJump;
    }

    private void OnDestroy()
    {
        playerInput.onActionTriggered -= InputContextJump;
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

    private void Jump()
    {
        if (GetComponent<CheckIfGrounded>().IsGrounded()
            && jumpTimer < 0)
        {
            objectRigidbody.AddForce(transform.up * jumpInput * jumpSpeed * Time.deltaTime);
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

    private void InputContextJump(InputAction.CallbackContext context)
    {
        if (context.started 
            && GetComponent<CheckIfGrounded>().IsGrounded()
            && jumpTimer < 0)
        {
            Debug.Log("jump");
            objectRigidbody.AddForce(transform.up * jumpSpeed * Time.deltaTime, ForceMode.Impulse);
            jumpTimer = jumpCooldownTime;
        }
    }
}
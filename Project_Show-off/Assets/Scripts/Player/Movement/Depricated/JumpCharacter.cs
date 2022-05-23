using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class JumpCharacter : MonoBehaviour
{
    private PlayerInputScript player1KeyboardInputs;
    private Rigidbody objectRigidbody;

    [SerializeField] private float jumpSpeed = 100;
    [SerializeField] private float jumpCooldownTime = 0.05f;
    [SerializeField] private float jumpTimer = 0;

    private void Start()
    {
        objectRigidbody = GetComponent<Rigidbody>();
        player1KeyboardInputs = new PlayerInputScript();
        player1KeyboardInputs.Ingame.Jump.Enable();
        player1KeyboardInputs.Ingame.Jump.started += Jump;
    }

    private void OnDestroy()
    {
        player1KeyboardInputs.Ingame.Jump.started -= Jump;
    }

    void Update()
    {
        CooldownJumpTimer();
    }

    private void CooldownJumpTimer()
    {
        if (jumpTimer >= 0)
        {
            jumpTimer -= Time.deltaTime;
        }
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.started
            && GetComponent<CheckIfGrounded>().IsGrounded()
            && jumpTimer < 0)
        {
            objectRigidbody.AddForce(transform.up * jumpSpeed, ForceMode.Impulse);
            jumpTimer = jumpCooldownTime;
        }
    }
}
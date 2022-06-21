using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetAnimation : MonoBehaviour
{
    private Animator animator;
    private PlayerInputs inputs;
    private CheckIfGrounded grounded;
    
    private void Start()
    {
        animator = GetComponent<Animator>();
        inputs = GetComponentInParent<PlayerProfileAccess>().PlayerProfile.PlayerInputs;
        grounded = GetComponentInParent<CheckIfGrounded>();
    }

    private void Update()
    {
        animator.SetFloat("Walk", inputs.Direction().magnitude);

        animator.SetFloat("Grab", inputs.Grab());
        animator.SetFloat("Jump", inputs.Jump());
        animator.SetBool("Grounded", grounded.IsGrounded());
    }
}

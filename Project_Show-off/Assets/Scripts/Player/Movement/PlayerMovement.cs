using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody playerRigidbody;

    [SerializeField] private float topSpeed = 5;
    [SerializeField] private float groundedAcceleration = 2000;
    [SerializeField] private float inAirAcceleration = 1000;
    [SerializeField] private float currentSpeed = 0;
    [SerializeField] private float groundedDrag = 0.02f;
    [SerializeField] private float inAirDrag = 0.05f;
    [SerializeField] private Transform cameraTransform;

    private enum PlayerNumber
    {
        Player1, Player2
    }


    private PlayerInputScript playerInputScript;
    private PlayerInput playerInput;

    private void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        playerInputScript = new PlayerInputScript();
        playerInputScript.Ingame.Walk.Enable();
    }

    void Update()
    {
        Accelerate();
    }

    private void Accelerate()
    {
        if (!OverTopSpeed())
        {
            playerRigidbody.AddForce(new Vector3(direction().x, 0, direction().y) * Acceleration(), ForceMode.Acceleration);
        }
        playerRigidbody.AddForce(Drag(), ForceMode.Acceleration);
    }

    private bool OverTopSpeed()
    {
        currentSpeed = new Vector2(playerRigidbody.velocity.x, playerRigidbody.velocity.z).magnitude;
        if (currentSpeed <= topSpeed) return false;
        else return true;
    }

    private float Acceleration()
    {
        if (GetComponent<CheckIfGrounded>().IsGrounded())
        {
            return groundedAcceleration * Time.deltaTime;
        }
        else return inAirAcceleration * Time.deltaTime;
    }

    private Vector3 Drag()
    {
        if (GetComponent<CheckIfGrounded>().IsGrounded())
        {
            return playerRigidbody.velocity * groundedDrag * -1 * Time.deltaTime;
        }
        else return playerRigidbody.velocity * inAirDrag * -1 * Time.deltaTime;
    }

    public Vector2 direction()
    {
        if (cameraTransform != null)
        {
            Vector3 cameraVector = (cameraTransform.right * playerInputScript.Ingame.Walk.ReadValue<Vector2>().x
            + cameraTransform.forward * playerInputScript.Ingame.Walk.ReadValue<Vector2>().y).normalized;
            return new Vector2(cameraVector.x, cameraVector.z);
        }
        else return playerInputScript.Ingame.Walk.ReadValue<Vector2>().normalized;
    }
}

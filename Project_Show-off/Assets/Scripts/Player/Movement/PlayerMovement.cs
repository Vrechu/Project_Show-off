using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    [SerializeField] private PlayerNumber playerNumber = PlayerNumber.Player1;

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
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
        Debug.Log(GetComponent<CheckIfGrounded>().IsGrounded());
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
            return playerRigidbody.velocity * groundedDrag  * -1 * Time.deltaTime;
        }
        else return playerRigidbody.velocity * inAirDrag  * -1 * Time.deltaTime;
    }

    Vector2 direction()
    {
        float up = 0;
        float down = 0;
        float left = 0;
        float right = 0;

        switch (playerNumber)
        {
            case PlayerNumber.Player1:
                if (Input.GetKey(KeyCode.W))
                {
                    up = 1;
                }
                if (Input.GetKey(KeyCode.S))
                {
                    down = -1;
                }
                if (Input.GetKey(KeyCode.A))
                {
                    left = -1;
                }
                if (Input.GetKey(KeyCode.D))
                {
                    right = 1;
                }
                break;

            case PlayerNumber.Player2:
                if (Input.GetKey(KeyCode.UpArrow))
                {
                    up = 1;
                }
                if (Input.GetKey(KeyCode.DownArrow))
                {
                    down = -1;
                }
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    left = -1;
                }
                if (Input.GetKey(KeyCode.RightArrow))
                {
                    right = 1;
                }
                break;
        }

        if (cameraTransform != null)
        {
            Vector3 cameraVector = (cameraTransform.right * (left + right) + cameraTransform.forward * (up + down)).normalized;
            return new Vector2(cameraVector.x, cameraVector.z);
        }
        else return new Vector2(left + right, up + down).normalized;
    }
}

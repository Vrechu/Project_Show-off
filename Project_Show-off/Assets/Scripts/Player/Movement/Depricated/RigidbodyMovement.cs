using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyMovement : MonoBehaviour
{
    private Rigidbody objectRigidbody;

    [SerializeField] private float moveSpeed = 500;
    [SerializeField] private float inAirMoveSpeed = 250;
    [SerializeField] private float turnSpeed = 100;
    private float forwardInput;
    private float sidewaysInput;
    private enum PlayerNumber
    {
        Player1, Player2
    }

    [SerializeField] private PlayerNumber playerNumber = PlayerNumber.Player1;

    void Start()
    {
        objectRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //SetKeys();
        Move();
    }

    /// <summary>
    /// Assigns the input axis values to the forward and sideways values
    /// </summary>
    private void SetKeys()
    {

        forwardInput = Input.GetAxis("Vertical");
        sidewaysInput = Input.GetAxis("Horizontal");



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
        return new Vector2(left + right, up + down).normalized;
    }

    /// <summary>
    ///
    /// </summary>
    /// <returns>the object velocity vector based on the imputs and movement speed</returns>
    private Vector3 Velocity()
    {
        if (GetComponent<CheckIfGrounded>().IsGrounded())
        {
            return transform.forward * direction().y * moveSpeed * Time.deltaTime;
        }
        else return transform.forward * direction().y * inAirMoveSpeed * Time.deltaTime;
    }

    /// <summary>
    /// Moves the object through the object rigidbody
    /// </summary>
    private void Move()
    {
        objectRigidbody.AddForce(Velocity());
        transform.Rotate(transform.up, direction().x * turnSpeed * Time.deltaTime);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyMovement: MonoBehaviour
{
    private Rigidbody objectRigidbody;

    [SerializeField] private float moveSpeed = 500;
    [SerializeField] private float inAirMoveSpeed = 250;
    [SerializeField] private float turnSpeed = 100;
    private float forwardInput;
    private float sidewaysInput;

    void Start()
    {
        objectRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        SetKeys();
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

    /// <summary>
    ///
    /// </summary>
    /// <returns>the object velocity vector based on the imputs and movement speed</returns>
    private Vector3 Velocity()
    {
        if (GetComponent<CheckIfGrounded>().IsGrounded())
        {
            return transform.forward * forwardInput * moveSpeed * Time.deltaTime;
        }
        else return transform.forward * forwardInput * inAirMoveSpeed * Time.deltaTime;
    }

    /// <summary>
    /// Moves the object through the object rigidbody
    /// </summary>
    private void Move()
    {
        objectRigidbody.AddForce(Velocity());
        transform.Rotate(transform.up, sidewaysInput * turnSpeed * Time.deltaTime);
    }
}
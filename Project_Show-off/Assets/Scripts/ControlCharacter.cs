using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCharacter : MonoBehaviour
{
    private Rigidbody objectRigidbody;

    [SerializeField] private float moveSpeed = 500;
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
    private Vector3 velocity()
    {
        return new Vector3(sidewaysInput, 0, forwardInput) * moveSpeed * Time.deltaTime;
    }

    /// <summary>
    /// Moves the object through the object rigidbody
    /// </summary>
    private void Move()
    {
        if (GetComponent<CheckIfGrounded>().IsGrounded())
        {
            objectRigidbody.AddForce(velocity());
        }
    }
}
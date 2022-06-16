using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrab : MonoBehaviour
{
    private PlayerInputs playerInputs;
    private Transform grabbingObject;
    public bool IsGrabbing = false;
    [SerializeField] private bool canGrab = true;
    [SerializeField] private float grabTime = 1;
    [SerializeField] private float grabTimer = 0;
    [SerializeField] private float pushForce = 200;
    

    private void Start()
    {
        playerInputs = GetComponentInParent<PlayerProfileAccess>().PlayerProfile.PlayerInputs;
    }

    private void Update()
    {
        GrabCountDown();
        if (playerInputs.Grab() == 0) canGrab = true;
    }

    private void GrabCountDown()
    {
        if (IsGrabbing)
        {
            if (grabTimer > 0)
            {
                grabTimer -= Time.deltaTime;
            }
            else LetLoose();
        }
        else grabTimer = grabTime;
    }

    private void OnTriggerStay(Collider other)
    {
        if (playerInputs.Grab() == 1)
        {
            switch (other.tag)
            {
                case "Grabbable":
                    if (canGrab && grabbingObject == null)
                    {
                        Grab(other);
                    }

                    break;

                case "Player":
                    if (canGrab && grabbingObject == null)
                    {
                        Grab(other);
                    }
                    break;

                case "ScoringObject":
                    if (canGrab && grabbingObject == null)
                    {
                        Grab(other);
                    }
                    break;
            }
        }
        else if (grabbingObject != null)
        {
            LetLoose();
        }
    }

    private void Grab(Collider other)
    {
        grabbingObject = other.transform;
        grabbingObject.gameObject.AddComponent<FixedJoint>();
        grabbingObject.GetComponent<FixedJoint>().connectedBody = GetComponentInParent<Rigidbody>();
        IsGrabbing = true;
        canGrab = false;
        grabTimer = grabTime;
    }

    private void LetLoose()
    {
        if (grabbingObject != null)
        {
            Destroy(grabbingObject.GetComponent<FixedJoint>());
            grabbingObject.GetComponent<Rigidbody>().AddForce(transform.forward * pushForce, ForceMode.Impulse);
            grabbingObject = null;
        } 
        IsGrabbing = false;
        grabTimer = grabTime;
    }
}

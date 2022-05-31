using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrab : MonoBehaviour
{
    private PlayerInputs playerInputs;
    private Transform grabbingObject;
    public bool IsGrabbing = false;

    private void Start()
    {
        playerInputs = GetComponentInParent<PlayerProfileAccess>().PlayerProfile.PlayerInputs;
    }

    private void OnTriggerStay(Collider other)
    {
        if (playerInputs.Grab() == 1)
        {
            switch (other.tag)
            {
                case "Grabbable":
                    if (grabbingObject == null)
                    {
                        grabbingObject = other.transform;
                        grabbingObject.gameObject.AddComponent<FixedJoint>();
                        grabbingObject.GetComponent<FixedJoint>().connectedBody = GetComponentInParent<Rigidbody>();
                        IsGrabbing = true;
                    }

                    break;

                case "Player":
                    if (grabbingObject == null)
                    {
                        grabbingObject = other.transform;
                        grabbingObject.gameObject.AddComponent<FixedJoint>();
                        grabbingObject.GetComponent<FixedJoint>().connectedBody = GetComponentInParent<Rigidbody>();
                        IsGrabbing = true;
                    }
                    break;
            }

        }
        else if (grabbingObject != null)
        {
            Destroy(grabbingObject.GetComponent<FixedJoint>());
            grabbingObject = null;
            IsGrabbing = false;
        }
    }
}

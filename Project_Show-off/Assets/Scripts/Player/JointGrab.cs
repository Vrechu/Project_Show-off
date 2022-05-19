using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JointGrab : MonoBehaviour
{
    private enum PlayerNumber
    {
        Player1, Player2
    }

    [SerializeField] private PlayerNumber playerNumber = PlayerNumber.Player1;

    private Transform grabbingObject;
    public bool IsGrabbing = false;

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKey(KeyCode.LeftShift) && playerNumber == PlayerNumber.Player1
            || Input.GetKey(KeyCode.RightShift) && playerNumber == PlayerNumber.Player2)
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

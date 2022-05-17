using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JointGrab : MonoBehaviour
{
    private Transform grabbingObject;


    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            switch (other.tag)
            {
                case "Grabbable":
                    if (grabbingObject == null)
                    {
                        grabbingObject = other.transform;
                        grabbingObject.gameObject.AddComponent<FixedJoint>();
                        grabbingObject.GetComponent<FixedJoint>().connectedBody = GetComponentInParent<Rigidbody>();
                    }

                    break;

                case "Player":
                    if (grabbingObject == null)
                    {
                        grabbingObject = other.transform;
                        grabbingObject.gameObject.AddComponent<FixedJoint>();
                        grabbingObject.GetComponent<FixedJoint>().connectedBody = GetComponentInParent<Rigidbody>();
                    }
                    break;
            }

        }
        else if (grabbingObject != null)
        {
            Destroy(grabbingObject.GetComponent<FixedJoint>());
            grabbingObject = null;
        }
    }
}

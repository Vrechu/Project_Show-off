using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabObject : MonoBehaviour
{
    private Transform grabbingObject;
    private Transform originalParent;

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
                        originalParent = grabbingObject.parent;
                        grabbingObject.parent = this.transform;
                        grabbingObject.GetComponent<Rigidbody>().useGravity = false;
                        grabbingObject.position = this.transform.position;
                    }
                    else
                    {
                        grabbingObject.position = this.transform.position;
                    }

                    break;

                case "Player":
                    //implement player grab
                    break;
            }

        }
        else if (grabbingObject != null)
        {
            grabbingObject.GetComponent<Rigidbody>().useGravity = true;
            if (originalParent == null) grabbingObject.parent = null;
            else grabbingObject.parent = originalParent;
            grabbingObject = null;
        }
    }
}

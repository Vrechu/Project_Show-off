using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabObject : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Grabbable")
        {
            if (Input.GetAxis("Fire1") == 1)
            {
                other.attachedRigidbody.useGravity = false;
                other.gameObject.transform.parent = this.transform;
                other.transform.position = this.transform.position;
            }
            else
            {
                other.attachedRigidbody.useGravity = true;
                other.gameObject.transform.parent = null;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceEnvironmentObject : MonoBehaviour
{
    [SerializeField] private float bounceForce = 500;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Rigidbody>().AddForce(transform.up * bounceForce);
            //collision.gameObject.GetComponent<Rigidbody>().AddForce(collision.relativeVelocity * - 2, ForceMode.VelocityChange);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceEnvironmentObject : MonoBehaviour
{
    [SerializeField] private float bounceForce = 500;
    [SerializeField] private bool isDelayed = false;
    [SerializeField] private float delayTime = 1;
    [SerializeField] private float delayTimer = 0;
    [SerializeField] private float resetTime = 3;
    [SerializeField] private float resetTimer = 0;

    private void Start()
    {
        delayTimer = delayTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player"
            && !isDelayed)
        {
            collision.gameObject.GetComponent<Rigidbody>().AddForce(transform.up * bounceForce);            
        }
    }

    private void Update()
    {
        if (isDelayed)
        {
            ResetCounter();
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            DelayCounter();
            if (delayTimer < 0)
            {
                collision.gameObject.GetComponent<Rigidbody>().AddForce(transform.up * bounceForce);
                delayTimer = delayTime;
                resetTimer = resetTime;
            }
        } 
    }

    private void DelayCounter()
    {
        if (delayTimer >= 0 && resetTimer < 0)
        {
            delayTimer -= Time.deltaTime;
        }
    }

    private void ResetCounter()
    {
        if (resetTimer >= 0)
        {
            resetTimer -= Time.deltaTime;
        }
    }
}

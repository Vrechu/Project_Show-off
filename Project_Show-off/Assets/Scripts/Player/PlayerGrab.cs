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
    [SerializeField] private float grabHeight = 0.5f;


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
                case "Fruit":
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
                case "DestroyOnFall":
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
        grabbingObject.position += new Vector3(0, grabHeight, 0);
        grabbingObject.gameObject.AddComponent<FixedJoint>();
        grabbingObject.GetComponent<FixedJoint>().connectedBody = GetComponentInParent<Rigidbody>();
        IsGrabbing = true;
        canGrab = false;
        grabTimer = grabTime;
        SoundManager.Instance.PlayEffect(SoundManager.Instance.Bite);
    }

    private void LetLoose()
    {
        if (grabbingObject != null)
        {
            Destroy(grabbingObject.GetComponent<FixedJoint>());
            grabbingObject.GetComponent<Rigidbody>().AddForce((transform.forward + transform.up).normalized * pushForce, ForceMode.Impulse);
            grabbingObject = null;
            SoundManager.Instance.PlayEffect(SoundManager.Instance.Push);
        } 
        IsGrabbing = false;
        grabTimer = grabTime;
    }
}

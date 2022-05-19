using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDirectionPivot : MonoBehaviour
{
    private PlayerMovement playerMovement;

    void Start()
    {
        playerMovement = GetComponentInParent<PlayerMovement>();
    }

    void Update()
    {
        SetDirection();
    }

    private void SetDirection()
    {
        if (playerMovement.direction().magnitude != 0 
            && !GetComponentInChildren<JointGrab>().IsGrabbing) {
            Quaternion rotation = Quaternion.identity;
            rotation.SetLookRotation(new Vector3(playerMovement.direction().x, 0, playerMovement.direction().y), Vector3.up);
            transform.rotation = rotation;
        } }
}

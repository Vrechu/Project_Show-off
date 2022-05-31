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
        if (playerMovement.Direction().magnitude != 0 
            && !GetComponentInChildren<PlayerGrab>().IsGrabbing) {
            Quaternion rotation = Quaternion.identity;
            rotation.SetLookRotation(new Vector3(playerMovement.Direction().x, 0, playerMovement.Direction().y), Vector3.up);
            transform.rotation = rotation;
        } }
}

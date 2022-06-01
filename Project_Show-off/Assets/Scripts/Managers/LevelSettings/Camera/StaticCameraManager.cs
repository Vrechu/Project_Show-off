using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticCameraManager : CameraManager
{
    [SerializeField] private GameObject staticCamera;

    private PlayerManager playerManager;
    protected override GameObject MyCamera(int playerNumber)
    {
        return staticCamera;
    }

    public override void SetCamera(PlayerProfile playerProfile)
    {
        //playerProfile.avatar.GetComponentInChildren<Camera>().enabled = false;
        //playerProfile.avatar.GetComponent<PlayerMovement>().cameraTransform = staticCamera.transform;
    }
}

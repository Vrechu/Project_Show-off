using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticCameraManager : CameraManager
{
    [SerializeField] private Camera staticCamera;

    public override Camera MyCamera(int playerNumber)
    {
        return staticCamera;
    }

    public override void SetCamera()
    {
        for (int i = 0; i < playerManager.GetPlayerProfiles().Count; i++)
        {
            playerManager.GetPlayerProfiles()[i].avatar.GetComponentInChildren<Camera>().enabled = false;
            playerManager.GetPlayerProfiles()[i].avatar.GetComponent<PlayerMovement>().cameraTransform = staticCamera.transform;
        }
    }
}

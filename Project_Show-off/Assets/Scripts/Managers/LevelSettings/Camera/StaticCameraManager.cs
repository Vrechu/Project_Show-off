using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticCameraManager : CameraManager
{
    [SerializeField] private Camera staticCamera;

    public override Camera MyCamera(int playerNumber)
    {
        Debug.Log("3");
        Debug.Log(staticCamera);
        return staticCamera;
    }

    public override void SetCamera()
    {
        for (int i = 0; i < playerManager.GetPlayerProfiles().Count; i++)
        {
            Debug.Log("2");
            playerManager.GetPlayerProfiles()[i].avatar.GetComponentInChildren<Camera>().enabled = false;
            playerManager.GetPlayerProfiles()[i].avatar.GetComponent<PlayerMovement>().cameraTransform = staticCamera.transform;
        }
    }
}

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
        
    }
}

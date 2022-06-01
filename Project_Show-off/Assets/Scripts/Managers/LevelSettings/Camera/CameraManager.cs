using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CameraManager : MonoBehaviour
{
    protected PlayerManager playerManager;
    protected virtual void Start()
    {
        Debug.Log("1");
        GetComponent<LevelSettings>().CameraManager = this;
        playerManager = PlayerManager.Instance;
        SetCamera();
    }

    public abstract Camera MyCamera(int playerNumber);
    public abstract void SetCamera();

}

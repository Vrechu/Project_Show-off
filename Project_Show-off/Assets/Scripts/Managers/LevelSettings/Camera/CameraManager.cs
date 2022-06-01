using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CameraManager : MonoBehaviour
{
    protected virtual void Start()
    {
        GetComponent<LevelSettings>().CameraManager = this;
    }

    protected abstract GameObject MyCamera(int playerNumber);
    public abstract void SetCamera(PlayerProfile playerProfile);

}

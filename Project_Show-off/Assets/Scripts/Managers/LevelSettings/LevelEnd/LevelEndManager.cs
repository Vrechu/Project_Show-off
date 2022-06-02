using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class LevelEndManager : MonoBehaviour
{
    public event Action OnLevelEnd;

    protected virtual void Start()
    {
        GetComponent<LevelSettings>().LevelEndManager = this;
    }

    public virtual void EndLevel()
    {
        OnLevelEnd?.Invoke();
    }

}

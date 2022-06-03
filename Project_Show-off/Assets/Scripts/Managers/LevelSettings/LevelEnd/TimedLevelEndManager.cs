using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedLevelEndManager : LevelEndManager
{
    [SerializeField] private float levelTime;

    protected override void Start()
    {
        base.Start();
        levelTimer = levelTime;
    }

    private void FixedUpdate()
    {
        LevelCountdown();
    }

    protected  void LevelCountdown()
    {
        if (levelTimer > 0)
        {
            levelTimer -= Time.fixedDeltaTime;
        }
        else EndLevel();
    }
}

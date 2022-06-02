using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedLevelEndManager : LevelEndManager
{
    [SerializeField] private float levelTime;
    [SerializeField] private float levelTimer;

    protected override void Start()
    {
        base.Start();
        levelTimer = levelTime;
    }

    private void FixedUpdate()
    {
        LevelCountdown();
    }

    private void LevelCountdown()
    {
        if (levelTimer > 0)
        {
            levelTimer -= Time.fixedDeltaTime;
        }
        else EndLevel();
    }
}

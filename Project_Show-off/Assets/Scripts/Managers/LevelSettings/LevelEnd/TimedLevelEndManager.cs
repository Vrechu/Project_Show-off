using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedLevelEndManager : LevelEndManager
{
    [SerializeField] private float levelTime;
    [SerializeField] private bool OnTimer = true;

    protected override void Start()
    {
        base.Start();
        levelTimer = levelTime;
    }

    private void FixedUpdate()
    {
        if (OnTimer)LevelCountdown();
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class LevelEndManager : MonoBehaviour
{
    private ManageScene manageScene;
    private ScoreManager scoreManager;
    private PlayerManager playerManager;
    public float levelTimer;

    protected virtual void Start()
    {
        GetComponent<LevelSettings>().LevelEndManager = this;
        manageScene = ManageScene.Instance;
        scoreManager = ScoreManager.Instance;
        playerManager = PlayerManager.Instance;
    }

    public virtual void EndLevel()
    {
        for (int i = 0; i < playerManager.GetPlayerProfiles().Count; i++)
        {
            playerManager.GetPlayerProfiles()[i].InScene = false;
        }
        scoreManager.SetGlobalPlayerScores();
        manageScene.LoadScene("Transition");
    }

}

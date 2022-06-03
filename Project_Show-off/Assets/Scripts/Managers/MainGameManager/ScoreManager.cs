using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; set; }

    public float[] GlobalPlayerScores = new float[4];
    public float[] LevelPlayerScores = new float[4];

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(this);
    }

    public void SetGlobalPlayerScores()
    {
        for (int i = 0; i < GlobalPlayerScores.Length; i++)
        {
            GlobalPlayerScores[i] += LevelPlayerScores[i];
        }
    }

    public void AddLevelPlayerScore(int playerNumber, float addedScore)
    {
        LevelPlayerScores[playerNumber] += addedScore;
    }

    public void ClearGlobalPlayerSCores()
    {
        for (int i = 0; i < GlobalPlayerScores.Length; i++)
        {
            GlobalPlayerScores[i] = 0;
        }
    }

    public void ClearLevelPlayerScores()
    {
        for (int i = 0; i < LevelPlayerScores.Length; i++)
        {
            LevelPlayerScores[i] = 0;
            
        }
    }

    public int TopPlayer()
    {
        float topScore = 0;
        int player = 0;
        for (int i = 0; i < GlobalPlayerScores.Length; i++)
        {
            if (GlobalPlayerScores[i] > topScore)
            {
                topScore = GlobalPlayerScores[i];
                player = i;
            }
        }
        return player;
    }
}

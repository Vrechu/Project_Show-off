using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; set; }

    public float[] ScoresPerRank = new float[] { 100, 75, 50, 25 }; 
    public float[] GlobalPlayerScores = new float[4];
    public float[] LevelPlayerScores = new float[4];
    public int[] LevelPlayerRanks = new int[4];

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(this);
    }

    public void SetGlobalPlayerScores()
    {
        for (int i = 0; i < GlobalPlayerScores.Length; i++)
        {
            GlobalPlayerScores[i] += ScoresPerRank[LevelPlayerRanks[i]];
        }
    }

    public void AddLevelPlayerScore(int playerNumber, float addedScore)
    {
        LevelPlayerScores[playerNumber] += addedScore;
    }

    public void RemoveLevelPlayerScore(int playerNumber, float removedScore)
    {
        LevelPlayerScores[playerNumber] -= removedScore;
    }

    public void ClearGlobalPlayerScores()
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

    public void ClearLevelPlayerRanks()
    {
        for (int i = 0; i < LevelPlayerRanks.Length; i++)
        {
            LevelPlayerRanks[i] = 0;
        }
    }
}

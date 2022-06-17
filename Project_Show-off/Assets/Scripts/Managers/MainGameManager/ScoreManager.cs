using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; set; }
    public static event Action OnScoreChange;

    public int[] ScoresPerRank = new int[] { 100, 75, 50, 25 }; 
    public int[] GlobalPlayerScores, GlobalPlayerRanks ,LevelPlayerScores, LevelPlayerRanks = new int[4];

    private void Awake()
    {
        GameInstanceManager.OnManagerDone += ManagerSetup;
    }

    private void OnDestroy()
    {
        GameInstanceManager.OnManagerDone -= ManagerSetup;
    }

    private void ManagerSetup()
    {
        if (Instance == null) Instance = this;
        else
        {
            Destroy(Instance);
            Instance = this;
        }
    }

    public void SetGlobalPlayerScores()
    {
        for (int i = 0; i < GlobalPlayerScores.Length; i++)
        {
            GlobalPlayerScores[i] += ScoresPerRank[LevelPlayerRanks[i]];
        }
    }

    public void AddLevelPlayerScore(int playerNumber, int addedScore)
    {
        LevelPlayerScores[playerNumber] += addedScore;
        CalculateLevelRanksFromScores();
    }

    public void RemoveLevelPlayerScore(int playerNumber, int removedScore)
    {
        LevelPlayerScores[playerNumber] -= removedScore;
        CalculateLevelRanksFromScores();
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

    public void SetLevelPlayerRank(int player, int rank)
    {
        LevelPlayerRanks[player] = rank;
        OnScoreChange?.Invoke();
    }

    public void ClearLevelPlayerRanks()
    {
        for (int i = 0; i < LevelPlayerRanks.Length; i++)
        {
            LevelPlayerRanks[i] = 0;
        }
    }

    private void CalculateLevelRanksFromScores()
    {
        for (int i = 0; i < LevelPlayerScores.Length; i++)
        {
            int rank = 3;
            for (int j = 0; j < LevelPlayerScores.Length; j++)
            {
                if (j != i && LevelPlayerScores[i] >= LevelPlayerScores[j]) rank--;
            }
            SetLevelPlayerRank(i, rank);
        }
    }

    private void CalculateGlobalRanksFromScores()
    {
        for (int i = 0; i < GlobalPlayerScores.Length; i++)
        {
            int rank = 3;
            for (int j = 0; j < GlobalPlayerScores.Length; j++)
            {
                if (j != i && GlobalPlayerScores[i] >= GlobalPlayerScores[j]) rank--;
            }
            GlobalPlayerRanks[i] = rank;
        }
    }

}

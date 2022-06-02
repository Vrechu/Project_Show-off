using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShowScores : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI[] globalScoreText = new TextMeshProUGUI[4];
    [SerializeField] private TextMeshProUGUI[] levelScoreText = new TextMeshProUGUI[4];

    private ScoreManager scoreManager;
    private PlayerManager playerManager;

    void Start()
    {
        scoreManager = ScoreManager.Instance;
        playerManager = PlayerManager.Instance;
    }

    private void FixedUpdate()
    {
        SetGlobalScores();
        SetLevelScores();
    }

    public void SetGlobalScores()
    {
        for (int i = 0; i < playerManager.GetPlayerProfiles().Count; i++)
        {
            globalScoreText[i].text = scoreManager.GlobalPlayerScores[i].ToString();
        }
    }

    public void SetLevelScores()
    {
        for (int i = 0; i < playerManager.GetPlayerProfiles().Count; i++)
        {
            levelScoreText[i].text = scoreManager.GlobalPlayerScores[i].ToString();
        }
    }

}

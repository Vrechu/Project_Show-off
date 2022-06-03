using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinalScreen : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI[] scores = new TextMeshProUGUI[4];
    [SerializeField] private GameObject[] winner = new GameObject[4];
    private ScoreManager scoreManager;
    private PlayerManager playerManager;

    void Start()
    {
        scoreManager = ScoreManager.Instance;
        playerManager = PlayerManager.Instance;
        SetWinner();
    }

    private void FixedUpdate()
    {
        ShowScores();
    }

    private void SetWinner()
    {
        for (int i = 0; i < winner.Length; i++)
        {
            winner[i].SetActive(false);
        }
        winner[scoreManager.TopPlayer()].SetActive(true);
    }

    private void ShowScores()
    {
        for (int i = 0; i < playerManager.GetPlayerProfiles().Count; i++)
        {
            scores[i].text = scoreManager.GlobalPlayerScores[i].ToString();
        }
    }

    public void BackToMenu()
    {
        ManageScene.Instance.LoadScene("MainMenu");
    }
}

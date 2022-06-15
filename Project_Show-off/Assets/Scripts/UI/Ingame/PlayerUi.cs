using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerUi : MonoBehaviour
{
    [SerializeField] private GameObject[] avatarImages, playerIcons;
    [SerializeField] private GameObject crown;
    [SerializeField] private int playerNumber;
    [SerializeField] private TextMeshProUGUI score;
    [SerializeField] private bool scoreGame = false;

    private void OnEnable()
    {
        SetAvatarImage();
        SetPlayerIcon();
        crown.SetActive(false);
        ScoreManager.OnScoreChange += SetScore;
    }

    private void OnDisable()
    {
        ScoreManager.OnScoreChange -= SetScore;   
    }

    private void SetAvatarImage()
    {
        for (int i = 0; i < avatarImages.Length; i++)
        {
            avatarImages[i].SetActive(false);
        }
        if (playerNumber < PlayerManager.Instance.GetPlayerProfiles().Count)
        {
            avatarImages[PlayerManager.Instance.GetPlayerProfiles()[playerNumber].AvatarNumber].SetActive(true);
        }
    }

    private void SetPlayerIcon()
    {
        for (int i = 0; i < playerIcons.Length; i++)
        {
            playerIcons[i].SetActive(false);
        }
        avatarImages[playerNumber].SetActive(true);
    }


    private void SetScore()
    {
        if (scoreGame)
        {
            score.text = ScoreManager.Instance.LevelPlayerScores[playerNumber].ToString();
        } 
        else score.text = ScoreManager.Instance.LevelPlayerRanks[playerNumber].ToString();
        SetCrown();
    }

    private void SetCrown()
    {
        if (ScoreManager.Instance.LevelPlayerRanks[playerNumber] == 0) crown.SetActive(true);
        else crown.SetActive(false);
    }
}

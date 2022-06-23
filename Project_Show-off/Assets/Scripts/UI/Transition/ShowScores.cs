using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShowScores : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI[] showScoresText, addedScoresText = new TextMeshProUGUI[4];

    [SerializeField] private float[] shownPlayerScores, addedScores = new float[4];
    private bool[] doneCounting = new bool[4];
    private int amountDone = 0;
    [SerializeField] private float increaseSpeed = 5;

    private ScoreManager scoreManager;
    private PlayerManager playerManager;

    private UniversalInputs inputs = new UniversalInputs(0);
    private bool canContinue = false;
    [SerializeField] private GameObject continuePanel;
    [SerializeField] private GameObject[] playerPanels, crowns = new GameObject[4];

    [SerializeField] private float waitTillCount = 1;

    void Start()
    {
        scoreManager = ScoreManager.Instance;
        playerManager = PlayerManager.Instance;
        

        continuePanel.SetActive(false);

        for (int i = 0; i < playerPanels.Length; i++)
        {
            playerPanels[i].SetActive(false);
            crowns[i].SetActive(false);
        }
        for (int i = 0; i < playerManager.GetPlayerProfiles().Count; i++)
        {
            playerPanels[i].SetActive(true);
        }

        ManageScene.Instance.SetNextLevel();
 
        SoundManager.Instance.PlayMusic(SoundManager.Instance.LoadingMusic);

        SetUpScores();
    }

    private void Update()
    {
        Continue();
        VisualiseIncreasedScores();
        ShowScoresUI();
        CountDown();
    }


    public void SetUpScores()
    {
        for (int i = 0; i < playerManager.GetPlayerProfiles().Count; i++)
        {
            shownPlayerScores[i] = scoreManager.OldGlobalPlayerScores[i];
            addedScores[i] = scoreManager.GlobalPlayerScores[i] - scoreManager.OldGlobalPlayerScores[i];
        }
    }

    public void ShowScoresUI()
    {
        for (int i = 0; i < playerManager.GetPlayerProfiles().Count; i++)
        {
            showScoresText[i].text = ((int)shownPlayerScores[i]).ToString();
            addedScoresText[i].text = ((int)addedScores[i]).ToString();
        }
    }

    public void VisualiseIncreasedScores()
    {
        if (waitTillCount <= 0)
        {
            for (int i = 0; i < playerManager.GetPlayerProfiles().Count; i++)
            {
                if (shownPlayerScores[i] < scoreManager.GlobalPlayerScores[i])
                {
                    shownPlayerScores[i] += Time.deltaTime * increaseSpeed;
                    addedScores[i] -= Time.deltaTime * increaseSpeed;
                    doneCounting[i] = false;
                }
                else if (doneCounting[i] != true)
                {
                    doneCounting[i] = true;
                    amountDone++;
                }
            }
            if (amountDone >= playerManager.GetPlayerProfiles().Count
                && !canContinue)
            {
                canContinue = true;
                continuePanel.SetActive(true);
                SetCrown();
                SoundManager.Instance.PlayEffect(SoundManager.Instance.Return);
            }
        }
    }

    public void Continue()
    {
        if (canContinue && inputs.JumpPressed())
        {
            if (ManageScene.Instance.NextLevel != 0) ManageScene.Instance.LoadScene("InfoScreen");
            else ManageScene.Instance.LoadNextLevel();
            SoundManager.Instance.PlayEffect(SoundManager.Instance.Select);
        }
    }

    private void SetCrown()
    {
        scoreManager.CalculateGlobalRanksFromScores();
        for (int i = 0; i < playerManager.GetPlayerProfiles().Count; i++)
        {
            if (scoreManager.GlobalPlayerRanks[i] == 0)
            {
                crowns[i].SetActive(true);
                SoundManager.Instance.PlayEffect(SoundManager.Instance.PlayerSounds[i]);
            }
        }
    }

    private void CountDown()
    {
        if (waitTillCount > 0)
        {
            waitTillCount -= Time.deltaTime;
        }
    }
}

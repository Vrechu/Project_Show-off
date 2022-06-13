using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoScreen : MonoBehaviour
{
    [SerializeField] private GameObject[] InfoPanels;

    private void Start()
    {
        ManageScene.Instance.SetNextLevel();
        SetPanel();
    }

    private void SetPanel()
    {
        for (int i = 0; i < InfoPanels.Length; i++)
        {
            InfoPanels[i].SetActive(false);
        }
        InfoPanels[ManageScene.Instance.NextLevel].SetActive(true);
    }

    public void Continue()
    {
        ManageScene.Instance.LoadNextLevel();
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetermineGoals : MonoBehaviour
{
    [SerializeField] GameObject[] goals = new GameObject[4];
    void Start()
    {
        for (int i = 0; i < goals.Length; i++)
        {
            goals[i].SetActive(false);
        }

        for (int i = 0; i < PlayerManager.Instance.GetPlayerProfiles().Count; i++)
        {
            goals[i].SetActive(true);
        }
    }
}

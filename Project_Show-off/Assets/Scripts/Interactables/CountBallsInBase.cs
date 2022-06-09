using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountBallsInBase : MonoBehaviour
{
    [SerializeField] private int playerNumber;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ScoringObject"))
        {
            ScoreManager.Instance.AddLevelPlayerScore(playerNumber ,other.GetComponent<ScoreObject>().score);            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("ScoringObject"))
        {
            ScoreManager.Instance.RemoveLevelPlayerScore(playerNumber, other.GetComponent<ScoreObject>().score);
        }
    }


}

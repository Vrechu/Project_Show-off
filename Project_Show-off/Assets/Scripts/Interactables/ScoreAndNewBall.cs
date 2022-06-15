using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScoreAndNewBall : MonoBehaviour
{
    [SerializeField] private int playerNumber;
    public static UnityEvent OnScore;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ScoringObject"))
        {
            ScoreManager.Instance.AddLevelPlayerScore(playerNumber, other.GetComponent<ScoreObject>().score);
            OnScore?.Invoke();
            Destroy(other.gameObject);
            Debug.Log("added");
        }
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPositions;
    [SerializeField] private GameObject[] objects;

    [SerializeField] private bool AutomaticSpawn = false;
    [SerializeField] private bool SpawnOnHere = false;

    [SerializeField] private float time = 5;
    [SerializeField] private float timer;

    private void Start()
    {
        timer = time;
    }

    private void Update()
    {
        CountDown();
        AutoSpawn();
    }

    public void SpawnObjectHere()
    {
        int randomObject = Random.Range(0, objects.Length);
        Instantiate(objects[randomObject], transform);
    }

    public void SpawnObjectAtPositions()
    {
        int randomObject = Random.Range(0, objects.Length);
        int randomPosition = Random.Range(0, spawnPositions.Length);
        Instantiate(objects[randomObject], spawnPositions[randomPosition]);
    }

    private void CountDown()
    {
        if ( timer > 0)
        {
            timer -= Time.deltaTime;
        }
    }

    private void AutoSpawn()
    {
        if (AutomaticSpawn && timer <= 0)
        {
            if (SpawnOnHere)
            {
                SpawnObjectHere();
            }
            else
            {
                SpawnObjectAtPositions();
            }
            timer = time;
        }
    }
}

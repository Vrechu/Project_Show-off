using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    [SerializeField] private bool spawnOnHere = false;
    [SerializeField] private bool automaticSpawn = false;
    [SerializeField] private bool movingObjects = false;

    [SerializeField] private GameObject[] objects;
    [SerializeField] private Transform[] spawnPositions;
    [SerializeField] private Transform[] targets;


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
        GameObject placedObject = Instantiate(objects[randomObject], transform.position, Quaternion.identity);
        if (movingObjects) placedObject.GetComponent<MoveObjectToTarget>().SetDirection(targets[0]);
        SoundManager.Instance.PlayEffect(SoundManager.Instance.Fall);
    }

    public void SpawnObjectAtPositions()
    {
        int randomObject = Random.Range(0, objects.Length);
        int randomPosition = Random.Range(0, spawnPositions.Length);
        GameObject placedObject = Instantiate(objects[randomObject], spawnPositions[randomPosition].position, Quaternion.identity);
        if (movingObjects) placedObject.GetComponent<MoveObjectToTarget>().SetDirection(targets[randomPosition]);
        SoundManager.Instance.PlayEffect(SoundManager.Instance.Fall);
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
        if (automaticSpawn && timer <= 0)
        {
            if (spawnOnHere)
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

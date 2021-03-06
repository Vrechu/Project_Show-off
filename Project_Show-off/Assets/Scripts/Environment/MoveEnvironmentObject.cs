using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnvironmentObject : MonoBehaviour
{
    [SerializeField] private Transform[] movePositions;
    private Queue<Vector3> movePositionQueue = new Queue<Vector3>();
    [SerializeField] private bool Loop = true;

    [SerializeField] private float moveSpeed = 0.5f;
    [SerializeField] private float waitingTime = 1;
    [SerializeField] private float waitingTimer = 0;
    private bool waiting = true;
    

    void Start()
    {
        if (movePositions.Length > 0)
        {
            movePositionQueue.Enqueue(transform.position);
            for (int i = 0; i < movePositions.Length; i++)
            {
                movePositionQueue.Enqueue(movePositions[i].position);
            }
        }
        else Debug.LogError("no moving positions");
    }

    void Update()
    {
        WaitCountDown();
        MoveToTarget();        
    }

    private bool TargetReached(Vector3 targetPosition)
    {
        if ((targetPosition -transform.position).magnitude <= moveSpeed * Time.deltaTime)
        {
            transform.position = targetPosition;
            return true;
        }
        else
        {
            return false;
        }
    }

    private void MoveToTarget()
    {
        if (!waiting && movePositionQueue.Count > 0)
        {
            if (TargetReached(movePositionQueue.Peek()))
            {
                if (Loop)
                {
                    movePositionQueue.Enqueue(movePositionQueue.Dequeue());
                }
                else movePositionQueue.Dequeue();
                waiting = true;
                waitingTimer = waitingTime;
            }
            else
            {
                transform.Translate(MoveDirection() * moveSpeed * Time.deltaTime,Space.World);
            }
        }
    }

    private Vector3 MoveDirection()
    {
        return (movePositionQueue.Peek() - transform.position).normalized;
    }

    private void WaitCountDown()
    {
        if (waitingTimer >= 0 
            && waiting)
        {
            waitingTimer -= Time.deltaTime;
        }
        else waiting = false;
    }
        
        
}

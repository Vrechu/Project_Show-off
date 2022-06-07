using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObjectToTarget : MonoBehaviour
{
    private Vector3 direction;
    private Vector3 target;
    [SerializeField] private float moveSpeed;

    private void Start()
    {
        if (direction == null) direction = transform.position;
    }

    public void SetDirection(Transform targetPosition)
    {
        target = targetPosition.position;
        direction = (target - transform.position).normalized;
    }

    private void Update()
    {
        transform.Translate(direction * moveSpeed * Time.deltaTime, Space.World);
        if((target - transform.position).magnitude < moveSpeed * Time.deltaTime)
        {
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingPlatform : MonoBehaviour
{
    [SerializeField] private float rotateSpeed = 1;
    private enum RotatingDirection { Clockwise, Counterclockwise }
    [SerializeField] private RotatingDirection rotatingDirection = RotatingDirection.Clockwise;
    private enum RotationAxis { X, Y, Z }
    [SerializeField] private RotationAxis rotationAxis = RotationAxis.Y;

    private float xRotation = 0;
    private float yRotation = 0;
    private float zRotation = 0;

    void Update()
    {
        RotateAroundAxis();
    }

    private float AdjustedSpeed()
    {
        if (rotatingDirection == RotatingDirection.Clockwise) return rotateSpeed * Time.deltaTime;
        else  return -rotateSpeed * Time.deltaTime;
    }

    private void RotateAroundAxis()
    {
        switch (rotationAxis)
        {
            case RotationAxis.X:
                transform.Rotate(AdjustedSpeed(), 0, 0);
                break;
            case RotationAxis.Y:
                transform.Rotate(0, AdjustedSpeed(), 0);
                break;
            case RotationAxis.Z:
                transform.Rotate(0, 0, AdjustedSpeed());
                break;
        }
    }
}
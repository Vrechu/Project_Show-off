using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetGravity : MonoBehaviour
{
    [SerializeField] private float gravityMultiplier = 3;

    void Start()
    {
        Physics.gravity *= gravityMultiplier;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetGravity : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity *= 2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

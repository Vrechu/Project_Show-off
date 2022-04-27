using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckIfGrounded : MonoBehaviour
{
    [SerializeField]private float checkDistance = 1.1f;

    /// <summary>
    /// 
    /// </summary>
    /// <returns> true if the object is resting on a terrain object</returns>
    public bool IsGrounded()
    {
        return Physics.Raycast(transform.position, transform.up * -1, checkDistance, 1000);
    }

}

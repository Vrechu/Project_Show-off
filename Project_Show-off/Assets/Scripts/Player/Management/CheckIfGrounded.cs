using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckIfGrounded : MonoBehaviour
{
    [SerializeField] private float checkDistance = 1.1f;


    /// <summary>
    /// 
    /// </summary>
    /// <returns> true if the object is resting on a terrain object</returns>
    public bool IsGrounded()
    {
        RaycastHit hitInfo;
        if (Physics.Raycast(transform.position, transform.up * -1, out hitInfo, checkDistance, 0b1001000))
        {
            if (hitInfo.transform.gameObject.layer == 6)        //6 == layer MovingTerrain
            {
                transform.parent = hitInfo.transform;
            }
            else transform.parent = null;
            return true;
        }
        else
        {
            transform.parent = null;
            return false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckIfGrounded : MonoBehaviour
{
    [SerializeField]private float checkDistance = 1.1f;
    [SerializeField] private float coyoteTime = 0.05f;
    [SerializeField] private float coyoteTimeCooldown = 0;
    private bool CoyoteTimeAvailable = false;

    private void Update()
    {
        CountdownCoyoteTime();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns> true if the object is resting on a terrain object</returns>
    public bool IsGrounded()
    {
        if (Physics.Raycast(transform.position, transform.up * -1, checkDistance, 1000))
        {
            CoyoteTimeAvailable = true;
            return true;
        }
        else if (coyoteTimeCooldown > 0)
        {
            return true;
        }
        else if (CoyoteTimeAvailable == true)
        {
            CoyoteTimeAvailable = false;
            coyoteTimeCooldown = coyoteTime;
            return true;
        } 
        else return false;
    }

    private void CountdownCoyoteTime()
    {
        if (coyoteTimeCooldown >= 0)
        {
            coyoteTimeCooldown -= Time.deltaTime;
        }
    }

}

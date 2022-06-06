using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Button : MonoBehaviour
{
    public UnityEvent OnButtunPushed;

    [SerializeField] private float rechargeTime = 3;
    [SerializeField] private float rechargeTimer;
    [SerializeField] private Renderer renderer;
 
    private void Start()
    {
        rechargeTimer = rechargeTime;
    }

    private void Update()
    {
        CountDown();
    }

    private void CountDown()
    {
        if (rechargeTimer > 0)
        {
            rechargeTimer -= Time.deltaTime;
            renderer.material.color = Color.red;
        }
        else renderer.material.color = Color.green;
    }

    private void OnCollisionStay(Collision collision)
    {
        if ( rechargeTimer <= 0 && collision.transform.tag == "Player")
        {
            rechargeTimer = rechargeTime;
            OnButtunPushed?.Invoke();
        }
    }
}

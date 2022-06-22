using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSound : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        SoundManager.Instance.PlayEffect(SoundManager.Instance.FruitHit);
    }
}

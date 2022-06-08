using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPLayerProfile : MonoBehaviour
{
    [SerializeField] private int number = 0;

    private void Awake()
    {
        GetComponent<PlayerProfileAccess>().PlayerProfile = new PlayerProfile(number, number, new KeyboardInputs(number));
    }
}

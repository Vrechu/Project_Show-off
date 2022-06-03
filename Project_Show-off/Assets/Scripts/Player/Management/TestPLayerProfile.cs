using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPLayerProfile : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<PlayerProfileAccess>().PlayerProfile = new PlayerProfile(0, 0, new KeyboardInputs(0));
    }
}

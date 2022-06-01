using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPLayerProfile : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<PlayerProfileAccess>().PlayerProfile = new PlayerProfile(1, 1, new KeyboardInputs(1));
    }
}

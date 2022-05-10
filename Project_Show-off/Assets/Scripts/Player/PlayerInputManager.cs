using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputManager : MonoBehaviour
{
    private Player1KeyboardInputs player1KeyboardInputs;


    void Start()
    {
        player1KeyboardInputs = new Player1KeyboardInputs();
    }

    public Vector2 DirectionVector()
    {
        return player1KeyboardInputs.Ingame.Walk.ReadValue<Vector2>();
    }

}

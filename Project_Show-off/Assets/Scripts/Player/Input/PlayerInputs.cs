using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerInputs
{
    protected int playerNumber;
    public PlayerInputs(int playerNumber)
    {
        this.playerNumber = playerNumber;
    }

    public abstract Vector2 Direction();
    public abstract float Jump();
    public abstract float Grab();
    public abstract float Back();
    public abstract float Menu();
}

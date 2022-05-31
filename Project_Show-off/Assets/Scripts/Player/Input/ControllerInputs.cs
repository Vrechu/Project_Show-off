using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerInputs : PlayerInputs
{
    public ControllerInputs(int playerNumber) : base(playerNumber)
    {
    }

    public override Vector2 Direction()
    {
        return new Vector2(Input.GetAxis("CHorizontal" + playerNumber)* -1, Input.GetAxis("CVertical" + playerNumber));
    }

    public override float Jump()
    {
        return Input.GetAxis("CJump" + playerNumber);
    }

    public override float Grab()
    {
        return Input.GetAxis("CGrab" + playerNumber);
    }

    public override float Back()
    {
        return Input.GetAxis("CBack" + playerNumber);
    }

    public override float Menu()
    {
        return Input.GetAxis("CMenu" + playerNumber);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerInputs : PlayerInputs
{
    public ControllerInputs(int controllerNumber) : base(controllerNumber)
    {
    }

    public override Vector2 Direction()
    {
        return new Vector2(Input.GetAxis("CHorizontal" + controllerNumber)* -1, Input.GetAxis("CVertical" + controllerNumber));
    }

    public override float Jump()
    {
        return Input.GetAxis("CJump" + controllerNumber);
    }

    public override float Grab()
    {
        return Input.GetAxis("CGrab" + controllerNumber);
    }

    public override float Back()
    {
        return Input.GetAxis("CBack" + controllerNumber);
    }

    public override float Menu()
    {
        return Input.GetAxis("CMenu" + controllerNumber);
    }

    public override float Join()
    {
        return Input.GetAxis("CJoin" + controllerNumber);
    }
}

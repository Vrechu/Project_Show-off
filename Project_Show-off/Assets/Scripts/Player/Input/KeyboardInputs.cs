using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardInputs : PlayerInputs
{
    public KeyboardInputs(int playerNumber) : base(playerNumber) { }

    public override Vector2 Direction()
    {
        return new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }

    public override float Jump()
    {
        return Input.GetAxis("Jump");
    }

    public override float Grab()
    {
        return Input.GetAxis("Fire3");
    }

    public override float Back()
    {
        return Input.GetAxis("Cancel");
    }

    public override float Menu()
    {
        return Input.GetAxis("Cancel");
    }
}

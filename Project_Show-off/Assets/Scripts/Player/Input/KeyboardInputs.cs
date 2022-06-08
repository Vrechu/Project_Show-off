using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardInputs : PlayerInputs
{
    public KeyboardInputs(int controllerNumber) : base(controllerNumber) { }

    public override Vector2 Direction()
    {
        switch (controllerNumber)
        {
            case 0:
                return new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            case 1:
                return new Vector2(Input.GetAxis("Horizontal1"), Input.GetAxis("Vertical1"));
        }
        return new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }

    public override float Jump()
    {
        switch (controllerNumber)
        {
            case 0:
                if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.LeftControl)) return 1;
                break;
            case 1:
                if (Input.GetKey(KeyCode.RightControl)) return 1;
                break;
        }
        return 0;
    }

    public override float Grab()
    {
        switch (controllerNumber)
        {
            case 0:
                if (Input.GetKey(KeyCode.LeftShift)) return 1;
                break;
            case 1:
                if (Input.GetKey(KeyCode.RightShift)) return 1;
                break;
        }
        return 0;
    }

    public override float Back()
    {
        if (Input.GetKey(KeyCode.Backspace)) return 1;
        else return 0;
    }

    public override float Menu()
    {
        if (Input.GetKey(KeyCode.Return)) return 1;
        else return 0;
    }
}

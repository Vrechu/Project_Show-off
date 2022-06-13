using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniversalInputs : PlayerInputs
{
    public UniversalInputs(int controllerNumber) : base(controllerNumber)
    {
    }

    public override Vector2 Direction()
    {
        for (int i = 0; i < 4; i++)
        {
            if (new Vector2(Input.GetAxis("CHorizontal" + i + 1) * -1, Input.GetAxis("CVertical" + i + 1)) != Vector2.zero)
            {
                return new Vector2(Input.GetAxis("CHorizontal" + controllerNumber) * -1, Input.GetAxis("CVertical" + controllerNumber));
            }
        } 
        return new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }

    public override float Jump()
    {
        for (int i = 0; i < 4; i++)
        {
            if (Input.GetAxis("CJump" + (i + 1)) == 1) return Input.GetAxis("CJump" + (i + 1));
        }
        return Input.GetAxis("Jump");
    }

    public override float Grab()
    {
        for (int i = 0; i < 4; i++)
        {
            if (Input.GetAxis("CGrab" + (i + 1)) == 1) return Input.GetAxis("CGrab" + (i + 1));
        }
        return Input.GetAxis("Fire3");
    }

    public override float Back()
    {
        for (int i = 0; i < 4; i++)
        {
            if (Input.GetAxis("CBack" + (i + 1)) == 1) return Input.GetAxis("CBack" + (i + 1));
        }
        if (Input.GetKey(KeyCode.Backspace)) return 1;
        else return 0;
    }

    public override float Menu()
    {
        for (int i = 0; i < 4; i++)
        {
             if (Input.GetAxis("CMenu" + (i + 1)) == 1) return Input.GetAxis("CMenu" + (i + 1));
        }
        if (Input.GetKey(KeyCode.Escape)) return 1;
        else return 0;
    }

    public override float Join()
    {
        for (int i = 0; i < 4; i++)
        {
            if (Input.GetAxis("CJoin" + (i + 1)) == 1) return Input.GetAxis("CMenu" + (i + 1));
        }
        if (Input.GetKey(KeyCode.Y)) return 1;
        else return 0;
    }
}

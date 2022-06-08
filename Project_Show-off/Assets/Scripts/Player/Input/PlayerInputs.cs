using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerInputs
{
    protected int controllerNumber;
    protected float lastJump, lastGrab, lastBack, lastMenu, lastDirection = 0;

    public PlayerInputs(int controllerNumber)
    {
        this.controllerNumber = controllerNumber;
    }

    public abstract Vector2 Direction();

    public float ChangedFrameDirection()
    {
        float output = 0;
        if (Direction().x != 0)
        {
            if (Direction().x > 0) output = 1;
            else output = -1;
        }

        if (output != lastDirection)
        {
            lastDirection = output;
            return output;
        }
        else return 0;
    }

    public abstract float Jump();
    public abstract float Grab();
    public abstract float Back();
    public abstract float Menu();
    public bool JumpPressed()
    {
        if (Jump() != lastJump)
        {
            lastJump = Jump();
            if (Jump() == 1) return true;
            else return false;
        }
        else return false;
    }

    public bool GrabPressed()
    {
        if (Grab() != lastGrab)
        {
            lastGrab = Grab();
            if (Grab() == 1) return true;
            else return false;
        }
        else return false;
    }

    public bool BackPressed()
    {
        if (Back() != lastBack)
        {
            lastBack = Back();
            if (Back() == 1) return true;

            else return false;
        }
        else return false;
    }

    public bool MenuPressed()
    {
        if (Menu() != lastMenu)
        {
            lastMenu = Menu();
            if (Menu() == 1)
            {
                return true;

            }
            else return false;
        }
        else return false;
    }
}

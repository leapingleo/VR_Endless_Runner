using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseState : State
{
    public PauseState() : base()
    {

    }

    public override void Pause()
    {
        
    }

    public override void Tick()
    {
        Debug.Log("at pause");

        if (ActionController.Instance.rightSecondaryButtonPressed || Input.GetKeyDown(KeyCode.P))
            GameManager.Instance.SetState(GameManager.Instance.FindState("Play"));
    }

    public override string GetName()
    {
        return "Pause";
    }
}

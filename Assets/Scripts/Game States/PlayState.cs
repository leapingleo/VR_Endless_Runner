using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayState : State
{
    public PlayState() : base()
    {

    }

    public override void Playing()
    {
       
    }

    public override void Tick()
    {
         Debug.Log("playing here");

        if (ActionController.Instance.rightTriggerPressed 
       || Input.GetKeyDown(KeyCode.P))
            GameManager.Instance.SetState(GameManager.Instance.FindState("Pause"));
    }

    public override string GetName()
    {
        return "Play";
    }
}

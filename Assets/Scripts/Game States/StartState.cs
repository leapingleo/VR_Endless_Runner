using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartState : State
{
    public StartState() : base() 
    {

    }

    public override void Start()
    {
      
    }

    public override void Tick()
    {
       //   Debug.Log("start state");
       // return base.Start();
        if (ActionController.Instance.rightMainButtonPressed
        || Input.GetKeyDown(KeyCode.P))
            GameManager.Instance.SetState(GameManager.Instance.FindState("Play"));
    }

    public override string GetName()
    {
        return "Start";
    }
}

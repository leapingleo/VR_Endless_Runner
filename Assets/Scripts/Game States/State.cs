using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{

    public State()
    {
    }

    public virtual void Start() 
    {
       // yield break;
    }

    public virtual void Playing() 
    {
        //yield break;
    }

    public virtual void Pause() 
    {
        //yield break;
    }

    public virtual void Tick()
    {
        Debug.Log("ticking");
    }

    public virtual string GetName()
    {
        return "";
    }
}

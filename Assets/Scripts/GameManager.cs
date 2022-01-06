using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private State currentState;
    public State[] states;
    private Dictionary<string, State> stateDict;


    void Awake() 
    {
        if (Instance == null)
            Instance = this;
    }

    void Start()
    {
        stateDict = new Dictionary<string, State>();

        foreach (State s in states) {
            stateDict.Add(s.GetName(), s);
        }

        currentState = new StartState();

        SetState(currentState);
        currentState.Start();
    }

    public void SetState(State state){
        currentState = state;
        //currentState.Start();
    }

    // Update is called once per frame
    void Update()
    {
        currentState.Tick();
    }

    public State FindState(string name) 
    {
        State state;

        if (stateDict.TryGetValue(name, out state))
            return state;

        return null;
    }

}



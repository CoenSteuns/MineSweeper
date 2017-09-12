using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine <T> {

    private State _currentState;
    private Dictionary<T, State> _states;

    public StateMachine()
    {
        _states = new Dictionary<T, State>();
    }

    public void AddState(T key, State state)
    {
        _states.Add(key, state);
    }

    public void SetState(T key)
    {
        if (_states[key] == null)
            return;

        if (_currentState != null)
            _currentState.ExitState();

        _currentState = _states[key];

        _currentState.EnterState();
    }

    public void Update()
    {
        if (_currentState == null)
            return;

        _currentState.Update();
        _currentState.Reason();
    }


}

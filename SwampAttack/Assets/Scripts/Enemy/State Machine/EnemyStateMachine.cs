using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyStateMachine : MonoBehaviour
{
    [SerializeField] private State _startState;

    private Player _target;

    private State _currentState;

    public State CurrentState => _currentState;

    public void Init(Player target)
    {
        _target = target;

        Reset(_startState);
    }

    private void Update()
    {
        if (_currentState == null)
            return;

        var next = _currentState.GetNextState();

        if (next != null)
            Transit(next);
    }

    public void Reset(State startState)
    {
        _currentState = startState;

        if (_currentState != null)
            _currentState.Enter(_target);
    }

    private void Transit(State _nextState)
    {
        if (_currentState != null)
            _currentState.Exit();

        _currentState = _nextState;

        if (_currentState != null)
            _currentState.Enter(_target);
    }
}

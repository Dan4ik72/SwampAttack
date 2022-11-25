using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Transition : MonoBehaviour
{
    [SerializeField] private State _targetState;

    protected Player Target { get; private set; }

    public State TargetState => _targetState;

    public bool IsNeedTransit { get; protected set; }

    private void Start()
    {
        IsNeedTransit = false;
    }

    public void Init(Player _target)
    {
        Target = _target;
    }
}

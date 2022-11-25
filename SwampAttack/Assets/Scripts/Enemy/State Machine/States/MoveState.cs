using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : State
{
    [SerializeField] private float _speed;

    private readonly int _runAnimationHash = Animator.StringToHash("Run");

    private void OnEnable()
    {
        GetComponent<Animator>().Play(_runAnimationHash);
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, Target.transform.position, _speed * Time.deltaTime);
    }
}

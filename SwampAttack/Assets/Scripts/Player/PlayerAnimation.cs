using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimation : MonoBehaviour
{
    private readonly int IsRunningParameterHash = Animator.StringToHash("IsRunning");
    private readonly int OnShootGun1ParameterHash = Animator.StringToHash("OnShootGun01");

    private Animator _animator;
    private PlayerInput _playerInput;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _playerInput = GetComponent<PlayerInput>();

        Weapon.OnMakeDamage += OnShot;
    }

    private void Update()
    {
        _animator.SetBool(IsRunningParameterHash, _playerInput.IsRunning);
    }

    private void OnShot()
    {
        _animator.SetTrigger(OnShootGun1ParameterHash);
    }
}

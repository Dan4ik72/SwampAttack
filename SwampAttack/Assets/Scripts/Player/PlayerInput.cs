using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(Player))]
public class PlayerInput : MonoBehaviour
{
    private PlayerMovement _playerMovement;
    private Player _player;

    private Vector3 _previousPosition;
    private Direction _currentDirection;

    public bool IsRunning => _previousPosition != transform.position;

    private void Start()
    {
        _player = GetComponent<Player>();
        _playerMovement = GetComponent<PlayerMovement>();

        _currentDirection = Direction.Right;
    }

    private void Update()
    {
        _previousPosition = transform.position;

        if (Input.GetKey(KeyCode.D))
        {
            _currentDirection = Direction.Right;
            
            _playerMovement.Run((int)_currentDirection);
        }

        if (Input.GetKey(KeyCode.A))
        {
            _currentDirection = Direction.Left;

            _playerMovement.Run((int)_currentDirection);
        }

        if (Input.GetMouseButton(0) && _player.WeaponBag.CurrentWeapon.IsBought)
        {
            _player.WeaponBag.CurrentWeapon.MakeDamage(Vector2.right);  
        }
    }

    enum Direction
    {
        Left= -1,
        Right = 1
    }
}



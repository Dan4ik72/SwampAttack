using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Rigidbody2D _rigidbody;
        
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();        
    }

    public void Run(int direction)
    {
        transform.localScale = new Vector3(direction, transform.localScale.y, transform.localScale.z);

        transform.Translate(direction * _speed * Time.deltaTime, 0, 0);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;

    private readonly int _bulletIgnoreLayerNumber = 6;

    private int _damage;

    private Vector2 _direction;

    public void Init(int damage, Vector2 direction)
    {
        _damage = damage;
        _direction = direction;
    }

    private void Update()
    {
        transform.Translate(_speed * Time.deltaTime * _direction);        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == _bulletIgnoreLayerNumber)
            return;

        if(collision.gameObject.TryGetComponent<IDamageable>(out IDamageable target))
        {
            target.ApplyDamage(_damage);
        }

        gameObject.SetActive(false);
    }
}

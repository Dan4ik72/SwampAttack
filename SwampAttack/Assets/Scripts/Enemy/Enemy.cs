using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour, IDamageable
{
    public event UnityAction<Enemy,Vector3> OnDied;

    [SerializeField] private EnemyStateMachine _stateMachine;

    [SerializeField] private int _health;
    [SerializeField] private int _reward;

    private Player _target;

    private int _maxHealth = 100;

    public int Reward => _reward;
    public Player Target => _target;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Enemy>(out Enemy enemy))
            Physics2D.IgnoreCollision(collision.otherCollider, collision.collider);
    }

    public void Init(Player target)
    {
        _target = target;

        _stateMachine.Init(_target);
    }

    public void ApplyDamage(int damage)
    {
        if (damage < 0)
            throw new System.ArgumentOutOfRangeException();

        if (_health - damage <= 0)
            Die();

        _health = Mathf.Clamp(_health - damage, 0, _maxHealth);
    }

    private void Die()
    {
        OnDied?.Invoke(this,transform.position);

        Destroy(gameObject);
    }
}

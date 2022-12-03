using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour, IDamageable
{
    public event UnityAction<int> OnHealthChanged;

    [SerializeField] private int _health;

    [SerializeField] private Wallet _wallet;
    [SerializeField] private WeaponBag _weaponBag;

    private int _maxHealth = 100;

    public WeaponBag WeaponBag => _weaponBag;
    public Wallet Wallet => _wallet;
    public bool IsDead => _health <= 0;
    public int MaxHealth => _maxHealth;
    
    public void ApplyDamage(int damage)
    { 
        if(damage < 0)
            throw new System.ArgumentOutOfRangeException();

        _health -= damage;

        Mathf.Clamp(_health, 0, _maxHealth);

        if (_health == 0)
            Die();

        OnHealthChanged?.Invoke(_health);
    }
    
    private void Die()
    {
        Destroy(gameObject);
    }    
}

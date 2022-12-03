using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.Events;

public abstract class Weapon : MonoBehaviour
{
    public static event UnityAction OnMakeDamage;

    [SerializeField] private string _lable;
    [SerializeField] private int _damage;
    [SerializeField] private int _price;
    [SerializeField] private Sprite _icon;
    [SerializeField] private bool _isBought;
    [SerializeField] private float _timeBetweenShots;

    private float _shotTimer;

    public string Lable => _lable;
    public int Price => _price;
    public Sprite Icon => _icon;

    public float TimeBetweenShots => _timeBetweenShots;
    public bool IsBought => _isBought;
    public bool IsAbleToMakeDamage => _shotTimer > _timeBetweenShots;    
    protected int Damage => _damage;
       
    private void Update()
    {
        _shotTimer += Time.deltaTime;
    }

    public virtual void MakeDamage(Vector2 direction)
    {
        OnMakeDamage?.Invoke();
        _shotTimer = 0;                
    }

    public void SetBought()
    {
        _isBought = true;
    }
}





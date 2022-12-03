using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.Events;

public class Wallet : MonoBehaviour
{
    public event UnityAction OnMoneyChanged;

    [SerializeField] private int _money;

    public int Money => _money;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Coin>(out Coin coin))
            CollectMoney();
    }

    public void Pay(int price)
    {
        if (price < 0)
            throw new System.ArgumentOutOfRangeException();

        if (_money - price < 0)
            throw new System.ArgumentOutOfRangeException();

        _money -= price;

        OnMoneyChanged?.Invoke();
    }

    private void CollectMoney()
    {
        _money++;
        OnMoneyChanged?.Invoke();
    }   
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class MoneyBar : MonoBehaviour
{
    [SerializeField] private Wallet _wallet;

    private TMP_Text _text;

    private void Awake()
    {
        _text = GetComponent<TMP_Text>();
    }

    private void OnEnable()
    {
        _wallet.OnMoneyChanged += ChangeBarValue;

        _text.text = _wallet.Money.ToString();
    }

    private void OnDisable()
    {
        _wallet.OnMoneyChanged -= ChangeBarValue;
    }

    private void ChangeBarValue()
    {
        _text.text = _wallet.Money.ToString(); 
    }
}

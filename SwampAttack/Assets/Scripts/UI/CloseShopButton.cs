using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class CloseShopButton : MonoBehaviour
{
    [SerializeField] private Shop _shop;

    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(CloseShop);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(CloseShop);
    }

    private void CloseShop()
    {
        _shop.gameObject.SetActive(false);
    }
}

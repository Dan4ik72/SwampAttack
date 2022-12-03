using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class WeaponView : MonoBehaviour
{
    public event UnityAction<Weapon, WeaponView> OnTryToBuyWeapon;

    [SerializeField] private TMP_Text _price;
    [SerializeField] private Image _icon;
    [SerializeField] private TMP_Text _lable;
    [SerializeField] private Button _sellButton;

    private Weapon _weapon;

    private void OnEnable()
    {
        _sellButton.onClick.AddListener(OnSellButtonClick);
    }

    private void OnDisable()
    {
        _sellButton.onClick.RemoveListener(OnSellButtonClick);
    }

    public void Init(Weapon weapon)
    {
        _weapon = weapon;

        _price.text = weapon.Price.ToString();
        _icon.sprite = weapon.Icon;
        _lable.text = weapon.Lable;

        _sellButton.interactable = !_weapon.IsBought;
    }

    public void DisableSellButtonInteractivity()
    {
        _sellButton.interactable = false;
    }

    private void OnSellButtonClick()
    {
        OnTryToBuyWeapon.Invoke(_weapon, this); 
    }
}

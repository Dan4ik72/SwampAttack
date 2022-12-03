using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private List<Weapon> _weapons;
    [SerializeField] private Player _player;
    [SerializeField] private WeaponView _template;    
    [SerializeField] private GameObject _itemContainer;
    
    private HashSet<Weapon> _uniqWeapons;

    private void Start()
    {
        _uniqWeapons = _weapons.ToHashSet();
        
        foreach(var weapon in _uniqWeapons)
        {
            AddItem(weapon);
        }
    }

    private void TryToSell(Weapon weapon, WeaponView weaponView)
    {
        if (weapon.IsBought == false && _player.Wallet.Money >= weapon.Price)
        {
            _player.Wallet.Pay(weapon.Price);

            _player.WeaponBag.AddWeapon(weapon);
            weapon.SetBought();

            weaponView.DisableSellButtonInteractivity();

            weaponView.OnTryToBuyWeapon -= TryToSell;
        }
    }

    private void AddItem(Weapon weapon)
    {
        var created = Instantiate(_template, _itemContainer.transform);

        created.Init(weapon);

        created.OnTryToBuyWeapon += TryToSell;
    }
}

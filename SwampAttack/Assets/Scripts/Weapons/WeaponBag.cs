using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WeaponBag : MonoBehaviour
{
    public event UnityAction<Weapon> OnCurrentWeaponChanged;

    [SerializeField] private List<Weapon> _availableWeapons;

    [SerializeField] private Weapon _currentWeapon;

    private int _currentWeaponNumber;

    public Weapon CurrentWeapon => _currentWeapon;

    private void Awake()
    {
        ChangeWeapon(_availableWeapons[0]);
    }

    public void AddWeapon(Weapon weapon)
    {
        _availableWeapons.Add(weapon);
    }

    public void SetNextWeapon()
    {
        if (_currentWeaponNumber == _availableWeapons.Count - 1)
            _currentWeaponNumber = 0;
        else
            _currentWeaponNumber++;

        ChangeWeapon(_availableWeapons[_currentWeaponNumber]);
    }

    public void SetPreviousWeapon()
    {
        if (_currentWeaponNumber == 0)
            _currentWeaponNumber = _availableWeapons.Count - 1;
        else
            _currentWeaponNumber--;

        ChangeWeapon(_availableWeapons[_currentWeaponNumber]);
    }

    private void ChangeWeapon(Weapon weapon)
    {
        _currentWeapon = weapon;

        OnCurrentWeaponChanged?.Invoke(_currentWeapon);
    }
}

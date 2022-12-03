using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class CurrentWeaponView : MonoBehaviour
{
    [SerializeField] private WeaponBag _weaponBag;

    private Image _currentWeaponIcon;

    private void Awake()
    {
        _currentWeaponIcon = GetComponent<Image>();
    }

    private void OnEnable()
    {
        _weaponBag.OnCurrentWeaponChanged += SetIcon;
    }

    private void OnDisable()
    {
        _weaponBag.OnCurrentWeaponChanged -= SetIcon;
    }

    private void Start()
    {
        SetIcon(_weaponBag.CurrentWeapon);
    }

    private void SetIcon(Weapon weapon)
    {
        _currentWeaponIcon.sprite = weapon.Icon;
    }
}

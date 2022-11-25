using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ObjectPool))]
public class ShotGun : Weapon, IShootable
{
    [SerializeField] private Bullet _bullet;
    [SerializeField] private Transform _shotPoint;
    [SerializeField] private int _ammoCapacity;

    private ObjectPool _bullets;

    private void OnEnable()
    {
        if (IsBought)
        {
            _bullets = GetComponent<ObjectPool>();

            _bullets.Create(_bullet.gameObject, _ammoCapacity);
        }
    }

    public override void MakeDamage(Vector2 direction)
    {
        if (IsAbleToMakeDamage)
        {
            base.MakeDamage(direction);
            Shoot(direction);
        }
    }

    public void Shoot(Vector2 direction)
    {
        bool isAbleToShoot = _bullets.TryGetObject(out GameObject bullet);

        if (isAbleToShoot)
        {   
            bullet.transform.position = _shotPoint.position;
            bullet.GetComponent<Bullet>().Init(Damage, direction);
            bullet.SetActive(true);
        }
    }
}

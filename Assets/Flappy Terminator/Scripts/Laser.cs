using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Laser : Weapon
{
    private Bullet _bullet;
    private Quaternion _startRotation;
    private float _timeDestroyBullet = 1f;

    private void Awake()
    {
        _startRotation = transform.rotation;
        
        if (TryGetComponent(out Enemy enemy))
        {
            StartCoroutine(DestroyBullet());
        }
    }

    private void Update()
    {
        Shoot();
    }

    public void Reset()
    {
        Bullet[] bullets = FindObjectsOfType<Bullet>();

        for (int i = 0; i < bullets.Length; i++)
        {
            Destroy(bullets[i].gameObject);
        }
    }

    protected override void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            _bullet = Instantiate(Bullet, transform.position, _startRotation);
            _bullet.GetShip(GetComponentInParent<Ship>());
        }
    }

    private IEnumerator DestroyBullet()
    {
        var wait = new WaitForSeconds(_timeDestroyBullet);

        while (enabled)
        {
            _bullet = Instantiate(Bullet, transform.position, _startRotation);

            yield return wait;
        }
    }
}
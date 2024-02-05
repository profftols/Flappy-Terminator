using System;
using UnityEngine;

public class Bullet : MonoBehaviour, IInteractable
{
    public bool IsShipShoot;
    private float shotForce = 7f;
    private Ship _ship;

    private void Awake()
    {
        Rigidbody2D bulletRigidbody = GetComponent<Rigidbody2D>();

        if (IsShipShoot)
        {
            bulletRigidbody.AddForce(transform.up * shotForce, ForceMode2D.Impulse);
        }
        else
        {
            bulletRigidbody.AddForce(-transform.up * shotForce, ForceMode2D.Impulse);
        }
    }
    
    public Ship GetShip(Ship ship)
    {
        return _ship = ship;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out Enemy enemy))
        {
            if (IsShipShoot)
            {
                _ship.KillEnemy(enemy);
                Destroy(gameObject);
            }
        }
    }
}
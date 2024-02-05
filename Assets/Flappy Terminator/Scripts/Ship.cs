using System;
using UnityEngine;

[RequireComponent(typeof(Mover))]
[RequireComponent(typeof(ScoreCounter))]
[RequireComponent(typeof(ShipCollisionHandler))]
public class Ship : MonoBehaviour
{
    private Mover _mover;
    private ShipCollisionHandler _handler;
    private ScoreCounter _scoreCounter;
    
    public event Action GameOver;

    private void Awake()
    {
        _handler = GetComponent<ShipCollisionHandler>();
        _scoreCounter = GetComponent<ScoreCounter>();
        _mover = GetComponent<Mover>();
    }

    private void OnEnable()
    {
        _handler.CollisionDetected += ProcessCollision;
    }

    private void OnDisable()
    {
        _handler.CollisionDetected -= ProcessCollision;
    }

    public void Reset()
    {
        _mover.Reset();
        _scoreCounter.Reset();
    }

    private void ProcessCollision(IInteractable interactable)
    {
        if (interactable is Enemy)
        {
            GameOver?.Invoke();
        }
        else if (interactable is Wall)
        {
            GameOver?.Invoke();
        }
        else if (interactable is Bullet)
        {
            Bullet bullet = interactable as Bullet;
            
            if (!bullet.IsShipShoot)
            {
                GameOver?.Invoke();
                Destroy(bullet.gameObject);
            }
        }
    }

    public void KillEnemy(Enemy enemy)
    {
        _scoreCounter.Add();
        Destroy(enemy.gameObject);
    }
}

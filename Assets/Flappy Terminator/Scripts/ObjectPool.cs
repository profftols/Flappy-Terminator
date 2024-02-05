using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private Transform _container;
    [SerializeField] private Enemy _prefabEnemy;

    private Queue<Enemy> _pools;
    
    public IEnumerable<Enemy> PooledObjects => _pools;

    private void Awake()
    {
        _pools = new Queue<Enemy>();
    }

    public Enemy GetObject()
    {
        if (_pools.Count == 0)
        {
            var enemy = Instantiate(_prefabEnemy);
            enemy.transform.parent = _container;

            return enemy;
        }
        
        return _pools.Dequeue();
    }

    public void PutObject(Enemy enemy)
    {
        _pools.Enqueue(enemy);
        enemy.gameObject.SetActive(false);
    }
}

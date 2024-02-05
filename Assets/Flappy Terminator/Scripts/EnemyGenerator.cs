using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] private float _delay;
    [SerializeField] private float _lowerBound;
    [SerializeField] private float _upperBound;
    [SerializeField] private ObjectPool _pool;
    
    private Queue<Enemy> _pools;
    private bool isFirstStart = true;

    private void Start()
    {
        _pools = new Queue<Enemy>();
        StartCoroutine(GenerateEnemy());
    }

    public void Reset()
    {
        for (int i = 0; i < _pools.Count; i++)
        {
            Destroy(_pools.Dequeue().gameObject);
        }
    }

    private IEnumerator GenerateEnemy()
    {
        var wait = new WaitForSeconds(_delay);

        while (enabled)
        {
            Spawn();
            yield return wait;
        }
    }

    private void Spawn()
    {
        if (isFirstStart)
        {
            isFirstStart = false;
        }
        else
        {
            float spawnPositionY = Random.Range(_upperBound, _lowerBound);
            Vector3 spawnPoint = new Vector3(transform.position.x, spawnPositionY, transform.position.z);

            var enemy = _pool.GetObject();

            enemy.gameObject.SetActive(true);
            enemy.transform.position = spawnPoint;
            _pools.Enqueue(enemy);
        }
    }
}

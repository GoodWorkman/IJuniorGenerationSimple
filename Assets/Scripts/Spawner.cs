using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Mover _enemyPrefab;

    private readonly List<Transform> _spawnPoints = new();

    private float _timeToLive = 5f;

    private void Start()
    {
        foreach (Transform child in transform)
        {
            _spawnPoints.Add(child);
        }

        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(2f);
        
        while (gameObject.activeInHierarchy)
        {
            yield return waitForSeconds;

            Transform spawnPoint = _spawnPoints[Random.Range(0, _spawnPoints.Count)];

            Mover newEnemy = Instantiate(_enemyPrefab, spawnPoint.position, spawnPoint.rotation);
            
            Destroy(newEnemy.gameObject, _timeToLive);
        }
    }
}

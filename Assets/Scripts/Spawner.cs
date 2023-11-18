using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Mover _enemyPrefab;

    private readonly List<Transform> _spawnPoints = new();

    private float _timeToLive = 5f;
    private float _delayTime = 2f;

    private Vector3 _direction;

    private void Start()
    {
        foreach (Transform child in transform)
        {
            _spawnPoints.Add(child);
        }

        _direction = transform.forward;

        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(_delayTime);
        
        while (gameObject.activeInHierarchy)
        {
            yield return waitForSeconds;

            Transform spawnPoint = _spawnPoints[Random.Range(0, _spawnPoints.Count)];

            Mover newEnemy = Instantiate(_enemyPrefab, spawnPoint.position, spawnPoint.rotation);
            
            newEnemy.SetDirection(_direction);
            
            Destroy(newEnemy.gameObject, _timeToLive);
        }
    }
}

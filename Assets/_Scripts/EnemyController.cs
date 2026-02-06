using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class EnemyController : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField]
    private GameObject _enemy;
    [SerializeField]
    private List<Transform> _spawnPoints;
    [SerializeField]
    private TextMeshProUGUI _killText;

    [Header("Balancing")]
    [SerializeField]
    private int _enemyCount = 5;
    [SerializeField]
    private int _killCount = 0;
    [SerializeField]
    private float _enemySpeed = 1f;
    
    private Transform _playerTransform;
    private Weapon _weaponTransform;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _playerTransform = FindAnyObjectByType<Player>().transform;
        _weaponTransform = FindAnyObjectByType<Weapon>();
        UpdateUI();

        for (int i = 0; i < _enemyCount; i++)
        {
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        if (_spawnPoints.Count == 0) return;
        int randomIndex = Random.Range(0, _spawnPoints.Count);
        Vector3 spawnPosition = _spawnPoints[randomIndex].position + (Vector3)Random.insideUnitCircle;
        GameObject enemy = Instantiate(_enemy, spawnPosition, Quaternion.identity);
        Enemy enemyObject = enemy.GetComponent<Enemy>();
        
        enemyObject.Setup(_enemySpeed, _playerTransform);
        enemyObject.OnDie += HandleEnemyDeath;
    }

    private void HandleEnemyDeath() 
    {
        _killCount++;
        UpdateUI();

        SpawnEnemy();

        if (_killCount % 3 == 0) 
        {
            _enemySpeed += 0.5f;
            if (_weaponTransform != null) 
            {
                _weaponTransform.UpRotationSpeed(50);
            }
        } 
        
        if (_killCount % 5 == 0) 
        {
            _enemyCount++; 
            SpawnEnemy(); 
        }
    }

    // private Vector3 SelectSpawnPosition()
    // {
    //     Transform selectedTransform = null;
    //     int randomSpawn = Random.Range(0, 4);
    //     SpawnPosition spawnPosition = (SpawnPosition)randomSpawn;
    //     switch (spawnPosition)
    //     {
    //         case SpawnPosition.TopLeft:
    //             selectedTransform = _spawnTopLeft;
    //             break;
    //         case SpawnPosition.BottomRight:
    //             selectedTransform = _spawnBottomRight;
    //             break;
    //         case SpawnPosition.TopRight:
    //             selectedTransform = _spawnTopRight;
    //             break;
    //         case SpawnPosition.BottomLeft:
    //             selectedTransform = _spawnBottomLeft;
    //             break;
    //     }
    //     return selectedTransform.position + (Vector3)Random.insideUnitCircle;
    // }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void UpdateUI() 
    {
        if (_killText != null) 
        {
            _killText.text = "Kills: " + _killCount;
        }
    }
}

// public enum SpawnPosition
// {
//     TopLeft,
//     BottomRight,
//     TopRight,
//     BottomLeft
// }

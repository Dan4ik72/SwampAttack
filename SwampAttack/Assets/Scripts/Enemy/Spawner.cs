using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
    public event UnityAction OnUnitSpawned;
    public event UnityAction OnWaveStarted;
    public event UnityAction OnWaveEnded;

    [SerializeField] private List<Wave> _waves;
    [SerializeField] private Player _target;
    [SerializeField] private CoinSpawner _rewardSpawner;

    private Wave _currentWave;

    private int _currentWaveNumber = 0;
    private float _timeAfterLastSpawn;
    private int _spawnedCount;

    public Wave CurrentWave => _currentWave;
    public int SpawnedCount => _spawnedCount;
    
    private void Update()
    {
        if (_currentWave == null)
            return;

        _timeAfterLastSpawn += Time.deltaTime;

        if( _timeAfterLastSpawn >= _currentWave.DelayBetweenSpawns)
        {
            _timeAfterLastSpawn = 0;

            SpawnUnit();
            _spawnedCount++;
        }

        if (_spawnedCount == _currentWave.Count)
        {
            _currentWave = null;

            _spawnedCount = 0;
            _currentWaveNumber++;

            OnWaveEnded?.Invoke();
        }
    }

    public void TryToStartNextWave()
    {
        if (_currentWaveNumber < _waves.Count)
        {
            SetWave(_currentWaveNumber);
            OnWaveStarted?.Invoke();
        }
    }

    private void SetWave(int waveIndex)
    {
        _currentWave = _waves[waveIndex];
        OnWaveStarted?.Invoke();
    }

    private void SpawnUnit()
    {
        var enemy = Instantiate(_currentWave.Unit, transform.position, Quaternion.identity, transform).GetComponent<Enemy>();

        InitSpawnedUnit(enemy);

        OnUnitSpawned?.Invoke();
    }    

    private void InitSpawnedUnit(Enemy spawnedUnit)
    {
        spawnedUnit.Init(_target);

        spawnedUnit.OnDied += SpawnRewardForDiedUnit;
    }

    private void SpawnRewardForDiedUnit(Enemy deadEnemy, Vector3 diedPosition)
    {
        _rewardSpawner.SpawnCoin(deadEnemy.Reward, diedPosition);
    }
}

[System.Serializable]
public class Wave
{
    [SerializeField] private GameObject _unit;
    [SerializeField] private float _delayBetweenSpawns;
    [SerializeField] private int _count;

    public GameObject Unit => _unit;
    public float DelayBetweenSpawns => _delayBetweenSpawns;
    public int Count => _count;
}

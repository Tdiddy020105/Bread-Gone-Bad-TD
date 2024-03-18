using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public event EventHandler OnWaveNumberChanged;

    private enum WaveState
    {
        WaitingToSpawnNextWave,
        SpawningWave,
    }

    [SerializeField] private List<Transform> spawnPositionTransformList;
    [SerializeField] private Transform nextWaveSpawnPositionTransform;

    private WaveState waveState;
    private int waveNumber;
    private float nextWaveSpawnTimer;
    private float nextEnemySpawnTimer;
    private int remainingEnemySpawnAmount;
    private Vector3 spawnPosition;

    private void Start()
    {
        waveState = WaveState.WaitingToSpawnNextWave;
        spawnPosition = spawnPositionTransformList[UnityEngine.Random.Range(0, spawnPositionTransformList.Count)].position;
        nextWaveSpawnPositionTransform.position = spawnPosition;
        nextWaveSpawnTimer = 3f;
    }

    private void Update()
    {
        switch (waveState)
        {
            case WaveState.WaitingToSpawnNextWave:
                nextWaveSpawnTimer -= Time.deltaTime;
                if(nextWaveSpawnTimer < 0f)
                {
                    SpawnWave();
                }
                break;
            case WaveState.SpawningWave:
                if(remainingEnemySpawnAmount > 0)
                {
                    nextWaveSpawnTimer -= Time.deltaTime;
                    if(nextEnemySpawnTimer < 0f)
                    {
                        nextEnemySpawnTimer = UnityEngine.Random.Range(0f, 2f);
                        //TODO Spawn enemy with enemy class
                        remainingEnemySpawnAmount--;

                        if(remainingEnemySpawnAmount <= 0)
                        {
                            waveState = WaveState.WaitingToSpawnNextWave;
                            spawnPosition = spawnPositionTransformList[UnityEngine.Random.Range(0, spawnPositionTransformList.Count)].position;
                            nextWaveSpawnPositionTransform.position = spawnPosition;
                            nextWaveSpawnTimer = 10f;
                        }
                    }
                }
                break;
        }
    }

    private void SpawnWave()
    {
        remainingEnemySpawnAmount = 3 + 2 * waveNumber;
        waveState = WaveState.SpawningWave;
        waveNumber++;

    }
}

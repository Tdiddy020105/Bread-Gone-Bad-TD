using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public event EventHandler OnWaveNumberChanged;
    
    

    //Temporary placeholder for the EnemySpawn script as object reference
    
    public EnemySpawn enemySpawn;
    
    private enum WaveState
    {
        WaitingToSpawnNextWave,
        SpawningWave,
        BossWave,
    }

    //[SerializeField] private List<Transform> spawnPositionTransformList;
    //[SerializeField] private Transform nextWaveSpawnPositionTransform;

    private WaveState waveState;
    private int waveNumber;
    private float nextWaveSpawnTimer;
    private float nextEnemySpawnTimer = 2f;
    private int remainingEnemySpawnAmount;
    [SerializeField] private Vector3 spawnPosition;

    private void Start()
    {
        Debug.Log("Start");
        
        waveState = WaveState.WaitingToSpawnNextWave;
        Debug.Log(waveState.ToString());
        //spawnPosition = spawnPositionTransformList[UnityEngine.Random.Range(0, spawnPositionTransformList.Count)].position;
        //nextWaveSpawnPositionTransform.position = spawnPosition;
        nextWaveSpawnTimer = 3f;
    }

    private void Update()
    {
        //Debug.Log("WaveNumber: " + waveNumber);
        switch (waveState)
        {
            case WaveState.WaitingToSpawnNextWave:
                //Debug.Log(nextWaveSpawnTimer);
                nextWaveSpawnTimer -= Time.deltaTime;
                if(nextWaveSpawnTimer < 0f)
                {
                    Debug.Log("Spawning wave");
                    SpawnWave();
                }
                break;
            case WaveState.SpawningWave:
                //Debug.Log(remainingEnemySpawnAmount);
                if(remainingEnemySpawnAmount > 0)
                {
                    //Debug.Log(nextEnemySpawnTimer);
                    nextEnemySpawnTimer -= Time.deltaTime;
                    if(nextEnemySpawnTimer < 0f)
                    {
                        //Debug.Log("Hier");
                        nextEnemySpawnTimer = 1f;
                        //Uses the EnemySpawn script which instantiates a copy of the current enemy prefab using spawnPosition as vector3
                        enemySpawn.Spawn(spawnPosition);
                        remainingEnemySpawnAmount--;

                        if(remainingEnemySpawnAmount <= 0)
                        {
                            Debug.Log("Alle enemies zijn gespawnd");
                            waveState = WaveState.WaitingToSpawnNextWave;
                            //spawnPosition = spawnPositionTransformList[UnityEngine.Random.Range(0, spawnPositionTransformList.Count)].position;
                            //nextWaveSpawnPositionTransform.position = spawnPosition;
                            nextWaveSpawnTimer = 5f;
                        }
                    }
                }
                break;
            case WaveState.BossWave: 
                Debug.Log("Spawning Boss wave");
                enemySpawn.SpawnBoss();
                waveState = WaveState.WaitingToSpawnNextWave;
                nextWaveSpawnTimer = 10f;
                break;
        }
    }

    private void SpawnWave()
    {
        waveNumber++;
        bool check = (waveNumber % 5) == 0;
        if(check == true)
        {
            waveState = WaveState.BossWave;
        }
        else
        {
            remainingEnemySpawnAmount = 3 + 2 * waveNumber;
            waveState = WaveState.SpawningWave;
        }
        
        Debug.Log(waveState.ToString());
        

    }
}

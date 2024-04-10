using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.EnemyPool
{
    public class WaveManager : MonoBehaviour
    {
        public event EventHandler OnWaveNumberChanged;
        public static event Action OnEnemiesDefeated;

        //Temporary placeholder for the EnemySpawn script as object reference
        public EnemySpawn enemySpawn;

        private enum WaveState
        {
            WaitingToSpawnNextWave,
            SpawningWave,
            BossWave,
            Waiting,
        }

        [SerializeField] private List<Transform> spawnPositionTransformList;
        [SerializeField] private Transform nextWaveSpawnPositionTransform;

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
            spawnPosition = spawnPositionTransformList[UnityEngine.Random.Range(0, spawnPositionTransformList.Count)].position;
            nextWaveSpawnPositionTransform.position = spawnPosition;

            OnEnemiesDefeated += HandleEnemiesDefeated;
            EnemySpawn.OnEnemiesKilled += CheckEnemyList;

            nextWaveSpawnTimer = 3f;

        }

        private void Update()
        {
            switch (waveState)
            {
                case WaveState.WaitingToSpawnNextWave:
                    nextWaveSpawnTimer -= Time.deltaTime;
                    if (nextWaveSpawnTimer < 0f)
                    {
                        Debug.Log("Spawning wave");
                        SpawnWave();
                    }


                    break;

                case WaveState.SpawningWave:
                    if (remainingEnemySpawnAmount > 0)
                    {
                        nextEnemySpawnTimer -= Time.deltaTime;
                        if (nextEnemySpawnTimer < 0f)
                        {
                            nextEnemySpawnTimer = 1f;
                            //Uses the EnemySpawn script which instantiates a copy of the current enemy prefab using spawnPosition as vector3
                            enemySpawn.Spawn(spawnPosition);
                            remainingEnemySpawnAmount--;

                            if (remainingEnemySpawnAmount <= 0)
                            {
                                waveState = WaveState.Waiting;
                                spawnPosition = spawnPositionTransformList[UnityEngine.Random.Range(0, spawnPositionTransformList.Count)].position;
                                nextWaveSpawnPositionTransform.position = spawnPosition;
                                nextWaveSpawnTimer = 5f;

                            }
                        }
                    }
                    break;

                case WaveState.BossWave:
                    Debug.Log("Spawning Boss wave");
                    enemySpawn.SpawnBoss();
                    waveState = WaveState.Waiting;
                    nextWaveSpawnTimer = 10f;
                    break;

                case WaveState.Waiting:
                    //TODO enemyRemove toepassen

                    //Debug.Log("Stuck here");
                    break;
            }
        }

        private void SpawnWave()
        {
            waveNumber++;
            bool check = (waveNumber % 5) == 0;
            //if (check)
            //{
                //waveState = WaveState.BossWave;
            //}
                remainingEnemySpawnAmount = 3 + 2 * waveNumber;
                waveState = WaveState.SpawningWave;
            
        }

        private void HandleEnemiesDefeated()
        {
            Debug.Log("All enemies are defeated!");
            waveState = WaveState.WaitingToSpawnNextWave;
        }

        private void CheckEnemyList()
        {
            Debug.Log(remainingEnemySpawnAmount);
            if (remainingEnemySpawnAmount <= 0)
            {
                
                if (enemySpawn.Enemies.Count == 0)
                {
                    OnEnemiesDefeated();
                    Debug.Log("Enemies defeated!");
                }
            }
        }

        void OnDestroy()
        {
            // Unsubscribe from the event to avoid memory leaks
            OnEnemiesDefeated -= HandleEnemiesDefeated;
            EnemySpawn.OnEnemiesKilled -= CheckEnemyList;
        }

        public int GetWaveNumber()
        {
            return waveNumber;
        }
    }

}

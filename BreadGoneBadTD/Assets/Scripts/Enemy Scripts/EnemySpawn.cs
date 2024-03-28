using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class EnemySpawn : MonoBehaviour
    {
        // Reference to the Enemy Prefab. Drag a Prefab into this field in the Inspector.
        [SerializeField] private PooledObject enemyToPool;
        public GameObject bossPrefab;

        // Start is called before the first frame update
        void Start()
        {
            for(int i = 0; i < enemyToPool.maxSize; i++){
                enemyToPool.CreateEnemy();
            }
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        public void Spawn()
        {
            Spawn(new Vector3(-9f, 0f, 0f)); // Default spawn position
        }

        public void Spawn(Vector3 SpawnPosition)
        {
            PooledObject enemyInstance = enemyToPool.Spawn(); // WIP
            enemyInstance.gameObject.transform.position = SpawnPosition;
            enemyInstance.gameObject.SetActive(true);
            
        }

        public void SpawnBoss()
        {
            SpawnBoss(new Vector3(1,1,0));
        }

        public void SpawnBoss(Vector3 SpawnPositionBoss)
        {
            Instantiate(bossPrefab, SpawnPositionBoss, Quaternion.identity);
        }
    }


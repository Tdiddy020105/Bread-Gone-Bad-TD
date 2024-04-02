using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;


    public class EnemySpawn : MonoBehaviour
    {
        // Reference to the Enemy Prefab. Drag a Prefab into this field in the Inspector.
        public GameObject enemyPrefab;


        
        public GameObject bossPrefab;
        public static ObjectPool<GameObject> SharedInstance;
        public List<GameObject> pooledObjects;
        public GameObject objectToPool;
        public int amountToPool;


        // Start is called before the first frame update
        void Start()
        {
            pooledObjects = new List<GameObject>();
            GameObject tmp;
            for(int i = 0; i < amountToPool; i++)
            {
                tmp = Instantiate(objectToPool);
                tmp.SetActive(false);
                pooledObjects.Add(tmp);
            }
        }

        private void Awake()
        {
            
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
            //Gets an already existing enemy from CreateEnemy() through objectPool.OnGetFromPool which.. makes a new enemy?
            GameObject enemy = GetPooledObject(); 
            if (enemy != null) {
                enemy.transform.position = SpawnPosition;
                enemy.SetActive(true);
            }
            
        }


        public void SpawnBoss()
        {
            SpawnBoss(new Vector3(1,1,0));
        }

        public void SpawnBoss(Vector3 SpawnPositionBoss)
        {
            Instantiate(bossPrefab, SpawnPositionBoss, Quaternion.identity);
        }

        public GameObject GetPooledObject()
        {
            for(int i = 0; i < amountToPool; i++)
            {
                if(!pooledObjects[i].activeInHierarchy)
                {
                    return pooledObjects[i];
                }
            }
            return null;
        }
    }


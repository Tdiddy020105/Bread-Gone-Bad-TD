using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;


    public class EnemySpawn : MonoBehaviour
    {
        // Reference to the Enemy Prefab. Drag a Prefab into this field in the Inspector.
        public IObjectPool<PooledObject> objectPool;
        [SerializeField] private PooledObject enemyPrefab;

        // public property to give the enemy a reference to its ObjectPool
        
        public GameObject bossPrefab;

        // throw an exception if we try to return an existing item, already in the pool
        [SerializeField] private bool collectionCheck = true;

        // extra options to control the pool capacity and maximum size
        [SerializeField] public int defaultCapacity = 20;
        [SerializeField] public int maxSize = 100;


        // Start is called before the first frame update
        void Start()
        {
            for(int i = 0; i < maxSize; i++){
                CreateEnemy();
            }
        }

        private void Awake()
        {
            objectPool = new ObjectPool<PooledObject>(CreateEnemy,
                OnGetFromPool, OnReleaseToPool, OnDestroyPooledObject,
                collectionCheck, defaultCapacity, maxSize);
 
        }



        // invoked when returning an item to the object pool
        public void OnReleaseToPool(PooledObject enemyObject)
        {
            enemyObject.gameObject.SetActive(false);
        }

        // invoked when retrieving the next item from the object pool
        public void OnGetFromPool(PooledObject enemyObject)
        {
            enemyObject.gameObject.SetActive(true);
        }


        // invoked when we exceed the maximum number of pooled items (i.e. destroy the pooled object)
        public void OnDestroyPooledObject(PooledObject enemyObject)
        {
            Destroy(enemyObject.gameObject);
        }

        //Creates the initial pool on Start()
        public PooledObject CreateEnemy()
        {
            PooledObject enemyInstance = Instantiate(enemyPrefab);
            enemyInstance.ObjectPool = objectPool;
            return enemyInstance;
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
            PooledObject pooledObject = objectPool.Get(); // WIP
            pooledObject.gameObject.transform.position = SpawnPosition;
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


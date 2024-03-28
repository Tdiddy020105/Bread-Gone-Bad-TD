using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;


    // projectile revised to use UnityEngine.Pool in Unity 2021
    public class PooledObject : MonoBehaviour
    {

        // stack-based ObjectPool available with Unity 2021 and above
        public IObjectPool<PooledObject> objectPool;

        // public property to give the enemy a reference to its ObjectPool
        public IObjectPool<PooledObject> ObjectPool { set => objectPool = value; }

        

        // throw an exception if we try to return an existing item, already in the pool
        [SerializeField] private bool collectionCheck = true;

        // extra options to control the pool capacity and maximum size
        [SerializeField] public int defaultCapacity = 20;
        [SerializeField] public int maxSize = 100;

        private float nextTimeToShoot;

        private void Awake()
        {
            objectPool = new ObjectPool<PooledObject>(CreateEnemy,
                OnGetFromPool, OnReleaseToPool, OnDestroyPooledObject,
                collectionCheck, defaultCapacity, maxSize);
 
        }



        // invoked when returning an item to the object pool
        public void OnReleaseToPool(PooledObject pooledObject)
        {
            pooledObject.gameObject.SetActive(false);
        }

        // invoked when retrieving the next item from the object pool
        public void OnGetFromPool(PooledObject pooledObject)
        {
            pooledObject.gameObject.SetActive(true);
        }

        public PooledObject Spawn()
        {
                PooledObject enemyObject = objectPool.Get();            
                enemyObject.ObjectPool = objectPool;
                return enemyObject;
                
        }

        // invoked when we exceed the maximum number of pooled items (i.e. destroy the pooled object)
        public void OnDestroyPooledObject(PooledObject pooledObject)
        {
            Destroy(pooledObject.gameObject);
        }

        public PooledObject CreateEnemy()
        {
            PooledObject enemyInstance = Instantiate(this);
            enemyInstance.ObjectPool = objectPool;
            return enemyInstance;
        }
    }

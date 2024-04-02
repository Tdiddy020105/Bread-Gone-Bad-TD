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


    }

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.EnemyPool
{
public class PooledObject : MonoBehaviour
{
    private EnemyPool pool;
    public EnemyPool Pool { get => pool; set => pool = value; }

    public void Release()
    {
        pool.ReturnToPool(this);
    }
}
}
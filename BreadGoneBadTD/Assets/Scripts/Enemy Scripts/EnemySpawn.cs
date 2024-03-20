using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    // Reference to the Enemy Prefab. Drag a Prefab into this field in the Inspector.
    public GameObject enemyPrefab;

    // Start is called before the first frame update
    void Start()
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
        Instantiate(enemyPrefab, SpawnPosition, Quaternion.identity);
    }
}

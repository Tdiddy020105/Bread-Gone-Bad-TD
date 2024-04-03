using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Achievements : MonoBehaviour
{

    [SerializeField] private EnemySpawn enemyScript;
    [SerializeField] private Map mapScript;

    private bool enemyTrackerTrue = false;

    private bool towerTrackerTrue = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        EnemyTracker();
        TowerTracker();
    }

    void EnemyTracker(){
       
        if(enemyScript.enemiesDefeated == 3){  
            if(enemyTrackerTrue == false){
                Debug.Log("Achievement unlocked! On a roll.");
                enemyTrackerTrue = true;
            }
        }
    }

    void TowerTracker(){
       
        if(mapScript.towersPlaced == 3){  
            if(enemyTrackerTrue == false){
                Debug.Log("Achievement unlocked! Bready for action.");
                enemyTrackerTrue = true;
            }
        }
    }

}

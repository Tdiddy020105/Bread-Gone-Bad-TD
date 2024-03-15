using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BakeryScript : MonoBehaviour
{

    [SerializeField] public int health;
    
    //Quick dev thing to not swamp the debug log on a done game
    int DebugLogCheck = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(health <= 0)
       {
        if(DebugLogCheck == 0)
        {
            Debug.Log("Game over!");
            DebugLogCheck = 1;
        }

       } 
    }
}

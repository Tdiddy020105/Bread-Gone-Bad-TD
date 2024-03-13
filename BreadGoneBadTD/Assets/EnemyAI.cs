using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{

    [SerializeField] private UnityEngine.AI.NavMeshAgent agent;
    [SerializeField] private Transform target;

    // Start is called before the first frame update
    void Start()
    {
        if(transform.position.x == 0.0f){
            transform.position = new Vector3(0.1f, transform.position.y, transform.position.z);
        }
		agent.updateRotation = false;
		agent.updateUpAxis = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null )
        {
            agent.SetDestination(target.position);    
        }
    }
}

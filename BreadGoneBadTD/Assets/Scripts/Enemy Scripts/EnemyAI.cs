using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{

    [SerializeField] private UnityEngine.AI.NavMeshAgent agent;
    [SerializeField] private GameObject target;
    [SerializeField] private int attack;
    [SerializeField] private int health; 

    [SerializeField] private GameObject player;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        // Messy fix to agent.SetDestination taking a few seconds to register at X poition 0, for some reason
        if(transform.position.x == 0.0f){
            transform.position = new Vector3(0.1f, transform.position.y, transform.position.z);
        }
        //Stops the agent from rotating as it often likes to do before setting a destination; causing it to rotate out of the game in 2D.
		agent.updateRotation = false;
		agent.updateUpAxis = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null )
        {
            agent.SetDestination(target.transform.position);    
        }

        if (this.health <= 0)
        {
            Destroy(this.gameObject);
        }
    }


    private void OnTriggerEnter2D(Collider2D trigger) {
        Debug.Log("Trigger collision!");
        //Check for a match with the specified target on any GameObject with a trigger that collides with your GameObject
        if (trigger.gameObject == target)
        {
            target.GetComponent<BakeryScript>().health -= this.attack;
            Debug.Log("The bakery has been hit for " + this.attack + " damage!");
            Debug.Log("The bakery is at " + target.GetComponent<BakeryScript>().health  + " health.");
            Destroy(this.gameObject);
        }
    }

/*     private void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject == player)
        {
            this.health -= player.GetComponent<WeaponData>().damage;
            Debug.Log(this.name " has been hit for " + player.GetComponent<WeaponData>().damage + " damage!");
            Debug.Log( this.name + " is now at " + this.health  + " health.");
        }
    } */

}

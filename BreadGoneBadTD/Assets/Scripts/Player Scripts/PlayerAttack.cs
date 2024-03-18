using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{

    public WeaponData currentWeapon;
    public Transform attackAreaParent;

    private GameObject currentAttackArea;
    private bool attacking = false;
    private float timetoAttack; // Declare timetoAttack here
    private float timer = 0f;

    public InputActionReference attackAction;

    // Start is called before the first frame update
    void Start()
    {
        InstantiateAttackArea(currentWeapon.attackAreaPrefab);
        timetoAttack = 1f / currentWeapon.attackRate; 
    }

    void Update()
    {
        // Check if the attack action is triggered
        if (attackAction.action.triggered)
        {
            Attack();
        }

        if (attacking)
        {
            timer += Time.deltaTime;

            if (timer >= timetoAttack)
            {
                timer = 0;
                attacking = false;
                currentAttackArea.SetActive(attacking);
            }
        }
    }

    private void Attack()
    {
        attacking = true;
        currentAttackArea.SetActive(attacking);
    }

    private void InstantiateAttackArea(GameObject attackAreaPrefab)
    {
        // Instantiate or enable the attack area prefab based on the current weapon
        if (attackAreaPrefab != null)
        {
            // If an attack area already exists, destroy it first
            if (currentAttackArea != null)
            {
                Destroy(currentAttackArea);
            }
            
            // Instantiate the attack area prefab as a child of the attackAreaParent
            currentAttackArea = Instantiate(attackAreaPrefab, attackAreaParent);
            currentAttackArea.SetActive(false); // Deactivate initially


            //Optional, ask for feedback
            //currentAttackArea.transform.localScale = new Vector3(currentWeapon.range * 2, currentWeapon.range * 2, 1);
        }
        else
        {
            Debug.LogWarning("Attack area prefab is null.");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Enemy attacked");
        // Check if currently attacking and collision is with enemy
        if (attacking && other.CompareTag("MeleeEnemy"))
        {
            // Get the damage value from the current weapon
            int damage = currentWeapon.damage;
            
            // Handle damage
            other.GetComponent<EnemyAI>().TakeDamage(damage);
        }
    }
}

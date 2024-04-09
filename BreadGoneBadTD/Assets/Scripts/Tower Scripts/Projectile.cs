using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Rigidbody2D rb;
    private TowerData towerData;

    private void Start()
{
    // Ensure towerData is assigned from the tower GameObject
    Tower tower = GetComponentInParent<Tower>();
    if (tower != null)
    {
        towerData = tower.towerData;
    }
    else
    {
        Debug.LogError("Tower component not found in parent GameObject hierarchy.");
    }

    // Check if towerData is null before using it
    if (towerData != null)
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * towerData.projectileSpeed;
    }
    else
    {
        Debug.LogError("Tower data not assigned to projectile!");
    }
}


    private void OnTriggerEnter2D(Collider2D other)
    {
        EnemyAI enemy = other.GetComponent<EnemyAI>();

        if (enemy != null)
        {
            enemy.TakeDamage(towerData.attackDamage);
            Destroy(gameObject);
        }
    }
}


using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] public TowerData towerData;
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] public Vector3 projectileSpawnOffset;


    private List<GameObject> enemiesWithinRange = new();
    private float attackTimer = 0.0f;

    private void Start()
    {
        this.GenerateAndApplyAttackRangePerimeterCollider();
    }

    private void Update()
    {
        if (this.enemiesWithinRange.Count == 0)
        {
            this.attackTimer = 0.0f;
            return;
        }

        // Warning: This produces a bug where an enemy that immediately enters and leaves the trigger will always be attacked
        //          This might be removed
        if (this.attackTimer == 0.0f)
        {
            this.AttackEnemies();
        }

        this.attackTimer += Time.deltaTime;

        if (this.attackTimer >= this.towerData.secondsBetweenAttacks)
        {
            this.attackTimer = 0.0f;
        }
    }

    private void AttackEnemies()
    {
        if (towerData.attackType == TowerAttackType.TARGET_FIRST_IN_RANGE)
        {
            GameObject targetEnemy = enemiesWithinRange[0];
            LaunchProjectile(targetEnemy.transform.position);
        }
        else if (towerData.attackType == TowerAttackType.TARGET_ALL_IN_RANGE)
        {
            foreach (GameObject enemy in enemiesWithinRange)
            {
                LaunchProjectile(enemy.transform.position);
            }
        }
    }

    private void OnMouseDown()
    {
        DestroyTower();
    }

    private void DestroyTower()
    {
        Destroy(this);
    }

    public TowerData GetData()
    {
        return this.towerData;
    }

    public void SetData(TowerData towerData)
    {
        this.towerData = towerData;
    }
    private void LaunchProjectile(Vector3 targetPosition)
    {
        // Get the position of the projectile spawn point from TowerData
        Vector3 projectileSpawnPoint = transform.position + towerData.projectileSpawnOffset;

        // Instantiate projectile as a child of the tower
        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity, transform);

        // Calculate direction towards the target position
        Vector2 direction = (targetPosition - projectileSpawnPoint).normalized;
        // Set velocity or apply force to move the projectile towards the target
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = direction * towerData.projectileSpeed;
        }
        // Optionally, you can rotate the projectile to face the target
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        projectile.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }




    #region Enemy detection
    private void OnTriggerEnter2D(Collider2D collider)
    {
        EnemyAI enemy = collider.GetComponent<EnemyAI>();

        if (enemy == null)
        {
            return;
        }

        this.enemiesWithinRange.Add(collider.gameObject);
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        EnemyAI enemy = collider.GetComponent<EnemyAI>();

        if (enemy == null)
        {
            return;
        }

        // WARNING: This could possibly become buggy if we want to implement
        //           some more elaborate pathing that does not respect FIFO.
        this.enemiesWithinRange.RemoveAt(0); // Index 0 actually refers to the first element
    }

    private void GenerateAndApplyAttackRangePerimeterCollider()
    {
        Rect perimeterOutline = PerimeterHelpers.CalculatePerimeterOutline(
            this.gameObject.transform,
            this.towerData.attackRange.x,
            this.towerData.attackRange.y
        );
        BoxCollider2D attackPerimeterCollider = this.AddComponent<BoxCollider2D>();

        attackPerimeterCollider.size = PerimeterHelpers.PerimeterOutlineSizeToLocalTransformSize(
            perimeterOutline,
            this.transform
        );
        attackPerimeterCollider.isTrigger = true;
    }
    #endregion

    #region Debug line drawing
    private void OnDrawGizmos()
    {
        this.DrawAttackPerimeterGizmo();
    }

    private void DrawAttackPerimeterGizmo()
    {
        Rect perimeterOutline = PerimeterHelpers.CalculatePerimeterOutline(
            this.gameObject.transform,
            this.towerData.attackRange.x,
            this.towerData.attackRange.y
        );

        Gizmos.color = Color.red;
        PerimeterHelpers.DrawAttackPerimeterGizmo(perimeterOutline);
    }
    #endregion
}
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private TowerData towerData;

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
        Debug.Log("ATTACK");

        if (this.towerData.attackType == TowerAttackType.TARGET_FIRST_IN_RANGE)
        {
            EnemyAI enemy = this.enemiesWithinRange[0].GetComponent<EnemyAI>();
            enemy?.TakeDamage(this.towerData.attackDamage);

            Debug.Log($"Attack {this.enemiesWithinRange[0].name}");

            return;
        }

        if (this.towerData.attackType == TowerAttackType.TARGET_ALL_IN_RANGE)
        {
            foreach (GameObject gameObject in this.enemiesWithinRange)
            {
                EnemyAI enemy = gameObject.GetComponent<EnemyAI>();
                enemy?.TakeDamage(this.towerData.attackDamage);

                Debug.Log($"Attack {gameObject.name}");
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
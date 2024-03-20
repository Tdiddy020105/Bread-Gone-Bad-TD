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
        this.attackTimer += Time.deltaTime;

        if (this.attackTimer >= this.towerData.secondsBetweenAttacks)
        {
            this.AttackEnemies();
        }
    }

    private void AttackEnemies()
    {
        Debug.Log("ATTACK");

        if (this.towerData.attackType == TowerAttackType.TARGET_FIRST_IN_RANGE)
        {
            EnemyAI enemy = this.enemiesWithinRange[0].GetComponent<EnemyAI>();
            enemy.TakeDamage(this.towerData.attackDamage);

            return;
        }

        if (this.towerData.attackType == TowerAttackType.TARGET_ALL_IN_RANGE)
        {
            foreach (GameObject gameObject in this.enemiesWithinRange)
            {
                EnemyAI enemy = gameObject.GetComponent<EnemyAI>();
                enemy.TakeDamage(this.towerData.attackDamage);
            }
        }
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

using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private TowerData towerData;

    [SerializeField] private List<GameObject> enemiesWithinRange = new();

    private void Start()
    {
        this.GenerateAndApplyAttackRangePerimeterCollider();
    }

    private void Update() {}

    #region Enemy detection
    private void OnTriggerEnter2D(Collider2D collider)
    {
        // TODO: Check that an enemy instance has entered the trigger (So not a generic gameobject like it blindly accepts now)

        this.enemiesWithinRange.Add(collider.gameObject);
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        // TODO: Check that an enemy instance has left the trigger (So not a generic gameobject like it blindly accepts now)

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

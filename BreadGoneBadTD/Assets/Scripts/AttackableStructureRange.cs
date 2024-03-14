using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class AttackableStructure : MonoBehaviour
{
    [SerializeField] private AttackPerimiter attackPerimiter = new();


    private void Start()
    {
        this.GenerateAndApplyAttackPerimiterCollider();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log($"Trigger {this.gameObject.name} entered by {collider.name}");
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        Debug.Log($"Trigger {this.gameObject.name} exited by {collider.name}");
    }

    private void GenerateAndApplyAttackPerimiterCollider()
    {
        Rect perimiterOutline = this.CalculateAttackPerimiterOutline(attackPerimiter);
        BoxCollider2D attackPerimiterCollider = this.AddComponent<BoxCollider2D>();

        // Convert the perimiter outline to the local size of the structure it's attached to
        attackPerimiterCollider.size = new Vector2(
            perimiterOutline.width / this.transform.lossyScale.x,
            perimiterOutline.height / this.transform.lossyScale.y
        );
        attackPerimiterCollider.isTrigger = true;
    }

    #region Debug line drawing
    private void OnDrawGizmos()
    {
        this.DrawAttackPerimiterGizmo(this.attackPerimiter);
    }

    private void DrawAttackPerimiterGizmo(AttackPerimiter attackPerimiter)
    {
        Rect perimiterOutline = this.CalculateAttackPerimiterOutline(attackPerimiter);

        Gizmos.color = Color.red;

        // Top line
        Gizmos.DrawLine(
            new Vector3(perimiterOutline.x                         , perimiterOutline.y + perimiterOutline.height, 0f),
            new Vector3(perimiterOutline.x + perimiterOutline.width, perimiterOutline.y + perimiterOutline.height, 0f)
        );

        // Right line
        Gizmos.DrawLine(
            new Vector3(perimiterOutline.x + perimiterOutline.width, perimiterOutline.y                          , 0f),
            new Vector3(perimiterOutline.x + perimiterOutline.width, perimiterOutline.y + perimiterOutline.height, 0f)
        );

        // Bottom line
        Gizmos.DrawLine(
            new Vector3(perimiterOutline.x                         , perimiterOutline.y, 0f),
            new Vector3(perimiterOutline.x + perimiterOutline.width, perimiterOutline.y, 0f)
        );

        // Left line
        Gizmos.DrawLine(
            new Vector3(perimiterOutline.x, perimiterOutline.y                          , 0f),
            new Vector3(perimiterOutline.x, perimiterOutline.y + perimiterOutline.height, 0f)
        );
    }

    private Rect CalculateAttackPerimiterOutline(AttackPerimiter attackPerimiter)
    {
        float halfWidth = (this.transform.lossyScale.x / 2) + attackPerimiter.perimiterBounds.x;
        float cornerLeftX = this.transform.position.x - halfWidth;
        float cornerRightX = this.transform.position.x + halfWidth;

        float halfHeight = (this.transform.lossyScale.y / 2) + attackPerimiter.perimiterBounds.y;
        float cornerTopY = this.transform.position.y - halfHeight;
        float cornerBottomY = this.transform.position.y + halfHeight;

        return new Rect(cornerLeftX, cornerTopY, cornerRightX - cornerLeftX, cornerBottomY - cornerTopY);
    }
    #endregion
}

[Serializable]
public class AttackPerimiter
{
    [SerializeField] public Vector2 perimiterBounds;
    [SerializeField] public string tag;
}

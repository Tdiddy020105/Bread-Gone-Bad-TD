using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class AttackableStructure : MonoBehaviour
{
    [SerializeField] List<AttackPerimiter> attackPerimiters = new List<AttackPerimiter>();

    private void Start()
    {

    }

    private void Update()
    {

    }

    #region Debug line drawing
    private void OnDrawGizmos()
    {
        foreach (AttackPerimiter attackPerimiter in this.attackPerimiters)
        {
            this.DrawAttackPerimiterGizmo(attackPerimiter);
        }
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
        float halfWidth = (this.transform.localScale.x / 2) + attackPerimiter.perimiterBounds.x;
        float cornerLeftX = this.transform.localPosition.x - halfWidth;
        float cornerRightX = this.transform.localPosition.x + halfWidth;

        float halfHeight = (this.transform.localScale.y / 2) + attackPerimiter.perimiterBounds.y;
        float cornerTopY = this.transform.localPosition.y - halfHeight;
        float cornerBottomY = this.transform.localPosition.y + halfHeight;

        return new Rect(cornerLeftX, cornerTopY, cornerRightX - cornerLeftX, cornerBottomY - cornerTopY);
    }
    #endregion
}

[Serializable]
public class AttackPerimiter
{
    [SerializeField] public Vector2 perimiterBounds;
    [SerializeField] public String tag;
}

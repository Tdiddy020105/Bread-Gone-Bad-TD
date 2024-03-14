using System;
using Unity.VisualScripting;
using UnityEngine;
using Cinemachine;

[Serializable]
public class AttackPerimiter
{
    [SerializeField]
    public Vector2 perimiterBounds;

    [TagField]
    [SerializeField]
    public string tag;
}

public class AttackableStructureRange : MonoBehaviour
{
    public static event Action<AttackableStructure> onCanAttackStructure;
    public static event Action onCannotAttackStructure;

    [SerializeField] private AttackPerimiter attackPerimiter = new();


    private void Start()
    {
        this.GenerateAndApplyAttackPerimiterCollider();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        AttackableStructure attackableStructure = this.GetComponentInParent<AttackableStructure>();

        if (collider.tag != this.attackPerimiter.tag || attackableStructure == null)
        {
            return;
        }

        onCanAttackStructure?.Invoke(attackableStructure);
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.tag != this.attackPerimiter.tag)
        {
            return;
        }

        onCannotAttackStructure?.Invoke();
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
        // Lossy scale is used to properly apply the global scale of all parent objects
        // This will allow the actual attack perimiter to be scaled properly

        // These calculations look wonky because we need to go to the outer most points from the center of the object
        // (The game object's origin point is located in its center)
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

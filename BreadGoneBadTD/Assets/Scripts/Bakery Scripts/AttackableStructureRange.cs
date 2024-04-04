using System;
using Unity.VisualScripting;
using UnityEngine;
using Cinemachine;

[Serializable]
public class AttackPerimeter
{
    [SerializeField]
    public Vector2 perimeterBounds;

    [TagField]
    [SerializeField]
    public string tag;
}

public class AttackableStructureRange : MonoBehaviour
{
    // Supress this warning because it will break the serialized field
    #pragma warning disable IDE0044 // Add readonly modifier
    [SerializeField] private AttackPerimeter attackPerimeter = new();
    #pragma warning restore IDE0044 // Add readonly modifier


    private void Start()
    {
        this.GenerateAndApplyAttackPerimeterCollider();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        AttackableStructure attackableStructure = this.GetComponentInParent<AttackableStructure>();

        if (collider.tag != this.attackPerimeter.tag || attackableStructure == null || !collider.gameObject.activeSelf)
        {
            return;
        }

        collider.SendMessage("CanAttackStructure", attackableStructure);
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.tag != this.attackPerimeter.tag || !collider.gameObject.activeSelf)
        {
            return;
        }

        collider.SendMessage("CannotAttackStructure");
    }

    private void GenerateAndApplyAttackPerimeterCollider()
    {
        Rect perimeterOutline = PerimeterHelpers.CalculatePerimeterOutline(
            this.gameObject.transform,
            this.attackPerimeter.perimeterBounds.x,
            this.attackPerimeter.perimeterBounds.y
        );
        BoxCollider2D attackPerimeterCollider = this.AddComponent<BoxCollider2D>();

        attackPerimeterCollider.size = PerimeterHelpers.PerimeterOutlineSizeToLocalTransformSize(
            perimeterOutline,
            this.transform
        );
        attackPerimeterCollider.isTrigger = true;
    }

    #region Debug line drawing
    private void OnDrawGizmos()
    {
        this.DrawAttackPerimeterGizmo();
    }

    private void DrawAttackPerimeterGizmo()
    {
        Rect perimeterOutline = PerimeterHelpers.CalculatePerimeterOutline(
            this.gameObject.transform,
            this.attackPerimeter.perimeterBounds.x,
            this.attackPerimeter.perimeterBounds.y
        );

        Gizmos.color = Color.red;
        PerimeterHelpers.DrawAttackPerimeterGizmo(perimeterOutline);
    }
    #endregion
}

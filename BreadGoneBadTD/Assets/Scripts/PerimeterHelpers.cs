using UnityEngine;

public class PerimeterHelpers : MonoBehaviour
{
    public static Vector2 PerimeterOutlineSizeToLocalTransformSize(Rect perimeterOutline, Transform transform)
    {
        // Convert the perimeter outline to the local size of the transform from the game object it's attached to
        return new Vector2(
            perimeterOutline.width / transform.lossyScale.x,
            perimeterOutline.height / transform.lossyScale.y
        );
    }

    public static void DrawAttackPerimeterGizmo(Rect perimeterOutline)
    {
        // Top line
        Gizmos.DrawLine(
            new Vector3(perimeterOutline.x                         , perimeterOutline.y + perimeterOutline.height, 0f),
            new Vector3(perimeterOutline.x + perimeterOutline.width, perimeterOutline.y + perimeterOutline.height, 0f)
        );

        // Right line
        Gizmos.DrawLine(
            new Vector3(perimeterOutline.x + perimeterOutline.width, perimeterOutline.y                          , 0f),
            new Vector3(perimeterOutline.x + perimeterOutline.width, perimeterOutline.y + perimeterOutline.height, 0f)
        );

        // Bottom line
        Gizmos.DrawLine(
            new Vector3(perimeterOutline.x                         , perimeterOutline.y, 0f),
            new Vector3(perimeterOutline.x + perimeterOutline.width, perimeterOutline.y, 0f)
        );

        // Left line
        Gizmos.DrawLine(
            new Vector3(perimeterOutline.x, perimeterOutline.y                          , 0f),
            new Vector3(perimeterOutline.x, perimeterOutline.y + perimeterOutline.height, 0f)
        );
    }

    public static Rect CalculatePerimeterOutline(Transform transform, float perimeterBoundsX, float perimeterBoundsY)
    {
        // Lossy scale is used to properly apply the global scale of all parent objects
        // This will allow the actual attack perimeter to be scaled properly

        // These calculations look wonky because we need to go to the outer most points from the center of the object
        // (The game object's origin point is located in its center)
        float halfWidth = (transform.lossyScale.x / 2) + perimeterBoundsX;
        float cornerLeftX = transform.position.x - halfWidth;
        float cornerRightX = transform.position.x + halfWidth;

        float halfHeight = (transform.lossyScale.y / 2) + perimeterBoundsY;
        float cornerTopY = transform.position.y - halfHeight;
        float cornerBottomY = transform.position.y + halfHeight;

        return new Rect(cornerLeftX, cornerTopY, cornerRightX - cornerLeftX, cornerBottomY - cornerTopY);
    }
}

using UnityEngine;

public class TempMouseFollowEnemy : MonoBehaviour
{
    [SerializeField] private Camera cam;

    void Update()
    {
        this.transform.position = this.cam.ScreenToWorldPoint(
            new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1)
        );

        // Remove enemy when left mouse button is clicked
        if (Input.GetMouseButtonDown(0))
        {
            Destroy(this.gameObject);
        }
    }

    private void CanAttackStructure(AttackableStructure attackableStructure)
    {
        Debug.Log($"{this.gameObject.name} Attacks!");
        attackableStructure.TakeDamage(5);
    }

    private void CannotAttackStructure()
    {
        Debug.Log($"{this.gameObject.name} cannot attack anymore.");
    }
}

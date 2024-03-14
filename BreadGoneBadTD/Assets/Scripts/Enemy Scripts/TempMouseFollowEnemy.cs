using UnityEngine;

public class TempMouseFollowEnemy : MonoBehaviour
{
    [SerializeField] private Camera cam;

    private void OnEnable()
    {
        AttackableStructureRange.onCanAttackStructure += this.HandleCanAttackState;
        AttackableStructureRange.onCannotAttackStructure += this.HandleCannotAttackState;
    }

    private void OnDisable()
    {
        AttackableStructureRange.onCanAttackStructure -= this.HandleCanAttackState;
        AttackableStructureRange.onCannotAttackStructure -= this.HandleCannotAttackState;
    }

    void Update()
    {
        this.transform.position = this.cam.ScreenToWorldPoint(
            new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1)
        );
    }

    private void HandleCanAttackState(AttackableStructure attackableStructure)
    {
        Debug.Log($"{this.gameObject.name} Attacks!");
        attackableStructure.DealDamage(5);
    }

    private void HandleCannotAttackState()
    {
        Debug.Log($"{this.gameObject.name} cannot attack anymore.");
    }
}

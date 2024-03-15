using UnityEngine;

public class TempMouseFollowEnemy : MonoBehaviour
{
    [SerializeField] private Camera cam;

    private void OnEnable()
    {
        AttackableStructureRange.OnCanAttackStructure += this.HandleCanAttackState;
        AttackableStructureRange.OnCannotAttackStructure += this.HandleCannotAttackState;
    }

    private void OnDisable()
    {
        AttackableStructureRange.OnCanAttackStructure -= this.HandleCanAttackState;
        AttackableStructureRange.OnCannotAttackStructure -= this.HandleCannotAttackState;
    }

    void Update()
    {
        this.transform.position = this.cam.ScreenToWorldPoint(
            new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1)
        );
    }

    private void HandleCanAttackState(int instanceId, AttackableStructure attackableStructure)
    {
        if (this.gameObject.GetInstanceID() != instanceId)
        {
            return;
        }

        Debug.Log($"{this.gameObject.name} Attacks!");
        attackableStructure.TakeDamage(5);
    }

    private void HandleCannotAttackState(int instanceId)
    {
        if (this.gameObject.GetInstanceID() != instanceId)
        {
            return;
        }

        Debug.Log($"{this.gameObject.name} cannot attack anymore.");
    }
}

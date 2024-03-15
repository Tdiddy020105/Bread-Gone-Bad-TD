using UnityEngine;

public class TempInactiveEnemy : MonoBehaviour
{
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

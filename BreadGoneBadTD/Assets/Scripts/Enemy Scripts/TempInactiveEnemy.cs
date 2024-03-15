using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempInactiveEnemy : MonoBehaviour
{
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
